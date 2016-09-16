using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace PushCenter
{
    public partial class Form1
    {
        public  string GetNetworkInterfaces()
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
            //return string.Format("主机名:{0},域名:{1},MAC地址:{2},时间{3}", host, dns, mac, DateTime.Now);
        }

        static byte[] buffer = new byte[1024];
        /// <summary>
        /// 异步接收消息
        /// </summary>
        /// <param name="ar">Socket对象</param>
        /// <returns></returns>
        public  void ReciverMsg(IAsyncResult ar)
        {
            try
            {
                Action<String> actionDelegate = (x) => { listBox1.Items.Add(x.ToString()); };
                var socket = ar.AsyncState as Socket;
                var leng = socket.EndReceive(ar);
                var msg = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                listBox1.BeginInvoke(actionDelegate, msg.Trim());
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
                if (!e.Message.Contains("主机"))
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        /// <summary>
        /// 定时发送消息
        /// </summary>
        public void SendbyTime(Socket client, byte[] data)
        {
            //定时发送消息
            var time = new System.Timers.Timer();
            time.Interval = 2000D;
            time.Enabled = true;
            time.Elapsed += (o, a) =>
            {
                Action<String> actionDelegate = (x) => { lab_ServerMsg.Text = x.ToString(); };
                if (client.Connected)
                {
                    data = Encoding.UTF8.GetBytes("Server:" + GetNetworkInterfaces() + " IP: " + client.LocalEndPoint.ToString().Split(':')[0]);
                    client.Send(data, 0, data.Length, SocketFlags.None);
                }
                else
                {
                    time.Stop();
                    time.Enabled = false;
                    lab_ServerMsg.BeginInvoke(actionDelegate, "客户端已断开");
                }
            };
            time.Start();
        }

        public void HanderSend(Socket client, byte[] data)
        {
            Action<String> actionDelegate = (x) => { lab_ServerMsg.Text = x.ToString(); };
            client.Send(data, 0, data.Length, SocketFlags.None);
        }
        /// <summary>
        /// 客户端连接
        /// </summary>
        /// <param name="ar"></param>
        public  void ClientAccepted(IAsyncResult ar)
        {
            var socket = ar.AsyncState as Socket;
            var client = socket.EndAccept(ar);
            byte[] data = Encoding.UTF8.GetBytes("Welcome&Welcome to Server:" + GetNetworkInterfaces() + " IP:" + client.LocalEndPoint.ToString().Split(':')[0]);
            client.Send(data, 0, data.Length, SocketFlags.None);
            sockets.Add(client);
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
