using System;
using System.Collections.Generic;
using Catalog.Entitites;

namespace Catalog.Repositories
{

    // our interface
    public interface IItemsRepository
    {
        Item GetItem(Guid id);
        
        IEnumerable<Item> GetItems();

        void CreateItem(Item item); // this method returns nothing, it just receives the item that needs to be created in the repository

        void UpdateItem(Item item); // returns nothing, just recieves the item to get updated

        // wont need a Dto for this, since we only need the id
        void DeleteItem(Guid id); // returns nothing, just needs the Guid id of the item that needs to be deleted

    }
}