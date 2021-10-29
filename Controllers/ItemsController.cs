using System.Collections.Generic; // for our interface "IEnumberable"
using Catalog.Repositories;
using Catalog.Entitites;
using Microsoft.AspNetCore.Mvc; // for controllerbase
using System;
using System.Linq;
using Catalog.Dtos;
 
 // the controller class receieves the request by the client and handles it properly

 // here we are adding routes 


namespace Catalog.Controllers
{
    // GET /items -- thi is url

    [ApiController] // look up this
    [Route("items")] // this defines which http route this controller will be responding to
    public class ItemsController : ControllerBase // this inheritance essentially turns this into a controller class
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
           
            this.repository = repository; // a new instance is created 
        }

        // a route to retrieve all the items
        // this is so it will actually become a route and react to HTTp verb
        // if someone perfoms a get against items, this method will react to that
        [HttpGet] // attribute
        public IEnumerable<ItemDto> GetItems()
        {
            // using the var keyword makes it implicitly typed
                // meaning we have't defined it, but the compiler determines the type 
            var items = repository.GetItems().Select( item => item.AsDto()); //invoking our GetItems method
            return items;
        }

        // GET /items/id
        [HttpGet("{id}")] // attribute
        // using actionresult type enables us to return more than one type in this method
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null) 
            {
                return NotFound();
            }

            return item.AsDto();
        }

        // POST /items 
        // when someone does a post in the items route
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateItem(item);
            
            // we return the action that reflects the route to get information on the item
                // then we specify the id, thats going to be passed into that other route
                // then the actual object thats going to be returned
            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto());
        }

        // the thing between the <> is the convention
        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItem(id);
            // if we cant find it
            if (existingItem is null) 
            {
                return NotFound();
            }

            // this with expression is taking the "existingItem" and creating a copy of it 
                // with the modified values
            // updatedItem is a copy of existingItem with updated properties
            Item updatedItem = existingItem with 
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            repository.UpdateItem(updatedItem);

            return NoContent();

        } 

        // DELETE /items/{id}
        [HttpDelete]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);
            // if we cant find it
            if (existingItem is null) 
            {
                return NotFound();
            }

            repository.DeleteItem(id);
            return NoContent();
        }
    }
}