using System;
using System.Collections.Generic;
using ProjectEternity.Core.Online;

namespace Tests
{
    class DummyDataManager : IDataManager
    {
        DateTimeOffset LastTimeChecked;
        private readonly string RoomID;

        public DummyDataManager(string RoomID)
        {
            this.RoomID = RoomID;
            LastTimeChecked = DateTimeOffset.MinValue;
        }

        public List<IRoomInformations> GetAllRoomUpdatesSinceLastTimeChecked(string ServerVersion)
        {
            DateTimeOffset CurrentTime = DateTimeOffset.Now;

            if (CurrentTime > LastTimeChecked + TimeSpan.FromSeconds(10))
            {
                //fetch
                LastTimeChecked = CurrentTime;
                return new List<IRoomInformations>();
            }

            return null;
        }

        public IRoomInformations GenerateNewRoom(string RoomName, string Password, string OwnerServerIP, int OwnerServerPort)
        {
            return new RoomInformations(RoomID, RoomName, OwnerServerIP, OwnerServerPort);
        }

        public IRoomInformations TransferRoom(string RoomID, string OwnerServerIP)
        {
            return new RoomInformations(RoomID, "", "", 0);
        }

        public void UpdatePlayerCountInRoom(string RoomID, int CurrentPlayerCount)
        {
        }

        public void RemoveRoom(string RoomID)
        {
        }

        public void DeleteOldRooms(string ServerIP, int ServerPort)
        {
        }

        public Player GetPlayerInfo(string Login, string Password)
        {
            throw new NotImplementedException();
        }
    }
}
