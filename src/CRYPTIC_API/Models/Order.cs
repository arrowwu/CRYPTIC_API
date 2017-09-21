using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRYPTIC_API.Models
{
    public class Order
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("OrderId")]
        public string OrderId { get; set; }

        [BsonElement("OrderName")]
        public string OrderName { get; set; }

        [BsonElement("Price")]
        public int Price { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }
    }
}
