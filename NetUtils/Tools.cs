using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Windows.Forms;
namespace NetUtils
{
    public class Tools
    {
        public static string GetNetworkInterfaces()
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            var host = computerProperties.HostName;
            var dns = computerProperties.DomainName;
            var mac = "";
            if (nics == null || nics.Length < 1)
            {
                return "  No network interfaces found.";
            }
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    PhysicalAddress address = adapter.GetPhysicalAddress();
                    byte[] bytes = address.GetAddressBytes();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        mac += string.Format("{0}", bytes[i].ToString("X2"));
                        if (i != bytes.Length - 1)
                        {
                            mac += string.Format("-");
                        }
                    }
                }
            }
            return mac;
            //return string.Format("主机名:{0},域名:{1},MAC地址:{2},时间{3}", host, dns, mac,DateTime.Now);
        }

        static byte[] buffer = new byte[1024];
        /// <summary>
        /// 异步接收消息
        /// </summary>
        /// <param name="ar">Socket对象</param>
        /// <returns></returns>
        public static void ReciverMsg(IAsyncResult ar)
        {
            try
            {
                var socket = ar.AsyncState as Socket;
                var leng = socket.EndReceive(ar);
                var msg = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                
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
                MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// 客户端连接
        /// </summary>
        /// <param name="ar"></param>
        public static void ClientAccepted(IAsyncResult ar)
        {
            var socket = ar.AsyncState as Socket;
            var client = socket.EndAccept(ar);
            byte[] data = Encoding.UTF8.GetBytes("This is MetroX" + DateTime.Now);
            client.Send(data,0,data.Length,SocketFlags.None);
            //定时发送消息
            var time = new System.Timers.Timer();
            time.Interval = 2000D;
            time.Enabled = true;
            time.Elapsed += (o, a) =>
            {
                if (client.Connected)
                {
                    byte[] data1 = Encoding.UTF8.GetBytes("已花费时间：" + DateTime.Now);
                    client.Send(data1, 0, data.Length, SocketFlags.None);
                }
                else
                {
                    time.Stop();
                    time.Enabled = false;
                    MessageBox.Show("客户端已断开");
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
