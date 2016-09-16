using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace C10000
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            var time = new System.Timers.Timer();
            Console.WriteLine("启动实例" + count);
            Process.Start("TcpClient.exe");
            time.Interval = 3000D;
            time.Enabled = true;
            time.Elapsed += (o, a) =>
            {
                if (count < 10000)
                {
                    Console.WriteLine("启动实例" + count);
                    Process.Start("TcpClient.exe");
                    count++;
                }
                else
                {
                    time.Enabled = false;
                }
            };
            time.Start();
            Console.Read();
        }
    }
}
