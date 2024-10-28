using Microsoft.EntityFrameworkCore;
using WebOrder.Domain.Entity;

namespace WebOrder.DataAccess;

public class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {

        context.Database.Migrate();


        if (context.Orders.Any())
        {
            return;
        }

        var orders = new List<Order>
        {
            new Order { Weight = 5.5f, Area = 1, DeliveryTime = new DateTime(2024, 10, 25, 16, 40, 00) },
            new Order { Weight = 10.2f, Area = 2, DeliveryTime = new DateTime(2024, 10, 25, 17, 30, 00) },
            new Order { Weight = 3.8f, Area = 1, DeliveryTime = new DateTime(2024, 10, 25, 18, 10, 00) },
            new Order { Weight = 7.0f, Area = 2, DeliveryTime = new DateTime(2024, 10, 25, 16, 50, 00) },
            new Order { Weight = 12.4f, Area = 3, DeliveryTime = new DateTime(2024, 10, 25, 16, 55, 00) },
            new Order { Weight = 3.8f, Area = 1, DeliveryTime = new DateTime(2024, 10, 26, 16, 30, 00) },
            new Order { Weight = 7.0f, Area = 3, DeliveryTime = new DateTime(2024, 10, 26, 19, 20, 00) },
            new Order { Weight = 12.4f, Area = 2, DeliveryTime = new DateTime(2024, 10, 25, 16, 20, 00) }
        };

        context.Orders.AddRange(orders);
        context.SaveChanges();
    }
}
