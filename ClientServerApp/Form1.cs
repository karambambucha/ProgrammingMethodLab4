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
using System.IO;

namespace ClientServerApp
{
    public partial class Form1 : Form
    {
        static int portNumber = 8080;
        TcpListener serverSocket;
        TcpClient clientSocket;
        public Form1()
        {
            InitializeComponent(); 
            CheckForIllegalCrossThreadCalls = false;
        }
        #region [ SERVER  ]
        private void ServerOnButton_Click(object sender, EventArgs e)
        {
            try
            {
                serverSocket = new TcpListener(IPAddress.Parse(textBox1.Text), portNumber);
                Thread ThreadingServer = new Thread(StartServer);
                ThreadingServer.Start();
                ServerOffButton.Enabled = true;
                ServerOnButton.Enabled = false;
                ConnectButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RecieveMessage(string message)
        {
            ServerTextBox.Text += $"{message}. {DateTime.Now}\n";
        }
        private void StartServer()
        {
            Action<string> DelegateRecieveMessage = RecieveMessage;
            serverSocket.Start();
            Invoke(DelegateRecieveMessage, $"Сервер включён в {DateTime.Now}. Порт в режиме ожидания соединения...");
            clientSocket = serverSocket.AcceptTcpClient();
            ServerTextBox.Text += $"Клиент подключен с адреса: {(IPEndPoint)clientSocket.Client.RemoteEndPoint} {DateTime.Now}\n";
            SendList();
            while (true)
            {
                try
                {
                    NetworkStream networkStream = clientSocket.GetStream();
                    byte[] bytesFrom = new byte[20];
                    networkStream.Read(bytesFrom, 0, 20);
                    string dataFromClient = Encoding.UTF8.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    string serverResponse;
                    if (dataFromClient == "Тест")
                    {

                        serverResponse = "Принято!";
                    }
                    else
                    {
                        serverResponse = "провал тутуру";
                    }
                    byte[] sendBytes = Encoding.UTF8.GetBytes(serverResponse);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();
                    ServerTextBox.Text += $"Сервер получил сообщение от клиента: {dataFromClient}. {DateTime.Now}\n";
                }
                catch
                {
                    serverSocket.Stop();
                    serverSocket.Start();
                    Invoke(DelegateRecieveMessage, $"Перезагрузка сервера...");
                    clientSocket = serverSocket.AcceptTcpClient();
                    Invoke(DelegateRecieveMessage, $"Перезагрузка... Сервер включён в {DateTime.Now}. Порт в режиме ожидания соединения...");
                }
            }
        }
        private void SendList()
        {
            string listOfDevices = "Список писек";
            byte[] listBytes = Encoding.UTF8.GetBytes(listOfDevices);
            NetworkStream networkStream = clientSocket.GetStream();
            networkStream.Write(listBytes, 0, listBytes.Length);
            networkStream.Flush();
        }
        #endregion

        #region [ CLIENT  ]
        TcpClient tcpClient = new TcpClient();
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                tcpClient.Connect(IPAddress.Parse(textBox1.Text), portNumber);
                ClientTextBox.Text += $"Подключено к серверу! {DateTime.Now}\n"; 
                Thread ThreadingClient = new Thread(AcceptResponses);
                ThreadingClient.Start();
                DisconnectButton.Enabled = true;
                SendToServerButton.Enabled = true;
                ConnectButton.Enabled = false;
                SendToClientButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AcceptResponses()
        {
            while (true)
            {
                try
                {
                    NetworkStream clientStream = tcpClient.GetStream();
                    byte[] bb = new byte[100];

                    clientStream.Read(bb, 0, 100);
                    string serverResponse = Encoding.UTF8.GetString(bb);

                    ClientTextBox.Text += $"Клиент получил ответ от сервера: {serverResponse}";
                    ClientTextBox.Text += $" {DateTime.Now}\n";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void SendToServerButton_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "Тест" + "$";
                NetworkStream clientStream = tcpClient.GetStream();
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] bytes = encoding.GetBytes(message);
                ClientTextBox.Text += $"Передача {message.Substring(0, message.IndexOf("$"))} серверу... {DateTime.Now}\n";
                clientStream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        #endregion

    }
}
