using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;
using CRYPTIC_API.Models;


namespace CRYPTIC_API.Controllers
{
    [Route("api/order")]
    public class OrderAPIController : Controller
    {
        DataAccess objds;

        public OrderAPIController(DataAccess d)
        {
            objds = d;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return objds.GetOrders();
        }

        [HttpGet("{id:length(24)}")]
        public IActionResult Get(string id)
        {
            var order = objds.GetOrder(new ObjectId(id));
            if (order == null)
            {
                return NotFound();
            }
            return new ObjectResult(order);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Order p)
        {
            objds.Create(p);
            return new OkObjectResult(p);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]Order p)
        {
            var recId = new ObjectId(id);
            var order = objds.GetOrder(recId);
            if (order == null)
            {
                return NotFound();
            }

            objds.Update(recId, p);
            return new OkObjectResult(p);
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var order = objds.GetOrder(new ObjectId(id));
            if (order == null)
            {
                return NotFound();
            }

            objds.Remove(order.Id);
            return new OkResult();
        }
    }
}