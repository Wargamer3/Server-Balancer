using System;
using System.Collections.Generic;
using ProjectEternity.Core.Online;

namespace ServerForm
{
    public class AskJoinRoomScriptServerForm : AskJoinRoomScriptServer
    {
        public AskJoinRoomScriptServerForm(Server Owner)
            : base(Owner)
        {
        }

        public override OnlineScript Copy()
        {
            return new AskJoinRoomScriptServerForm(Owner);
        }

        protected override void OnJoinRoomLocal(IOnlineConnection Sender, string RoomID, ClientGroup ActiveGroup)
        {
            foreach (IOnlineConnection ActivePlayer in ActiveGroup.Room.ListOnlinePlayer)
            {
                if (ActivePlayer == Sender)
                {
                    continue;
                }

                ActivePlayer.Send(new PlayerJoinedScriptServer(ActiveGroup.Room.GetPlayer(Sender)));
            }

            Dictionary<string, OnlineScript> DicNewScript = new Dictionary<string, OnlineScript>();
            DicNewScript.Add(LeaveRoomScriptServer.ScriptName, new LeaveRoomScriptServer(ActiveGroup.Room, Owner));
            Sender.AddOrReplaceScripts(DicNewScript);

            PlayerWithID NewGamePlayer = null;

            if (ActiveGroup.CurrentGame != null)
            {
                TextGame CurrentGame = (TextGame)ActiveGroup.CurrentGame;
                NewGamePlayer = CurrentGame.AddPlayer();
                //Add Game Specific scripts
                DicNewScript = new Dictionary<string, OnlineScript>();
                DicNewScript.Add(SendSquareScriptServer.ScriptName, new SendSquareScriptServer(ActiveGroup, NewGamePlayer));
                DicNewScript.Add(SendCircleScriptServer.ScriptName, new SendCircleScriptServer(ActiveGroup, NewGamePlayer));
                DicNewScript.Add(FinishedLoadingScriptServer.ScriptName, new FinishedLoadingScriptServer(ActiveGroup, NewGamePlayer));
                Sender.AddOrReplaceScripts(DicNewScript);

                foreach (IOnlineConnection ActivePlayer in ActiveGroup.Room.ListOnlinePlayer)
                {
                    if (ActivePlayer == Sender)
                    {
                        continue;
                    }

                    ActivePlayer.Send(new CreatePlayerScriptServer(NewGamePlayer.ID, false));
                }
            }

            Sender.Send(new JoinRoomLocalScriptServerForm(RoomID, NewGamePlayer, ActiveGroup));
        }
    }
}
