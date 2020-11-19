using System;
using System.Collections.Generic;
using ProjectEternity.Core.Online;

namespace Tests
{
    class DummyOnlineConnection : IOnlineConnection
    {
        public string IP { get; }
        public string ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IOnlineConnection.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public readonly string Name;
        public readonly List<OnlineScript> ListScriptToSend;
        public readonly List<OnlineScript> ListScriptSent;
        public readonly List<OnlineScript> ListScriptReceived;
        public readonly List<OnlineScript> ListScriptRead;

        private Dictionary<string, OnlineScript> DicServerOnlineScripts;

        public bool Connected;

        public DummyOnlineConnection(string Name,
            Dictionary<string, OnlineScript> DicServerOnlineScripts,
            List<OnlineScript> ListScriptSent)
        {
            this.Name = Name;
            this.DicServerOnlineScripts = DicServerOnlineScripts;
            this.ListScriptToSend = new List<OnlineScript>();
            this.ListScriptSent = ListScriptSent;
            ListScriptReceived = ListScriptReceived = ListScriptSent;
            this.ListScriptRead = new List<OnlineScript>();

            Connected = true;
        }

        public DummyOnlineConnection(string Name,
            Dictionary<string, OnlineScript> DicServerOnlineScripts,
            List<OnlineScript> ListScriptSent,
            List<OnlineScript> ListScriptReceived)
        {
            this.Name = Name;
            this.DicServerOnlineScripts = DicServerOnlineScripts;
            this.ListScriptToSend = new List<OnlineScript>();
            this.ListScriptSent = ListScriptSent;
            this.ListScriptReceived = ListScriptReceived;
            this.ListScriptRead = new List<OnlineScript>();

            Connected = true;
        }

        public DummyOnlineConnection(string Name,
            string IP,
            Dictionary<string, OnlineScript> DicServerOnlineScripts,
            List<OnlineScript> ListScriptSent,
            List<OnlineScript> ListScriptReceived)
        {
            this.Name = Name;
            this.IP = IP;
            this.DicServerOnlineScripts = DicServerOnlineScripts;
            this.ListScriptToSend = new List<OnlineScript>();
            this.ListScriptSent = ListScriptSent;
            this.ListScriptReceived = ListScriptReceived;
            this.ListScriptRead = new List<OnlineScript>();

            Connected = true;
        }

        internal void Clear()
        {
            ListScriptToSend.Clear();
            ListScriptSent.Clear();
            ListScriptReceived.Clear();
            ListScriptRead.Clear();
        }

        public void Close()
        {
        }

        public IOnlineConnection ReOpen()
        {
            return null;
        }

        public bool IsConnected()
        {
            return Connected;
        }

        public IEnumerable<OnlineScript> ReadScripts()
        {
            if (ListScriptReceived.Count == 0)
            {
                yield break;
            }

            foreach (OnlineScript ActiveScript in ListScriptReceived)
            {
                yield return DicServerOnlineScripts[ActiveScript.Name].Copy();
            }

            ListScriptReceived.Clear();
        }

        public void Send(OnlineScript ScriptToSend)
        {
            ListScriptSent.Add(ScriptToSend);
        }

        public void SendWriteBuffer()
        {
            ListScriptSent.Add(ListScriptToSend[0]);
            ListScriptToSend.RemoveAt(0);
        }

        public override string ToString()
        {
            return Name;
        }

        public void AddOrReplaceScripts(Dictionary<string, OnlineScript> DicNewScript)
        {
            throw new NotImplementedException();
        }

        public bool HasLeftServer()
        {
            throw new NotImplementedException();
        }
    }
}
