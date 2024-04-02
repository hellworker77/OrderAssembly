using Domain.Entities;
using Domain.Entities.LinkedEntity;

namespace Persistence.SeedData;

public static class FakeData
{
    public static readonly List<Order> Orders = new()
    {
        new Order()
        {
            Id = 10
        },
        new Order()
        {
            Id = 11
        },
        new Order()
        {
            Id = 14
        },
        new Order()
        {
            Id = 15
        }
    };

    public static readonly List<Shelf> Shelves = new()
    {
        new Shelf()
        {
            Id = 1,
            Name = "А"
        },
        new Shelf()
        {
            Id = 2,
            Name = "Б"
        },
        new Shelf()
        {
            Id = 3,
            Name = "Ж"
        },
        new Shelf()
        {
            Id = 4,
            Name = "З"
        },
        new Shelf()
        {
            Id = 5,
            Name = "В"
        }
    };

    public static readonly List<Product> Products = new()
    {
        new Product()
        {
            Id = 1,
            Name = "Ноутбук"
        },
        new Product()
        {
            Id = 2,
            Name = "Телевизор"
        },
        new Product()
        {
            Id = 3,
            Name = "Телефон"
        },
        new Product()
        {
            Id = 4,
            Name = "Системный блок"
        },
        new Product()
        {
            Id = 5,
            Name = "Часы"
        },
        new Product()
        {
            Id = 6,
            Name = "Микрофон "
        },
    };

    public static readonly List<ProductShelf> ProductShelves = new()
    {
        new ProductShelf()
        {
            Id = 1,
            ShelfId = 1,
            ProductId = 1,
            IsPriority = true
        },
        new ProductShelf()
        {
            Id = 2,
            ShelfId = 1,
            ProductId = 2,
            IsPriority = true
        },
        new ProductShelf()
        {
            Id = 3,
            ShelfId = 2,
            ProductId = 3,
            IsPriority = true
        },
        new ProductShelf()
        {
            Id = 4,
            ShelfId = 4,
            ProductId = 3,
            IsPriority = false
        },
        new ProductShelf()
        {
            Id = 5,
            ShelfId = 5,
            ProductId = 3,
            IsPriority = false
        },
        new ProductShelf()
        {
            Id = 6,
            ShelfId = 3,
            ProductId = 4,
            IsPriority = true
        },
        new ProductShelf()
        {
            Id = 7,
            ShelfId = 3,
            ProductId = 5,
            IsPriority = true
        },
        new ProductShelf()
        {
            Id = 8,
            ShelfId = 1,
            ProductId = 5,
            IsPriority = true
        },
        new ProductShelf()
        {
            Id = 9,
            ShelfId = 3,
            ProductId = 6,
            IsPriority = false
        }
    };

    public static readonly List<OrderProductShelf> OrderProductShelves = new()
    {
        new()
        {
            OrderId = 10,
            ProductId = 1,
            Count = 2
        },
        new()
        {
            OrderId = 10,
            ProductId = 3,
            Count = 1
        },
        new()
        {
            OrderId = 10,
            ProductId = 4,
            Count = 1
        },
        new()
        {
            OrderId = 10,
            ProductId = 5,
            Count = 1
        },
        new()
        {
            OrderId = 10,
            ProductId = 9,
            Count = 1
        },
        new()
        {
            OrderId = 11,
            ProductId = 2,
            Count = 3
        },
        new ()
        {
            OrderId = 14,
            ProductId = 1,
            Count = 3
        },
        new ()
        {
            OrderId = 14,
            ProductId = 6,
            Count = 4
        },
        new ()
        {
            OrderId = 15,
            ProductId = 7,
            Count = 1
        },
        new ()
        {
            OrderId = 15,
            ProductId = 8,
            Count = 1
        }
    };
}