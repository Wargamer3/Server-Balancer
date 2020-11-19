using System;

namespace ProjectEternity.Core.Online
{
    public interface IOnlineGame
    {
        bool HasGameStarted { get; }

        byte[] GetSnapshotData();

        void Update(double ElapsedSeconds);
    }
}
