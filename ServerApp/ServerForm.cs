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

namespace ServerApp
{
    public partial class ServerForm : Form
    {
        private delegate void ConnectDelegate();
        // делегат для приема сообщений
        private delegate void Send();

        Socket socket;
        Socket client;
        EndPoint end;
        byte[] buffer;

        public ServerForm()
        {
            InitializeComponent(); 
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void ServerOnButton_Click(object sender, EventArgs e)
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(textBox1.Text), 8080);
                end = (EndPoint)ipe;
                socket.Bind(ipe);
                socket.Listen(10);
                ServerTextBox.Text += $"Сервер включён в {DateTime.Now}. Порт в режиме ожидания соединения...\n";
                ServerOffButton.Enabled = true;
                new ConnectDelegate(delegate () { Connect(); }).BeginInvoke(null, null);
                //while (true)
                //{
                //
                //    Socket handler = socket.Accept();
                //    string data = null;
                //
                //
                //    byte[] bytes = new byte[1024];
                //    int bytesRec = handler.Receive(bytes);
                //
                //    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                //
                //    ServerTextBox.Text += $"Полученный текст от клиента: {data}\n\n";
                //
                //    string reply = $"Спасибо за запрос в {data.Length} символов";
                //    byte[] msg = Encoding.UTF8.GetBytes(reply);
                //    handler.Send(msg);
                //
                //    if (data.IndexOf("<TheEnd>") > -1)
                //    {
                //        ServerTextBox.Text += "Сервер завершил соединение с клиентом.";
                //        break;
                //    }
                //
                //    handler.Shutdown(SocketShutdown.Both);
                //    handler.Close();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void Connect()
        {
            client = socket.Accept();
            ServerTextBox.Text += $"Клиент подключен в {DateTime.Now}.\n";
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 46)
            {
                e.Handled = true;
            }
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }

        private void SendToClientButton_Click(object sender, EventArgs e)
        {
            new Send(delegate () { Connected(); }).BeginInvoke(null, null);
        }
        private void Connected()
        {
            while (true)
            {
                SendMessage();
            }
        }
        private void SendMessage()
        {
            try
            {
                // получение сообщения
                buffer = new byte[256];
                client.ReceiveFrom(buffer, ref end);
                ServerTextBox.Text += Encoding.Default.GetString(buffer);
                // отправка ответа
                string str = "Сообщение получено";
                byte[] service = Encoding.Default.GetBytes(str);
                client.Send(service, service.Length, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {

        }
    }
}
