using System;
using System.Collections.Generic;
using System.IO;
using ProjectEternity.Core.Online;

namespace ClientForm
{
    public class JoinRoomLocalScriptClientForm : OnlineScript
    {
        private delegate void SafeCallDelegate(IOnlineConnection Host);

        public const string ScriptName = "Join Room Local";

        private readonly ClientForm Owner;

        private string RoomID;
        private bool HasGame;
        private readonly List<Player> ListPlayer;
        private uint PlayerID;
        private byte[] ArrayGameData;

        public JoinRoomLocalScriptClientForm(ClientForm Owner)
            : base(ScriptName)
        {
            this.Owner = Owner;

            HasGame = false;
            ListPlayer = new List<Player>();
            ArrayGameData = null;
        }

        public override OnlineScript Copy()
        {
            return new JoinRoomLocalScriptClientForm(Owner);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Host)
        {
            if (Owner.lstRoomPlayers.InvokeRequired)
            {
                Owner.lstRoomPlayers.Invoke(new SafeCallDelegate(Execute), new object[] { Host });
            }
            else
            {
                Owner.txtRoomID.Text = RoomID.ToString();
                Owner.lstRoomPlayers.Items.Clear();

                for (int P = 0; P < ListPlayer.Count; ++P)
                {
                    Owner.lstRoomPlayers.Items.Add(ListPlayer[P]);
                }

                if (HasGame)
                {
                    Owner.ActiveGame = new TextGame(ArrayGameData);

                    Owner.GamePlayer = Owner.ActiveGame.DicPlayerByID[PlayerID];

                    Owner.UpdateGame();
                    Owner.UpdateGameUI();
                }
            }
        }

        protected override void Read(OnlineReader Sender)
        {
            RoomID = Sender.ReadString();

            using (MemoryStream MS = new MemoryStream(Sender.ReadByteArray()))
            {
                using (BinaryReader BR = new BinaryReader(MS))
                {
                    int NumberOfPlayers = BR.ReadInt32();
                    for (int P = 0; P < NumberOfPlayers; ++P)
                    {
                        Player NewPlayer = new Player();
                        NewPlayer.ID = BR.ReadString();
                        NewPlayer.Name = BR.ReadString();
                        ListPlayer.Add(NewPlayer);
                    }
                }
            }

            HasGame = Sender.ReadBoolean();

            if (HasGame)
            {
                PlayerID = Sender.ReadUInt32();
                ArrayGameData = Sender.ReadByteArray();
            }
        }
    }
}
