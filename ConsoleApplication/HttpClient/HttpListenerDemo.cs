using System;
using System.Net;

namespace ConsoleApplication.HttpClient
{
    public class HttpListenerDemo
    {
        public static void HttpListenerIns()
        {
            if (!HttpListener.IsSupported)
            {
                throw new InvalidOperationException("必须为XP SP2或Server2003以上系统！");
            }
            //前缀必须以/正斜杠结尾
            string[] prefixes = new string[] { "http://localhost:50002/" };
            //创建监听
            HttpListener listener = new HttpListener();
            //增加监听前缀
            foreach (string s in prefixes)
                listener.Prefixes.Add(s);
            listener.Start();
            Console.WriteLine("监听中...");
            while (true)
            {
                //阻塞进程，知道请求到达
                HttpListenerContext context = listener.GetContext();
                Console.WriteLine("接收到{0}的请求", context.Request.RemoteEndPoint);
                HttpListenerRequest request = context.Request;
                //取得回应对象
                HttpListenerResponse response = context.Response;
                string responseString = @"<html><body>hehe</body></html>";
                response.ContentLength64 = System.Text.Encoding.UTF8.GetByteCount(responseString);
                response.ContentType = "text/html;charset = UTF-8";
                System.IO.Stream output = response.OutputStream;
                System.IO.StreamWriter writer = new System.IO.StreamWriter(output);
                writer.Write(responseString);
                writer.Close();//必须关闭输出流
                if (Console.KeyAvailable)
                    break;
            }
            listener.Stop();
        }
    }
}
