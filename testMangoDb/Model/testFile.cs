using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace testMangoDb.Model
{
    public class testFile:tempUser
    {
        public ObjectId Id { get; set; }//存取MangoDb Id
        [BsonElement("wishList")]
        public List<wish> wishList { get; set; }
    }
    public class tempUser
    {
        [BsonElement("userName")]
        public string userName { get; set; }
        [BsonElement("userAccount")]
        public string userAccount { get; set; }
        [BsonElement("userPassword")]
        public string userPassword { get; set; }
    }
    public class wish
    {
        [BsonElement("prodOid")]
        public string prodOid { get; set; }
        [BsonElement("prodName")]
        public string prodName { get; set; }
    }
}
