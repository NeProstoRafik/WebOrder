using Microsoft.EntityFrameworkCore;
using WebOrder.DataAccess.Interfaces;
using WebOrder.Domain.Entity;

namespace WebOrder.DataAccess.Repositories;

public class OrderRepository : IOrderRepository
{

    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Order>?> GetOrdersForAreaAfterDateAsync(int? area, DateTime? date)
    {   
        var listAllDate = await _context.Orders.Where(a => a.Area == area)
                               .Where(o => o.DeliveryTime >= date && o.DeliveryTime <= date.Value.AddMinutes(30))
                               .OrderBy(t => t.DeliveryTime)
                               .ToListAsync();

        return listAllDate;
    }
    
}
