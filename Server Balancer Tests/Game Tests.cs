using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Tests
{
    [TestClass]
    public class GameTests
    {
        [TestInitialize]
        public void Init()
        {
        }

        [TestMethod]
        public void TestConnectToExistingMaster()
        {
            byte[] ArrayGameData = GetSnapshotData();
            using (MemoryStream MS = new MemoryStream(ArrayGameData))
            {
                using (BinaryReader BR = new BinaryReader(MS))
                {
                    bool HasGameStarted = BR.ReadBoolean();
                    int NumberOfPlayers = BR.ReadInt32();
                    Assert.IsTrue(HasGameStarted);
                    Assert.AreEqual(10, NumberOfPlayers);
                }
            }
        }

        public byte[] GetSnapshotData()
        {
            using (MemoryStream MS = new MemoryStream())
            {
                using (BinaryWriter BW = new BinaryWriter(MS))
                {
                    BW.Write(true);
                    BW.Write(10);
                    return MS.ToArray();
                }
            }
        }
    }
}
