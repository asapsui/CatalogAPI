using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos 
{
    public record CreateItemDto 
    {
        // data annotation requiring these be inputted or else the system fails
        [Required]
        // we dont need the created date or the id, cause that will be auto-generated by the server
        public string Name { get; init; }
        
        [Required]
        [Range(1,1000)] // protecting the values coming in to the controller
        public decimal Price { get; init; }

    }
}