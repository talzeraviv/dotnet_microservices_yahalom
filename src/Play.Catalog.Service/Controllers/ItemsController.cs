using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Dtos;

namespace Play.Catalog.Service.Controllers
{
    // Http://localhost:5241/items
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private static readonly List<ItemDto> items = new List<ItemDto>()
        {
            new ItemDto(Guid.NewGuid(), "Potion", "Restores a small amount of HP", 5, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Antidote", "Cures Poison", 7, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Bronze Sword", "Deals a small amount of damage", 20, DateTimeOffset.UtcNow)
        };

        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return items;
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        public ItemDto GetById(Guid id)
        {
            return items.SingleOrDefault(item => item.Id == id);
        }

        // ActionResult allows us to return a status code or an object
        // 
        [HttpPost]
        public ActionResult<ItemDto> Post(CreateItemDto createItemDto)
        {
            var item = new ItemDto(Guid.NewGuid(), createItemDto.Name, createItemDto.Description, createItemDto.Price, DateTimeOffset.UtcNow);

            // Object that says 'Hey, the item has been created (Status 201) and you can find it at the following route'
            // nameof(GetById) products a header in the response that specifies how to find the item by the getbyid method above.
            // new { id = item.Id} specifies the id of the created item. (Anonymous type)
            // item is the body of the response, which will give the actual item.
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }
    }
}