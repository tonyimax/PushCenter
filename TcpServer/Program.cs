using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TcpServer
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

            //绑定主机与端口
            socket.Bind(new IPEndPoint(IPAddress.Any, 4530));
            //启动消息监听,最大连接数100
            socket.Listen(100);
            //接受传入的连接(异步方式)
            socket.BeginAccept(new AsyncCallback(ClientAccepted), socket);

            Console.WriteLine("服务端已准备好！");
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
                Console.WriteLine(msg);

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
        /// <summary>
        /// 客户端连接
        /// </summary>
        /// <param name="ar"></param>
        static void ClientAccepted(IAsyncResult ar)
        {
            var socket = ar.AsyncState as Socket;
            var client = socket.EndAccept(ar);
            client.Send(Encoding.UTF8.GetBytes("This is MetroX" + DateTime.Now));

            //定时发送消息
            var time = new System.Timers.Timer();
            time.Interval = 2000D;
            time.Enabled = true;
            time.Elapsed += (o, a) =>
            {
                if (client.Connected)
                {
                    var str = "已花费时间：" + DateTime.Now.ToString();
                    client.Send(Encoding.UTF8.GetBytes(str));
                }
                else
                {
                    time.Stop();
                    time.Enabled = false;
                    Console.WriteLine("客户端已断开");
                }
            };
            time.Start();

            //接收消息
            //接收客户端消息
            client.BeginReceive(
                buffer,
                0,
                buffer.Length,
                SocketFlags.None,
                new AsyncCallback(ReciverMsg),
                client);
            //接收下一个连接
            socket.BeginAccept(new AsyncCallback(ClientAccepted), socket);
        }
    }
}
