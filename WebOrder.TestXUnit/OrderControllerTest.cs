using Microsoft.AspNetCore.Mvc;
using Moq;
using WebOrder.Application.BaseResponse;
using WebOrder.Application.Contacts;
using WebOrder.Application.Interfaces;
using WebOrder.Controllers;
using WebOrder.Domain.Entity;
using WebOrder.Domain.Enum;
using Xunit;

namespace WebOrder.TestXUnit
{
    public class OrderControllerTest
    {
        private readonly OrderController _controller;
        private readonly Mock<IOrderService> _orderServiceMock;
        public OrderControllerTest()
        {
            _orderServiceMock = new Mock<IOrderService>();
            _controller = new OrderController(_orderServiceMock.Object);
        
        }

        [Fact]
        public async Task GetOrdersAfterDateForArea_ReturnsOkResult_WhenServiceReturnsData()
        {
            // Arrange
            var area = 1;
            var date = new DateTime(2024, 10, 25, 16, 20, 0);
            var expectedOrders = new List<OrderDto>
        {
             new OrderDto { Weight = 5.5f, Area = 1, DeliveryTime = new DateTime(2024, 10, 25, 16, 40, 00) },
            new OrderDto { Weight = 10.2f, Area = 1, DeliveryTime = new DateTime(2024, 10, 25, 16, 30, 00) },
        };

            _orderServiceMock
                .Setup(service => service.GetOrdersForAreaAfterDateAsync(area, date))
              .ReturnsAsync(new Response<List<OrderDto>>
              {
                  StatusCode = StatusCode.OK,
                  Data = expectedOrders
              });

            // Act
            var result = await _controller.GetOrdersAfterDateForArea(area, date);

            // Assert            
            Assert.Equal(2, expectedOrders.Count);
           
        }

        [Fact]
        public async Task GetOrdersAfterDateForArea_ReturnsBadRequest_WhenServiceReturnsError()
        {
            // Arrange
            var area = 1;
            var date = new DateTime(2025, 10, 25, 16, 20, 0);
            var errors = "Нет заказов для указанного района или даты.";

            _orderServiceMock
                .Setup(service => service.GetOrdersForAreaAfterDateAsync(area, date))
                  .ReturnsAsync(new Response<List<OrderDto>>
                  {
                      StatusCode = StatusCode.NotFoundOrders,
                      Errors = errors
                  });

            // Act
            var result = await _controller.GetOrdersAfterDateForArea(area, date);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsAssignableFrom<Response<List<OrderDto>>>(badRequestResult.Value);
      
            Assert.Equal(errors, response.Errors); // Проверка сообщений об ошибках

        }
    }
}
