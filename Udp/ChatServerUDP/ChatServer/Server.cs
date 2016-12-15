using System;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Net;
using System.Collections;

using ChatApplication;

namespace ChatServer
{
    public partial class Server : Form
    {
        #region Private Members

        // Structure to store the client information
        private struct Client
        {
            public EndPoint EndPoint;
        }

        // Listing of clients
        private ArrayList _clientList;

        // Server socket
        private Socket _serverSocket;

        // Data stream
        private readonly byte[] _dataStream = new byte[1024];

        // Status delegate
        private delegate void UpdateStatusDelegate(string status);
        private UpdateStatusDelegate _updateStatusDelegate;

        #endregion

        #region Constructor

        public Server()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void Server_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialise the ArrayList of connected clients
                _clientList = new ArrayList();

                // Initialise the delegate which updates the status
                _updateStatusDelegate = UpdateStatus;

                // Initialise the socket
                _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                // Initialise the IPEndPoint for the server and listen on port 30000
                IPEndPoint server = new IPEndPoint(IPAddress.Any, 30000);

                // Associate the socket with this IP address and port
                _serverSocket.Bind(server);

                // Initialise the IPEndPoint for the clients
                IPEndPoint clients = new IPEndPoint(IPAddress.Any, 0);

                // Initialise the EndPoint for the clients
                EndPoint epSender = clients;

                // Start listening for incoming data
                _serverSocket.BeginReceiveFrom(_dataStream, 0, _dataStream.Length, SocketFlags.None, ref epSender, ReceiveData, epSender);

                lblStatus.Text = @"Listening";
            }
            catch (Exception ex)
            {
                lblStatus.Text = @"Error";
                MessageBox.Show(@"Load Error: " + ex.Message, @"UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Send And Receive

        public void SendData(IAsyncResult asyncResult)
        {
            try
            {
                _serverSocket.EndSend(asyncResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"SendData Error: " + ex.Message, @"UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReceiveData(IAsyncResult asyncResult)
        {
            try
            {
                byte[] data;

                // Initialise a packet object to store the received data
                Packet receivedData = new Packet(_dataStream);

                // Initialise a packet object to store the data to be sent
                Packet sendData = new Packet();

                // Initialise the IPEndPoint for the clients
                IPEndPoint clients = new IPEndPoint(IPAddress.Any, 0);

                // Initialise the EndPoint for the clients
                EndPoint epSender = clients;

                // Receive all data
                _serverSocket.EndReceiveFrom(asyncResult, ref epSender);

                // Start populating the packet to be sent
                sendData.ChatDataIdentifier = receivedData.ChatDataIdentifier;
                sendData.ChatName = receivedData.ChatName;

                switch (receivedData.ChatDataIdentifier)
                {
                    case DataIdentifier.Message:
                        sendData.ChatMessage = string.Format("{0}: {1}", receivedData.ChatName, receivedData.ChatMessage);
                        break;

                    case DataIdentifier.LogIn:
                        // Populate client object
                        Client client = new Client();
                        client.EndPoint = epSender;

                        // Add client to list
                        _clientList.Add(client);

                        sendData.ChatMessage = string.Format("-- {0} is online --", receivedData.ChatName);
                        break;

                    case DataIdentifier.LogOut:
                        // Remove current client from list
                        foreach (Client c in _clientList)
                        {
                            if (c.EndPoint.Equals(epSender))
                            {
                                _clientList.Remove(c);
                                break;
                            }
                        }

                        sendData.ChatMessage = string.Format("-- {0} has gone offline --", receivedData.ChatName);
                        break;
                }

                // Get packet as byte array
                data = sendData.GetDataStream();

                foreach (Client client in _clientList)
                {
                    if (client.EndPoint != epSender || sendData.ChatDataIdentifier != DataIdentifier.LogIn)
                    {
                        // Broadcast to all logged on users
                        _serverSocket.BeginSendTo(data, 0, data.Length, SocketFlags.None, client.EndPoint, SendData, client.EndPoint);
                    }
                }

                // Listen for more connections again...
                _serverSocket.BeginReceiveFrom(_dataStream, 0, _dataStream.Length, SocketFlags.None, ref epSender, ReceiveData, epSender);

                // Update status through a delegate
                Invoke(_updateStatusDelegate, sendData.ChatMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"ReceiveData Error: " + ex.Message, @"UDP Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Other Methods

        private void UpdateStatus(string status)
        {
            rtxtStatus.Text += status + Environment.NewLine;
        }

        #endregion
    }
}