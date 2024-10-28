using Microsoft.AspNetCore.Mvc;
using WebOrder.Application.BaseResponse;
using WebOrder.Application.Contacts;
using WebOrder.Application.Implementations;
using WebOrder.Application.Interfaces;

namespace WebOrder.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("get-orders-after-date")]
        public async Task<ActionResult<List<OrderDto>>> GetOrdersAfterDateForArea([FromQuery] int area,  [FromQuery] DateTime? date)
        {           
            var result = await _orderService.GetOrdersForAreaAfterDateAsync(area, date);            

            return result.StatusCode == WebOrder.Domain.Enum.StatusCode.OK ? Ok(result.Data) : BadRequest(result);
        }
    }
}
