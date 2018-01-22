using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.HttpClient
{
    public class SocketDemo
    {
        static IPAddress address;
        static IPEndPoint endPoint;
        static Socket socket;
        public SocketDemo()
        {
            address = IPAddress.Loopback;
            endPoint = new IPEndPoint(address, 50001);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(endPoint);
            socket.Listen(10);
        }
        public static void SocketIns()
        {
            Console.WriteLine("开始监听，端口号{0}", endPoint.Port);
            while (true)
            {
                //开始监听，这个方法会阻塞进程，直到接收到第一个连接请求
                Socket client = socket.Accept();
                Console.WriteLine("客户端地址:{0}", client.RemoteEndPoint);
                //准备读取客户端请求数据，读取的数据将保存在一个数组中
                byte[] buffer = new byte[4096];
                //接收数据
                int length = client.Receive(buffer, 4096, SocketFlags.None);
                //请求编码方式
                System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
                //将请求数据保存为UTF-8
                string requestString = utf8.GetString(buffer, 0, length);
                //回应的状态行
                string statusLine = "HTTP/1.1 200 OK\r\n";
                byte[] statusLineBytes = utf8.GetBytes(statusLine);
                //准备发送到客户端的网页
                string responseBody = "Hello!!!";
                byte[] responseBodyBytes = utf8.GetBytes(responseBody);
                //回应的头部
                string responseHeader = string.Format("Content-Type: text/html;charset = UTF-8\r\nContent-Length:{0}\r\n", responseBody.Length);
                byte[] responseHeaderBytes = utf8.GetBytes(responseHeader);
                //向客户端发送信息
                client.Send(statusLineBytes);
                client.Send(responseHeaderBytes);
                //头部与内容的分割行
                client.Send(new byte[] { 13, 10 });
                client.Send(responseBodyBytes);
                //断开与客户端的链接
                client.Close();
                if (Console.KeyAvailable)
                {
                    break;
                }
            }
            //关闭服务器
            socket.Close();
        }
    }
}
