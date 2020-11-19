using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace ProjectEternity.Core.Online
{
    public unsafe class OnlineHost
    {
        public Dictionary<string, OnlineScript> DicOnlineScripts = new Dictionary<string, OnlineScript>();

        private List<IOnlineConnection> ListPlayerClient;
        private TcpListener HostListener;
        private bool CanListen;
        private readonly OnlineWriter WriteBuffer;

        public OnlineHost()
        {
            WriteBuffer = new OnlineWriter();
            ListPlayerClient = new List<IOnlineConnection>();
        }

        public OnlineHost(List<IOnlineConnection> ListPlayerClient)
        {
            WriteBuffer = new OnlineWriter();
            this.ListPlayerClient = ListPlayerClient;
        }

        public void StartListening()
        {
            try
            {
                IPEndPoint ListeningEndPoint = new IPEndPoint(IPAddress.Any, 2312);
                HostListener = new TcpListener(ListeningEndPoint);
                HostListener.Start();
                CanListen = true;
            }
            catch (Exception)
            {
                CanListen = false;
            }
        }

        public void StopListening()
        {
            CanListen = false;

            try
            {
                if (HostListener != null)
                {
                    HostListener.Stop();
                    HostListener = null;
                }
            }
            catch (Exception)
            {
            }
        }

        public void CheckForNewClient()
        {
            if (!CanListen)
            {
                return;
            }

            try
            {
                if (HostListener.Pending())
                {
                    //Accept the pending client connection and return a TcpClient object initialized for communication.
                    TcpClient PlayerClient = HostListener.AcceptTcpClient();
                    PlayerClient.NoDelay = true;

                    // Get a stream object for reading and writing
                    NetworkStream PlayerStream = PlayerClient.GetStream();

                    OnlineConnection NewPlayer = new OnlineConnection(PlayerClient, PlayerStream, DicOnlineScripts, WriteBuffer);
                    ListPlayerClient.Add(NewPlayer);
                }
            }
            catch (SocketException)
            {
            }
        }

        public void Update()
        {
            CheckForNewClient();

            for (int C = ListPlayerClient.Count - 1; C >= 0 ; --C)
            {
                IOnlineConnection Sender = ListPlayerClient[C];

                foreach (OnlineScript ActiveScript in Sender.ReadScripts())
                {
                    ActiveScript.Execute(Sender);

                    SendToClients(ActiveScript, Sender);
                }
            }
        }

        private void SendToClients(OnlineScript ScriptToSend, IOnlineConnection Sender)
        {
            WriteBuffer.ClearWriteBuffer();
            WriteBuffer.WriteScript(ScriptToSend);

            foreach (IOnlineConnection OnlinePlayer in ListPlayerClient)
            {
                if (OnlinePlayer == Sender)
                    continue;

                OnlinePlayer.SendWriteBuffer();
            }
        }
    }
}
