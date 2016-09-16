using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace TcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建网络套接对象
            var socket = new Socket(
                AddressFamily.InterNetwork, //IPV4
                SocketType.Stream, //流式套接字
                ProtocolType.Tcp //TCP方式
            );
            socket.Connect("127.0.0.1",4530);//连接服务端
            Console.WriteLine("已连接到服务端");
            string str = "MAC:" + NetUtils.Tools.GetNetworkInterfaces()  + " IP: " + socket.LocalEndPoint.ToString().Split(':')[0] + " " + DateTime.Now;
            socket.Send(Encoding.UTF8.GetBytes(str));
            //接收消息容器
            var buffer = new byte[1024];
            //开始异步接收(只接收一次)
            socket.BeginReceive(
                buffer,
                0,
                buffer.Length,
                SocketFlags.None,
                new AsyncCallback((ar) =>
                {
                    var leng = socket.EndReceive(ar);
                    var msg = Encoding.UTF8.GetString(buffer, 0, leng);
                    Console.WriteLine(msg);
                }), null);

            //开始异步接收(一直接收消息)
            socket.BeginReceive(
                buffer,
                0,
                buffer.Length,
                SocketFlags.None,
                new AsyncCallback(ReciverMsg), socket);
            Console.Read();
        }

        static byte[] buffer = new byte[1024];
        /// <summary>
        /// 异步接收消息
        /// </summary>
        /// <param name="ar">Socket对象</param>
        /// <returns></returns>
        static void ReciverMsg(IAsyncResult ar)
        {
            try
            {
                var socket = ar.AsyncState as Socket;
                var leng = socket.EndReceive(ar);
                var msg = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                Console.WriteLine(msg.Trim());

                socket.BeginReceive(
                    buffer, 
                    0, 
                    buffer.Length, 
                    SocketFlags.None,
                    new AsyncCallback(ReciverMsg), 
                    socket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

       
    }
}
