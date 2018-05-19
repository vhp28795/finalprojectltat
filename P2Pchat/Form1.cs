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
using System.Security.Cryptography;
using System.Timers;

namespace P2Pchat
{
    public partial class Form1 : Form
    {
        AES256 aes = new AES256();
        Hkdf hkdf = new Hkdf();
        Socket sck;
        EndPoint epLocal, epRemote;
        byte[] buffer;
        byte[] pubk;
        ECDiffieHellmanCng key_pair;
        DH difhel = new DH();
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyDown += text1_KeyDown;
        }

        public Form1( ECDiffieHellmanCng DH, byte[] otherpubk, int port1, int port2)
        {
            InitializeComponent();
            key_pair = DH;
            pubk = otherpubk;
            this.port1.Text = port1.ToString();
            this.port2.Text = port2.ToString();
            textBox1.KeyDown += text1_KeyDown;
        }

        private void Form1_Load(object sender, EventArgs e )
        {
            // Set up Socket
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            //Set up IP
            ipclient1.Text = GetLocalIP();
            ipclient2.Text = GetLocalIP();

            //Generate key DH
            //key_pair = difhel.generate_DH();

        }

     
        private void connect_Click(object sender, EventArgs e)
        {
            //binding Socket
            epLocal = new IPEndPoint(IPAddress.Parse(ipclient1.Text), Convert.ToInt32(port1.Text));
            sck.Bind(epLocal);
            //Connecting to remote IP
            epRemote = new IPEndPoint(IPAddress.Parse(ipclient2.Text), Convert.ToInt32(port2.Text));
            sck.Connect(epRemote);
            //Listening the specific port
            buffer = new byte[1500];
            sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);

            
            if (sck.Connected)
            {
                connect.Text = "Connected!";
                connect.Enabled = false;
                ipclient1.Enabled = false;
                ipclient2.Enabled = false;
                port1.Enabled = false;
                port2.Enabled = false;
            }
        }

        
        private void MessageCallBack(IAsyncResult aResult)
        {
            try
            {
                int nReceived = sck.EndReceive(aResult);
                byte[] receiveData = null;
                receiveData = (byte[])aResult.AsyncState;
                byte[] ct = new byte[nReceived];
                Array.Copy(receiveData, 0, ct, 0, nReceived);

                byte[] pubka = new byte[72];
                Array.Copy(ct, 0, pubka, 0, 72);
                
                byte[] encryptedmes = new byte[ct.Length - 72];
                Array.Copy(ct, 72, encryptedmes, 0, ct.Length - 72);
                string receiveMessage = null;

                //Decrypt mess
                byte[] seck = difhel.DH1(key_pair, pubk);
                string key = Convert.ToString(seck);
                receiveMessage = aes.Decrypt(encryptedmes, key, 256);

                //tách padding
                byte[] mesbyte = Encoding.UTF8.GetBytes(receiveMessage);
                int length = mesbyte.Length;
                byte[] chuoi = new byte[length];
                while (mesbyte[length - 1] == 0x00)
                {
                    length--;
                }
                    length--;
                Array.Copy(mesbyte, 0, chuoi, 0, length);
                
                string receivemes = System.Text.Encoding.UTF8.GetString(chuoi); 

                //Adding this message into ListBox
                listBox1.Items.Add("Other: " + receivemes);

                //Show key DH & encrypt mess
                keybox.Text = System.Convert.ToBase64String(pubk);
                seckey.Text = System.Convert.ToBase64String(seck);
                encryptbox.Text = System.Convert.ToBase64String(encryptedmes);

                buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private byte [] padding(string mes)
        {
            int pad;
            if (mes.Length % 16 == 0)
                pad = 16;
            else pad = 16 - (mes.Length % 16);
            byte[] mesbyte = new byte[mes.Length + pad];
            Array.Copy(Encoding.UTF8.GetBytes(mes), 0, mesbyte, 0, mes.Length);
            mesbyte[mes.Length] = 0x61;
            for (int i = mes.Length + 1; i < mesbyte.Length; i++)
            {
                mesbyte[i] = 0x00;
            }
            return mesbyte;

        }
        private void sendmsg_Click(object sender, EventArgs e)
        {
            //Convert string message to byte[]
            UTF8Encoding aEncoding = new UTF8Encoding();
            byte[] sendingMessage = new byte[1500];

            //padding
            string mes = textBox1.Text;
            int pad;
            if (mes.Length % 16 == 0)
                pad = 16;
            else pad = 16 - (mes.Length % 16);
            byte[] mesbyte = new byte[mes.Length + pad];
            Array.Copy(Encoding.UTF8.GetBytes(mes), 0, mesbyte, 0, mes.Length);
            mesbyte[mes.Length] = 0x61;
            for (int i = mes.Length + 1; i < mesbyte.Length; i++)
            {
                mesbyte[i] = 0x00;
            }

            //Encrypt AES256 message
            byte[] seck = difhel.DH1(key_pair, pubk);
            string key = Convert.ToString(seck);
            byte[] send = aes.Encrypt(Encoding.UTF8.GetString(mesbyte), key, 256);
           
            byte[] packet = new byte[72 + send.Length];
            Array.Copy(pubk, 0, packet, 0, 72);
            Array.Copy(send, 0, packet, 72, send.Length);

            //Sending the Encoded message
            sck.Send(packet);

            //Adding to the listbox
            listBox1.Items.Add("Me: " + textBox1.Text);
            keybox.Text = System.Convert.ToBase64String(pubk);
            textBox1.Clear();
        }

        private void text1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendmsg_Click(null,null);
            }
        }
        private string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "127.0.0.1";
        }

        public char randomtext()
        {
            string chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rand = new Random();
            int num = rand.Next(0, chars.Length - 1);
            return chars[num];
        }
        private void sendnoise_Click(object sender, EventArgs e)
        {
            EncryptMD5 encrypt = new EncryptMD5();
            string mes = textBox1.Text;
            string mes1 = textBox1.Text + randomtext();

            byte[] seck = difhel.DH1(key_pair, pubk);
            string key = Convert.ToString(seck);

            string en1 = encrypt.MD5Hash(mes);
            string en2 = encrypt.MD5Hash(mes);
            if (en1 == en2)
            {
            
                string mes2 = "Goi tin da bi thay doi";

                byte[] send2 = aes.Encrypt(Encoding.UTF8.GetString(padding(mes2)), key, 256);
                byte[] packet2 = new byte[72 + send2.Length];
                Array.Copy(pubk, 0, packet2, 0, 72);
                Array.Copy(send2, 0, packet2, 72, send2.Length);

                //Sending the Encoded message
                sck.Send(packet2);
            }

            //Adding to the listbox
            listBox1.Items.Add("Me: " + textBox1.Text);
            keybox.Text = System.Convert.ToBase64String(pubk);
            textBox1.Clear();
        }
    }
}
