using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace ProjectEternity.Core.Online
{
    public unsafe class OnlineConnection : OnlineReader, IOnlineConnection
    {
        private readonly OnlineWriter WriteBuffer;

        private DateTimeOffset LastUpdate = DateTimeOffset.Now;

        public string IP => ActiveClient.Client.RemoteEndPoint.ToString();

        public string ID { get; set; }
        public string Name { get; set; }

        public OnlineConnection(TcpClient ActiveClient, NetworkStream ActiveStream, Dictionary<string, OnlineScript> DicOnlineScripts)
            : base(ActiveClient, ActiveStream, DicOnlineScripts)
        {
            WriteBuffer = new OnlineWriter();
        }

        public OnlineConnection(TcpClient ActiveClient, NetworkStream ActiveStream, Dictionary<string, OnlineScript> DicOnlineScripts, OnlineWriter SharedWriteBuffer)
            : base(ActiveClient, ActiveStream, DicOnlineScripts)
        {
            this.WriteBuffer = SharedWriteBuffer;
        }

        public void AddOrReplaceScripts(Dictionary<string, OnlineScript> DicNewScript)
        {
            foreach (var ActiveScript in DicNewScript)
            {
                if (!this.DicOnlineScripts.ContainsKey(ActiveScript.Key))
                {
                    this.DicOnlineScripts.Add(ActiveScript.Key, ActiveScript.Value);
                }
                else
                {
                    this.DicOnlineScripts[ActiveScript.Key] = ActiveScript.Value;
                }
            }
        }

        public void Send(OnlineScript ScriptToSend)
        {
            WriteBuffer.ClearWriteBuffer();
            ScriptToSend.Write(WriteBuffer);
            WriteBuffer.Send(ActiveStream);
        }

        public void Close()
        {
            ActiveClient.Client.NoDelay = true;
            ActiveClient.Client.Disconnect(false);
            ActiveStream.Close();
            ActiveClient.Close();
        }

        public void SendWriteBuffer()
        {
            WriteBuffer.Send(ActiveStream);
        }

        IEnumerable<OnlineScript> IOnlineConnection.ReadScripts()
        {
            if (IsConnected())
            {
                LastUpdate = DateTimeOffset.Now;
            }

            return ReadScripts();
        }

        public IOnlineConnection ReOpen()
        {
            IPEndPoint HostEndPoint = new IPEndPoint(IPAddress.Parse(IP), 2312);
            TcpClient UserClient = new TcpClient();
            UserClient.NoDelay = true;
            UserClient.Connect(HostEndPoint);

            // Get a client stream for reading and writing.
            NetworkStream HostStream = UserClient.GetStream();

            return new OnlineConnection(UserClient, HostStream, null);
        }

        public bool IsConnected()
        {
            return ActiveClient.Connected;
        }

        public bool HasLeftServer()
        {
            return DateTimeOffset.Now.Subtract(LastUpdate).TotalSeconds > 30;
        }

        public override string ToString()
        {
            return IP;
        }
    }
}
