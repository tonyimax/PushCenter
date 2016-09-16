using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetUtils;
using System.Net.Sockets;
namespace client
{
    class Program
    {

        static void Connect()
        {
            var info = Tools.GetNetworkInterfaces();
            Console.WriteLine(info);
            string server = "192.168.1.102";
            string message = "客户端：" + info;
            Int32 port = 13000;
            try
            {
                //连接服务端
                TcpClient client = new TcpClient(server, port);
                //编码消息
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(info);
                //获取网络流对象
                NetworkStream stream = client.GetStream();
                //发送消息给服务端 
                stream.Write(data, 0, data.Length);
                Console.WriteLine("已发送消息: {0}", message);
                //用来保存服务端响应消息的容器
                data = new Byte[256];
                String responseData = String.Empty;
                //读取网络流
                Int32 bytes = stream.Read(data, 0, data.Length);
                //编码数据
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("接收到的消息: {0}", responseData);
                //关闭网络流与套接字
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("参数为空: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("连接出错: {0}", e);
            }
            Console.WriteLine("\n 按任何键继续...");
            Console.Read();
        }
        static void Main(string[] args)
        {
            Connect();
        }
    }
}
