using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEternity.Core.Online;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class MasterTests
    {
        private Master Master1Test;
        private Master Master2Test;

        private DummyOnlineConnection MockMaster1ToMaster2Connection;
        private DummyOnlineConnection MockMaster2ToMaster1Connection;

        [TestInitialize]
        public void Init()
        {
            Master1Test = new Master();
            Master2Test = new Master();

            Dictionary<string, OnlineScript> DicServerOnlineScripts = new Dictionary<string, OnlineScript>();
            Dictionary<string, OnlineScript> DicClientOnlineScripts = new Dictionary<string, OnlineScript>();
            
            List<OnlineScript> ListClientToServerScriptSent = new List<OnlineScript>();
            List<OnlineScript> ListServerToClientScriptSent = new List<OnlineScript>();

            MockMaster1ToMaster2Connection = new DummyOnlineConnection("MockServerToClientConnection", DicServerOnlineScripts, ListClientToServerScriptSent, ListServerToClientScriptSent);
            MockMaster2ToMaster1Connection = new DummyOnlineConnection("MockClientToServerConnection", DicClientOnlineScripts, ListServerToClientScriptSent, ListClientToServerScriptSent);
        }

        [TestMethod]
        public void TestConnectToExistingMaster()
        {
            Master1Test.ConnectToExistingMaster(MockMaster1ToMaster2Connection);
            Master2Test.OnMasterConnected(MockMaster2ToMaster1Connection);
        }
    }
}
