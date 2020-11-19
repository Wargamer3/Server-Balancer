using ProjectEternity.Core.Online;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationBalancer
{
    /// <summary>
    /// Handle communication between local clients or send communication higher to allow cross server communication.
    /// To avoid excessive cross server communication the clients in the communication servers should match the game servers.
    /// When a client sends a message it check if the receiver is on the server, if it's not it send it to its Server Manager that will send it to the proper Server
    /// </summary>
    class Server
    {
        public readonly IOnlineConnection Host;
        public readonly List<IOnlineConnection> ListPlayer;
        public readonly List<Group> ListGroup;
    }

    /// <summary>
    /// Group with direct connection to each client to avoid cross server communication.
    /// </summary>
    class Group
    {
        List<IOnlineConnection> ListGroupMember;
    }
}
