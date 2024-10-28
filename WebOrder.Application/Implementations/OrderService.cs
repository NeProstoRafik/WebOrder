
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebOrder.Application.BaseResponse;
using WebOrder.Application.Contacts;
using WebOrder.Application.Interfaces;
using WebOrder.DataAccess.Interfaces;
using WebOrder.Domain.Entity;
using static System.Net.Mime.MediaTypeNames;
using Serilog;
namespace WebOrder.Application.Implementations;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly Serilog.ILogger _logger;
    public OrderService(IOrderRepository orderRepository, Serilog.ILogger logger)
    {
        _orderRepository = orderRepository;
        _logger = logger;
    }

    public async Task<Response<List<OrderDto>>> GetOrdersForAreaAfterDateAsync(int? area, DateTime? date)
    {
        var baseResponse = new Response<List<OrderDto>>();
        if (area==null || date==null)
        {
            _logger.Warning("Район или дата не может быть пустым");
            baseResponse.Errors = "Район или дата не может быть пустым.";
            baseResponse.StatusCode =Domain.Enum.StatusCode.NullParametrs;
            return baseResponse;
        }

        var listOrders = new List<OrderDto>();

        var list = await _orderRepository.GetOrdersForAreaAfterDateAsync(area, date);

        if (list==null || list.Count==0)
        {
            _logger.Warning("отчет не найден");
            baseResponse.Errors = "Нет заказов для указанного района или даты.";
            baseResponse.StatusCode = Domain.Enum.StatusCode.NotFoundOrders;
            return baseResponse;
        }
        foreach (var order in list)
        {
            _logger.Information($"Номер отчета {order.Id} и время доставки {order.DeliveryTime}");
            var application = OrderDtoConverter(order);
            listOrders.Add(application);
        }

        baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
        baseResponse.Data = listOrders;

        return baseResponse;
    }

    private OrderDto OrderDtoConverter(Order order)
    {
        return new OrderDto()
        {
            Area = order.Area,
            Id = order.Id,
            DeliveryTime = order.DeliveryTime,
            Weight = order.Weight,
        };
    }
}
