using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPI.Models;
using MyFirstWebAPI.Services;
using System.Collections.Generic;

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
        public void Post([FromBody] Item item)
        {
            ItemAction itemAction = new();
            itemAction.Insert(item);
        }

        [HttpPut()]
        public void Put([FromBody] Item item)
        {
            ItemAction itemAction = new();
            itemAction.Update(item);
        }

        [HttpDelete("{id}")]
        public void Delete(uint id)
        {
            ItemAction itemAction = new();
            itemAction.Delete(id);
        }
    }
}