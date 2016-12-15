using System;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Net;

using ChatApplication;

namespace ChatClient
{
    public partial class Client : Form
    {
        #region Private Members

        // Client socket
        private Socket _clientSocket;

        // Client _name
        private string _name;

        // Server End Point
        private EndPoint _epServer;

        // Data stream
        private byte[] _dataStream = new byte[1024];

        // Display message delegate
        private delegate void DisplayMessageDelegate(string message);
        private DisplayMessageDelegate _displayMessageDelegate;

        #endregion

        #region Constructor

        public Client()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void Client_Load(object sender, EventArgs e)
        {
            // Initialise delegate
            _displayMessageDelegate = DisplayMessage;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                // Initialise a packet object to store the data to be sent
                Packet sendData = new Packet();
                sendData.ChatName = _name;
                sendData.ChatMessage = txtMessage.Text.Trim();
                sendData.ChatDataIdentifier = DataIdentifier.Message;

                // Get packet as byte array
                byte[] byteData = sendData.GetDataStream();

                // Send packet to the server
                _clientSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, _epServer, SendData, null);

                txtMessage.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Send Error: " + ex.Message, @"UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_clientSocket != null)
                {
                    // Initialise a packet object to store the data to be sent
                    Packet sendData = new Packet();
                    sendData.ChatDataIdentifier = DataIdentifier.LogOut;
                    sendData.ChatName = _name;
                    sendData.ChatMessage = null;

                    // Get packet as byte array
                    byte[] byteData = sendData.GetDataStream();

                    // Send packet to the server
                    _clientSocket.SendTo(byteData, 0, byteData.Length, SocketFlags.None, _epServer);

                    // Close the socket
                    _clientSocket.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Closing Error: " + ex.Message, @"UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                _name = txtName.Text.Trim();

                // Initialise a packet object to store the data to be sent
                Packet sendData = new Packet();
                sendData.ChatName = _name;
                sendData.ChatMessage = null;
                sendData.ChatDataIdentifier = DataIdentifier.LogIn;

                // Initialise socket
                _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // Initialise server IP
                IPAddress serverIp = IPAddress.Parse(txtServerIP.Text.Trim());

                // Initialise the IPEndPoint for the server and use port 30000
                IPEndPoint server = new IPEndPoint(serverIp, 30000);

                // Initialise the EndPoint for the server
                _epServer = server;

                // Get packet as byte array
                byte[] data = sendData.GetDataStream();

                // Send data to server
                _clientSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, _epServer, SendData, null);

                // Initialise data stream
                _dataStream = new byte[1024];

                // Begin listening for broadcasts
                _clientSocket.BeginReceiveFrom(_dataStream, 0, _dataStream.Length, SocketFlags.None, ref _epServer, ReceiveData, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Connection Error: " + ex.Message, @"UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Send And Receive

        private void SendData(IAsyncResult ar)
        {
            try
            {
                _clientSocket.EndSend(ar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Send Data: " + ex.Message, @"UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReceiveData(IAsyncResult ar)
        {
            try
            {
                // Receive all data
                _clientSocket.EndReceive(ar);

                // Initialise a packet object to store the received data
                Packet receivedData = new Packet(_dataStream);

                // Update display through a delegate
                if (receivedData.ChatMessage != null)
                    Invoke(_displayMessageDelegate, new object[] { receivedData.ChatMessage });

                // Reset data stream
                _dataStream = new byte[1024];

                // Continue listening for broadcasts
                _clientSocket.BeginReceiveFrom(_dataStream, 0, _dataStream.Length, SocketFlags.None, ref _epServer, ReceiveData, null);
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(@"Receive Data: " + ex.Message, @"UDP Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Other Methods

        private void DisplayMessage(string messge)
        {
            rtxtConversation.Text += messge + Environment.NewLine;
        }

        #endregion
    }
}
