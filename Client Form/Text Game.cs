using System;
using System.IO;
using System.Collections.Generic;
using ProjectEternity.Core.Online;

namespace ClientForm
{
    public class TextGame : IOnlineGame
    {
        public readonly Dictionary<uint, PlayerWithID> DicPlayerByID;

        int ExpectedNumberOfPlayers;

        public bool HasGameStarted { get; private set; }

        public TextGame(int ExpectedNumberOfPlayers)
        {
            this.ExpectedNumberOfPlayers = ExpectedNumberOfPlayers;

            DicPlayerByID = new Dictionary<uint, PlayerWithID>();

            HasGameStarted = false;
        }

        public TextGame(byte[] ArrayGameData)
        {
            using (MemoryStream MS = new MemoryStream(ArrayGameData))
            {
                using (BinaryReader BR = new BinaryReader(MS))
                {
                    ExpectedNumberOfPlayers = BR.ReadInt32();
                    DicPlayerByID = new Dictionary<uint, PlayerWithID>(ExpectedNumberOfPlayers);

                    for (int P = 0; P < ExpectedNumberOfPlayers; ++P)
                    {
                        uint ID = BR.ReadUInt32();
                        string Input = BR.ReadString();

                        DicPlayerByID.Add(ID, new PlayerWithID(ID, Input));
                    }
                }
            }
        }

        public byte[] GetSnapshotData()
        {
            using (MemoryStream MS = new MemoryStream())
            {
                using (BinaryWriter BW = new BinaryWriter(MS))
                {
                    BW.Write(DicPlayerByID.Count);
                    foreach (var ActivePlayer in DicPlayerByID.Values)
                    {
                        BW.Write(ActivePlayer.ID);
                        BW.Write(ActivePlayer.Input);
                    }

                    return MS.ToArray();
                }
            }
        }

        public void Update(double ElapsedSeconds)
        {
            if (!HasGameStarted)
            {
                if (DicPlayerByID.Count != ExpectedNumberOfPlayers)
                {
                    return;
                }

                foreach (PlayerWithID ActivePlayer in DicPlayerByID.Values)
                {
                    if (!ActivePlayer.HasFinishedLoadingGame)
                    {
                        return;
                    }
                }

                HasGameStarted = true;
            }
        }

        public PlayerWithID AddPlayer()
        {
            throw new NotImplementedException();
        }
    }
}
