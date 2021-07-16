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
using System.Threading;

namespace loganywhere
{
    public partial class Form1 : Form
    {
        private static Socket sock;
        private static IPEndPoint iep1;
        private static byte[] data;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            iep1 = new IPEndPoint(IPAddress.Parse(this.textBox1.Text), 9050);
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string hostname = DateTime.Now.ToString() + Dns.GetHostName() + "\r\n";
            data = Encoding.ASCII.GetBytes(hostname);
            sock.SendTo(data, iep1);
            this.label1.Text = hostname;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            iep1 = new IPEndPoint(IPAddress.Parse(this.textBox1.Text), 9050);
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
        }
    }
}
