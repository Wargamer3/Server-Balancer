using System.Collections.Generic;

namespace ProjectEternity.Core.Online
{
    public interface IDataManager
    {
        IRoomInformations GenerateNewRoom(string RoomName, string Password, string OwnerServerIP, int NewOwnerServerPort);
        List<IRoomInformations> GetAllRoomUpdatesSinceLastTimeChecked(string ServerVersion);
        void DeleteOldRooms(string ServerIP, int ServerPort);
        void RemoveRoom(string RoomID);
        IRoomInformations TransferRoom(string RoomID, string NewOwnerServerIP);
        void UpdatePlayerCountInRoom(string RoomID, int CurrentPlayerCount);
        Player GetPlayerInfo(string Login, string Password);
    }
}