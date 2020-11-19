using System.Collections.Generic;

namespace ProjectEternity.Core.Online
{
    public interface IRoomInformations
    {
        int CurrentPlayerCount { get; }
        string RoomID { get; }
        int MaxNumberOfPlayer { get; }
        bool IsDead { get; }
        string OwnerServerIP { get; }
        int OwnerServerPort { get; }
        string RoomName { get; }
        string MapName { get; set; }
        List<IOnlineConnection> ListOnlinePlayer { get; }

        void AddPlayer(IOnlineConnection NewPlayer);
        void RemovePlayer(IOnlineConnection OnlinePlayerToRemove);
        Player GetPlayer(IOnlineConnection Sender);

        byte[] GetRoomInfo();
    }
}