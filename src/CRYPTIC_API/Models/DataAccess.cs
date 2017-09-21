using CRYPTIC_API.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

namespace CRYPTIC_API.Models
{
    public class DataAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("TradingDB");

        }

        public IEnumerable<Order> GetOrders()
        {
            return _db.GetCollection<Order>("Orders").FindAll();
        }


        public Order GetOrder(ObjectId id)
        {
            var res = Query<Order>.EQ(p => p.Id, id);
            return _db.GetCollection<Order>("Orders").FindOne(res);
        }

        public Order Create(Order p)
        {
            _db.GetCollection<Order>("Orders").Save(p);


            p.OrderId = p.Id.ToString();
            _db.GetCollection<Order>("Orders").Save(p);

            return p;
        }

        public Order Update(ObjectId id, Order p)
        {
            p.Id = id;
            var res = Query<Order>.EQ(pd => pd.Id, id);
            var operation = Update<Order>.Replace(p);
            _db.GetCollection<Order>("Orders").Update(res, operation);
            return p;
        }
        public void Remove(ObjectId id)
        {
            var res = Query<Order>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Order>("Orders").Remove(res);
        }
    }
}
