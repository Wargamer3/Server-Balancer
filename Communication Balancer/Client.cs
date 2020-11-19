using ProjectEternity.Core.Online;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommunicationBalancer
{
    class Client
    {
        public IOnlineConnection Host;
        public IOnlineConnection GroupHost;
        public List<IOnlineConnection> ListPrivateMessageGroup;

        public void JoinGroup(IOnlineConnection GroupHost)
        {

        }

        public void CreateGroup()
        {

        }

        public void MessageOtherClient()
        {
            //Send message to client
            //Create a groupe to allow direct messaging.
            CreateGroup();
            //Send group invite to other client
        }
    }
}
