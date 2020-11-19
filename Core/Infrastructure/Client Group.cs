using System;
using System.Collections.Generic;

namespace ProjectEternity.Core.Online
{
    public class ClientGroup
    {
        public IOnlineGame CurrentGame;
        public IRoomInformations Room;

        public ClientGroup(IRoomInformations Room)
        {
            this.Room = Room;
        }

        internal bool IsRunningSlow()
        {
            return false;
        }
    }
}
