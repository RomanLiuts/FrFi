using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrFi.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Internal;


namespace FrFi.DomainModel
{
    public class Data
    {
        //private const string connectionString = "mongodb://localhost:27017/db";

        public static void CreateUser(UserModel user)
        {
            MongoServer server = MongoServer.Create("mongodb://127.0.0.1:27017");

            MongoDatabase users = server.GetDatabase("db");

            MongoCollection<BsonDocument> collection = users.GetCollection<BsonDocument>("Users");

            BsonDocument bsonUser = new BsonDocument(user.ToBsonDocument());

            collection.Insert(user);
        }
    }
}