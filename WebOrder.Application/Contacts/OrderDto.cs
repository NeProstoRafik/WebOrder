using System;

namespace WebOrder.Application.Contacts;
public class OrderDto
{
    public int Id { get; set; }
    public float Weight { get; set; }
    public int Area { get; set; }
    public DateTime DeliveryTime { get; set; }
}
