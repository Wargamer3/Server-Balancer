using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using ProjectEternity.Core.Online;

namespace ServerForm
{
    public class MongoDBManager : IDataManager
    {
        private DateTime LastTimeChecked;
        private MongoClient DatabaseClient;
        private IMongoDatabase Database;
        private IMongoCollection<BsonDocument> RoomsCollection;
        private IMongoCollection<BsonDocument> PlayersCollection;

        public MongoDBManager()
        {
            LastTimeChecked = DateTime.MinValue;
        }

        public void Init()
        {
            DatabaseClient = new MongoClient("mongodb+srv://Wargamer:o1hCpZpjSeJuv2JG@triplethunder.x2fyo.gcp.mongodb.net/TripleThunder?retryWrites=true&w=majority");
            Database = DatabaseClient.GetDatabase("TripleThunder");
            RoomsCollection = Database.GetCollection<BsonDocument>("Rooms");
            PlayersCollection = Database.GetCollection<BsonDocument>("Players");
        }

        public List<IRoomInformations> GetAllRoomUpdatesSinceLastTimeChecked(string ServerVersion)
        {
            DateTime CurrentTime = DateTime.Now;
            FilterDefinition<BsonDocument> LastTimeCheckedFilter = Builders<BsonDocument>.Filter.Gte("LastUpdate", LastTimeChecked);
            List<BsonDocument> ListFoundRoomDocument = RoomsCollection.Find(LastTimeCheckedFilter).ToList();
            List<IRoomInformations> ListFoundRoom = new List<IRoomInformations>();

            foreach (BsonDocument ActiveDocument in ListFoundRoomDocument)
            {
                string RoomID = ActiveDocument.GetValue("_id").AsObjectId.ToString();
                string RoomName = ActiveDocument.GetValue("RoomName").AsString;
                string Password = ActiveDocument.GetValue("Password").AsString;
                string OwnerServerIP = ActiveDocument.GetValue("OwnerServerIP").AsString;
                int OwnerServerPort = ActiveDocument.GetValue("OwnerServerPort").AsInt32;
                int CurrentPlayerCount = ActiveDocument.GetValue("CurrentPlayerCount").AsInt32;
                int MaxNumberOfPlayer = ActiveDocument.GetValue("MaxNumberOfPlayer").AsInt32;
                bool IsDead = ActiveDocument.GetValue("IsDead").AsBoolean;

                IRoomInformations NewRoom = new RoomInformations(RoomID, RoomName, Password, OwnerServerIP, OwnerServerPort, CurrentPlayerCount, MaxNumberOfPlayer, IsDead);
                ListFoundRoom.Add(NewRoom);
            }

            LastTimeChecked = CurrentTime;
            return ListFoundRoom;
        }

        public void DeleteOldRooms(string OwnerServerIP, int OwnerServerPort)
        {
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("OwnerServerIP", OwnerServerIP) & Builders<BsonDocument>.Filter.Eq("OwnerServerPort", OwnerServerPort);

            RoomsCollection.DeleteManyAsync(filter);
        }

        public IRoomInformations GenerateNewRoom(string RoomName, string Password, string OwnerServerIP, int OwnerServerPort)
        {
            BsonDocument document = new BsonDocument
            {
                { "LastUpdate", DateTime.Now },
                { "RoomName", RoomName },
                { "Password", Password },
                { "OwnerServerIP", OwnerServerIP },
                { "OwnerServerPort", OwnerServerPort },
                { "CurrentPlayerCount", 1 },
                { "MaxNumberOfPlayer", 3 },
                { "IsDead", false },
            };

            RoomsCollection.InsertOne(document);

            RoomInformations NewRoom = new RoomInformations(document.GetValue("_id").AsObjectId.ToString(), RoomName, OwnerServerIP, OwnerServerPort);
            return NewRoom;
        }

        public IRoomInformations TransferRoom(string RoomID, string OwnerServerIP)
        {
            return null;
        }

        public void UpdatePlayerCountInRoom(string RoomID, int CurrentPlayerCount)
        {
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(RoomID));
            UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("CurrentPlayerCount", CurrentPlayerCount).Set("LastUpdate", DateTime.Now);
            RoomsCollection.UpdateOneAsync(filter, update);
        }

        public Player GetPlayerInfo(string Login, string Password)
        {
            FilterDefinition<BsonDocument> LastTimeCheckedFilter = Builders<BsonDocument>.Filter.Eq("Login", Login) & Builders<BsonDocument>.Filter.Eq("Password", Password);
            BsonDocument FoundPlayerDocument = PlayersCollection.Find(LastTimeCheckedFilter).FirstOrDefault();

            if (FoundPlayerDocument == null && PlayersCollection.Find(Builders<BsonDocument>.Filter.Eq("Login", Login)).FirstOrDefault() == null)
            {
                BsonDocument document = new BsonDocument
                {
                    { "Login", Login },
                    { "Name", Login },
                    { "Password", Password },
                    { "NumberOfFailedConnection", 0 },
                    { "Equipment",
                        new BsonArray
                        {
                            new BsonDocument { { "Money", 0 }, { "EXP", 0 } } }
                        }
                };

                PlayersCollection.InsertOne(document);
                FoundPlayerDocument = PlayersCollection.Find(LastTimeCheckedFilter).FirstOrDefault();
            }

            Player FoundPlayer = new Player();
            FoundPlayer.ID = FoundPlayerDocument.GetValue("_id").AsObjectId.ToString();
            FoundPlayer.Name = FoundPlayerDocument.GetValue("Name").AsString;
            return FoundPlayer;
        }

        public void RemoveRoom(string RoomID)
        {
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(RoomID));
            UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("IsDead", true).Set("LastUpdate", DateTime.Now);
            RoomsCollection.UpdateOneAsync(filter, update);
        }
    }
}
