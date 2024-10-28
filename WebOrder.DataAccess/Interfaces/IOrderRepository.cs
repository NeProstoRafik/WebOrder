using System;
using System.Collections.Generic;
using WebOrder.Domain.Entity;

namespace WebOrder.DataAccess.Interfaces;

public interface IOrderRepository
{

    //Task CreateAsync(Order entity);
    //Task<Order?> GetAsync(Guid id);
    //Task Delete(Order entity);
    Task<List<Order>> GetOrdersForAreaAfterDateAsync(int? area, DateTime? date);     

}
