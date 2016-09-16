using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Net.WebSockets;
using System.Net.Security;
using System.Security;
using System.Threading;
namespace PushCenter
{
    public partial class Form1 : Form
    {
        public List<Socket> sockets;
        TcpClient client = null;
        TcpListener server = null;
        Thread svrThread = null;
        bool isStart = false;
        public Form1()
        {
            InitializeComponent();
            sockets = new List<Socket>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmb_PushPlatform.SelectedIndex = 0;
            cmb_PushTarget.SelectedIndex = 0;
        }

        private void btnAutoPush_Click(object sender, EventArgs e)
        {

        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            if (!isStart)
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
                lab_ServerMsg.Text = "服务已启动";
                isStart = !isStart;
            }
           
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            var data = Encoding.UTF8.GetBytes(textBox1.Text + "&" + textBox2.Text);
            foreach (var s in sockets)
            {
                HanderSend(s, data);
            }
        }

        void setText(string msg)
        {
            lab_ServerMsg.Text = msg;
        }
        ///// <summary>
        ///// 主线程调用的线程方法
        ///// </summary>
        //public void StartListener()
        //{
        //    Action<String> actionDelegate = (x) => { lab_ServerMsg.Text = x.ToString(); };
        //    try
        //    {
        //        Int32 port = 13000;
        //        IPAddress localAddr = IPAddress.Parse("192.168.1.102");
        //        server = new TcpListener(localAddr, port);
        //        server.Start();
        //        while (isStart)
        //        {
        //            lab_ServerMsg.BeginInvoke(actionDelegate, "侦听已启动，正在等待客户端连接...");
        //            TcpClient client = server.AcceptTcpClient();
        //            ReadData(client);
        //            SendData(client, "HelloWorld");
        //        }
        //    }
        //    catch (SocketException e){MessageBox.Show( string.Format("连接出错: {0}", e)); }
        //    finally{server.Stop();}
        //}

        //public void ReadData(TcpClient client)
        //{
        //    Action<String> listDelegate = (x) => { listBox1.Items.Add(x.ToString()); };
        //    //数据容器
        //    Byte[] bytes = new Byte[256];
        //    String data = null;
        //    //获取客户端网络流对象
        //    NetworkStream stream = client.GetStream();
        //    int i;
        //    try {
        //        //接收客户端发来的消息
        //        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
        //        {
        //            //编码数据，并显示客户端的消息
        //            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
        //            listBox1.BeginInvoke(listDelegate, DateTime.Now + " : " + data);
        //        }
        //    }
        //    catch (Exception ex) {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //public void SendData(TcpClient client, string data)
        //{
        //    if (client != null && client.Connected)
        //    {
        //        //获取客户端网络流对象
        //        NetworkStream stream = client.GetStream();
        //        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
        //        //发送服务端响应数据到客户端网络流
        //        stream.Write(msg, 0, msg.Length);
        //        //关闭套接字
        //        stream.Close();
        //        client.Close();
        //    }
        //}
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
            {
                server.Stop();
            }
        }
    }
}
