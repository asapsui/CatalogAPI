// this method extends the definition of type by adding a method that can be exceuted
using Catalog.Dtos;
using Catalog.Entitites;

namespace Catalog
{
    // has to be a static class
    public static class Extensions{
        
        // this method recieves an item by using the current item(this) and returns the ItemDto version
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto 
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
}