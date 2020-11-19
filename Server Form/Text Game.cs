using System;
using System.IO;
using System.Collections.Generic;
using ProjectEternity.Core.Online;

namespace ServerForm
{
    public class TextGame : IOnlineGame
    {
        public readonly Dictionary<uint, PlayerWithID> DicPlayerByID;

        private uint NextID;

        private readonly ClientGroup Owner;
        public bool HasGameStarted { get; private set; }

        //TODO: add an AI that plays with the player.
        public TextGame(ClientGroup Owner)
        {
            this.Owner = Owner;

            DicPlayerByID = new Dictionary<uint, PlayerWithID>();

            NextID = 1;
            HasGameStarted = false;
        }

        public PlayerWithID AddPlayer()
        {
            PlayerWithID NewPlayer = new PlayerWithID(NextID);
            DicPlayerByID.Add(NextID, NewPlayer);

            ++NextID;

            return NewPlayer;
        }

        public byte[] GetSnapshotData()
        {
            using (MemoryStream MS = new MemoryStream())
            {
                using (BinaryWriter BW = new BinaryWriter(MS))
                {
                    BW.Write(DicPlayerByID.Count);
                    foreach (PlayerWithID ActivePlayer in DicPlayerByID.Values)
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
                foreach (PlayerWithID ActivePlayer in DicPlayerByID.Values)
                {
                    if (!ActivePlayer.HasFinishedLoadingGame)
                    {
                        return;
                    }
                }

                foreach (IOnlineConnection ActiverPlayer in Owner.Room.ListOnlinePlayer)
                {
                    ActiverPlayer.Send(new StartGameScriptServer());
                }

                HasGameStarted = true;
            }
        }
    }
}
