using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.HttpClient
{
    public class TcpDemo
    {
        static IPAddress address;
        static IPEndPoint endPoint;
        static TcpListener nserver;
        public TcpDemo()
        {
            address = IPAddress.Loopback;
            endPoint = new IPEndPoint(address, 50001);
            nserver = new TcpListener(endPoint);
        }
        public static void TcpIns()
        {
            nserver.Start();
            Console.WriteLine("开始监听，端口号{0}", endPoint.Port);
            while (true)
            {
                TcpClient nclient = nserver.AcceptTcpClient();
                Console.WriteLine("已经建立连接");
                NetworkStream ns = nclient.GetStream();
                Encoding utf8 = Encoding.UTF8;
                byte[] request = new byte[4096];
                int length = ns.Read(request, 0, 4096);
                string requestString = utf8.GetString(request, 0, length);

                //回应的状态行
                string statusLine = "HTTP/1.1 200 OK\r\n";
                byte[] statusLineBytes = utf8.GetBytes(statusLine);
                //准备发送到客户端的网页
                string responseBody = "Hello!!!";
                byte[] responseBodyBytes = utf8.GetBytes(responseBody);
                //回应的头部
                string responseHeader = string.Format("Content-Type: text/html;charset = UTF-8\r\nContent-Length:{0}\r\n", responseBody.Length);
                byte[] responseHeaderBytes = utf8.GetBytes(responseHeader);
                ns.Write(statusLineBytes, 0, statusLineBytes.Length);
                ns.Write(responseHeaderBytes, 0, responseHeaderBytes.Length);
                ns.Write(new byte[] { 13, 10 }, 0, 2);
                ns.Write(responseBodyBytes, 0, responseBodyBytes.Length);
                nclient.Close();
                if (Console.KeyAvailable)
                    break;
            }
            nserver.Stop();
        }
    }
}
