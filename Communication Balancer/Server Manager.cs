using ProjectEternity.Core.Online;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationBalancer
{
    /// <summary>
    /// Used to direct clients to a Server.
    /// When a client sends a message it check if the receiver is inside one of its local server, if it's not it send it to a master that will send it to the proper Server Manager
    /// </summary>
    class ServerManager
    {
        public readonly List<IOnlineConnection> ListLocalServer;
        public readonly List<IOnlineConnection> ListMaster;
    }
}
