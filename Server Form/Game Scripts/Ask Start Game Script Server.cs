using System;
using System.Collections.Generic;
using ProjectEternity.Core.Online;

namespace ServerForm
{
    public class AskStartGameScriptServer : OnlineScript
    {
        public const string ScriptName = "Ask Start Game";

        private readonly ClientGroup CreatedGroup;

        public AskStartGameScriptServer(ClientGroup CreatedGroup)
            : base(ScriptName)
        {
            this.CreatedGroup = CreatedGroup;
        }

        public override OnlineScript Copy()
        {
            return new AskStartGameScriptServer(CreatedGroup);
        }

        protected override void DoWrite(OnlineWriter WriteBuffer)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(IOnlineConnection Sender)
        {
            TextGame NewGame = new TextGame(CreatedGroup);
            CreatedGroup.CurrentGame = NewGame;

            foreach (IOnlineConnection ActivePlayer in CreatedGroup.Room.ListOnlinePlayer)
            {
                ActivePlayer.Send(new CreateGameScriptServer());
            }

            foreach (IOnlineConnection ActivePlayer in CreatedGroup.Room.ListOnlinePlayer)
            {
                PlayerWithID NewGamePlayer = NewGame.AddPlayer();
                //Add Game Specific scripts
                Dictionary<string, OnlineScript> DicNewScript = new Dictionary<string, OnlineScript>();
                DicNewScript.Add(SendSquareScriptServer.ScriptName, new SendSquareScriptServer(CreatedGroup, NewGamePlayer));
                DicNewScript.Add(SendCircleScriptServer.ScriptName, new SendCircleScriptServer(CreatedGroup, NewGamePlayer));
                DicNewScript.Add(FinishedLoadingScriptServer.ScriptName, new FinishedLoadingScriptServer(CreatedGroup, NewGamePlayer));
                ActivePlayer.AddOrReplaceScripts(DicNewScript);

                //Send created Player to all Players.
                foreach (IOnlineConnection ActivePlayerInRoom in CreatedGroup.Room.ListOnlinePlayer)
                {
                    ActivePlayerInRoom.Send(new CreatePlayerScriptServer(NewGamePlayer.ID, ActivePlayer == ActivePlayerInRoom));
                }
            }
        }

        protected override void Read(OnlineReader Sender)
        {
        }
    }
}
