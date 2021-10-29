using System;

namespace Catalog.Entitites
{
    // instead of public class Item, we use public record Item 
    public record Item {
        /*
            record types (like classes)
            - use for immutable objects (data models)
            - these are objects that cannot be changed after it has been created
            - with-expressions support
            - value-based equailty support
            - Ex. Item potion1 = new() {Name = "Potion", Price = 9};
                  Item potion2 = new() {Name = "Potion", Price = 9};
                  bool areEqual = potion1 == potion2; // true
                  Item potion3 = potion1 with {Price = 15};
                  areEqual = potion1 == potion3; // false
        */ 

        // init accessor
        // init-only properties
        // after the creation, we can no longer modify this property
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}