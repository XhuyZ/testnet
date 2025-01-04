using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var orderDetail = await _orderDetailService.GetOrderDetailByIdAsync(id);
            if (orderDetail == null)
                return NotFound();

            return Ok(orderDetail);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetails()
        {
            var orderDetails = await _orderDetailService.GetAllOrderDetailsAsync();
            return Ok(orderDetails);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderDetail(OrderDetailDto orderDetailDto)
        {
            await _orderDetailService.AddOrderDetailAsync(orderDetailDto);
            return CreatedAtAction(nameof(GetOrderDetailById), new { id = orderDetailDto.Id }, orderDetailDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetail(int id, OrderDetailDto orderDetailDto)
        {
            if (id != orderDetailDto.Id)
                return BadRequest();

            await _orderDetailService.UpdateOrderDetailAsync(orderDetailDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await _orderDetailService.DeleteOrderDetailAsync(id);
            return NoContent();
        }
    }
}

