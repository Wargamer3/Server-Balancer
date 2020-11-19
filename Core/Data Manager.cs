using System;
using System.Collections.Generic;
using ProjectEternity.Core.Online;

namespace ProjectEternity.GameScreens.TripleThunderScreen
{
    public class DataManager : IDataManager
    {
        private DateTimeOffset LastTimeChecked;
        private int RoomIDCount;
        private SortedList<DateTimeOffset, List<IRoomInformations>> ListRoom;

        public DataManager()
        {
            LastTimeChecked = DateTimeOffset.MinValue;
            RoomIDCount = 1;
            ListRoom = new SortedList<DateTimeOffset, List<IRoomInformations>>();
        }

        //If there are server with multiple version running, ensure you won't show incompatible rooms.
        public List<IRoomInformations> GetAllRoomUpdatesSinceLastTimeChecked(string ServerVersion)
        {
            DateTimeOffset CurrentTime = DateTimeOffset.Now;
            List<IRoomInformations> ListRoomFound = new List<IRoomInformations>();

            bool CheckTime = true;
            IList<DateTimeOffset> RoomKeys = ListRoom.Keys;

            for (int R = 0; R < RoomKeys.Count; ++R)
            {
                if ((CheckTime && RoomKeys[R] >= LastTimeChecked) || !CheckTime)
                {
                    CheckTime = false;
                    foreach (IRoomInformations ActiveRoom in ListRoom[RoomKeys[R]])
                    {
                        ListRoomFound.Add(ActiveRoom);
                    }
                }
            }

            LastTimeChecked = CurrentTime;

            return ListRoomFound;
        }

        public IRoomInformations GenerateNewRoom(string RoomName, string Password, string OwnerServerIP, int OwnerServerPort)
        {
            DateTimeOffset CurrentTime = DateTimeOffset.Now;
            RoomInformations NewRoom = new RoomInformations(RoomIDCount++.ToString(), RoomName, OwnerServerIP, OwnerServerPort);

            if (ListRoom.ContainsKey(CurrentTime))
            {
                ListRoom[CurrentTime].Add(NewRoom);
            }
            else
            {
                ListRoom.Add(CurrentTime, new List<IRoomInformations>() { NewRoom });
            }

            return NewRoom;
        }

        public IRoomInformations TransferRoom(string RoomID, string OwnerServerIP)
        {
            throw new NotImplementedException();
        }

        public void RemoveRoom(string RoomID)
        {
        }

        public void UpdatePlayerCountInRoom(string RoomID, int CurrentPlayerCount)
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
