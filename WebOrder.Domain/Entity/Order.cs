using System;

namespace WebOrder.Domain.Entity;

public class Order
{
    public int Id { get; set; }
    public float Weight { get; set; }
    public int Area { get; set; }
    public DateTime DeliveryTime { get; set; }
}
