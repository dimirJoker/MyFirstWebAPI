using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPI.Models;
using MyFirstWebAPI.Services;
using System.Collections.Generic;
using System.Net;

namespace MyFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            ItemAction itemAction = new();

            return itemAction.GetAllItems();
        }

        [HttpGet("{id}")]
        public Item Get(uint id)
        {
            ItemAction itemAction = new();

            return itemAction.GetItemById(id);
        }

        [HttpPost]
        public HttpStatusCode Post([FromBody] Item item)
        {
            ItemAction itemAction = new();
            if (itemAction.Insert(item))
            {
                return HttpStatusCode.OK;
            }

            return HttpStatusCode.BadRequest;
        }

        [HttpPut()]
        public HttpStatusCode Put([FromBody] Item item)
        {
            ItemAction itemAction = new();
            if (itemAction.Update(item))
            {
                return HttpStatusCode.OK;
            }

            return HttpStatusCode.BadRequest;
        }

        [HttpDelete("{id}")]
        public HttpStatusCode Delete(uint id)
        {
            ItemAction itemAction = new();
            if (itemAction.Delete(id))
            {
                return HttpStatusCode.OK;
            }

            return HttpStatusCode.BadRequest;
        }
    }
}