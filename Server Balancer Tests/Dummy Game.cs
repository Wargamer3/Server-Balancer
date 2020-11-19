using System;
using ProjectEternity.Core.Online;

namespace Tests
{
    class DummyGame : IOnlineGame
    {
        public byte[] ArrayGameData;

        public bool HasGameStarted { get; private set; }
        
        public byte[] GetSnapshotData()
        {
            return ArrayGameData;
        }

        public void RestoreSnapshot(byte[] ArrayGameData)
        {
            this.ArrayGameData = ArrayGameData;
        }

        public void Update(double ElapsedSeconds)
        {
        }
    }
}
