using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebOrder.Application.Contacts;
using WebOrder.Application.BaseResponse;

namespace WebOrder.Application.Interfaces;

public interface IOrderService
{
    Task<Response<List<OrderDto>>> GetOrdersForAreaAfterDateAsync(int? area, DateTime? date);
}
