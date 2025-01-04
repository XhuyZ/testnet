using BLL.Interfaces;
using BLL.DTOs;
using DAL.Entities;
using DAL.Repositories.Interfaces;
namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount
            };
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            var orderDTOs = new List<OrderDto>();
            foreach (var order in orders)
            {
                orderDTOs.Add(new OrderDto
                {
                    Id = order.Id,
                    UserId = order.UserId,
                    OrderDate = order.OrderDate,
                    TotalAmount = order.TotalAmount
                });
            }
            return orderDTOs;
        }

        public async Task AddOrderAsync(OrderDto orderDTO)
        {
            var order = new Order
            {
                UserId = orderDTO.UserId,
                OrderDate = orderDTO.OrderDate,
                TotalAmount = orderDTO.TotalAmount
            };
            await _orderRepository.AddAsync(order);
        }

        public async Task UpdateOrderAsync(OrderDto orderDTO)
        {
            var order = await _orderRepository.GetByIdAsync(orderDTO.Id);
            if (order != null)
            {
                order.UserId = orderDTO.UserId;
                order.OrderDate = orderDTO.OrderDate;
                order.TotalAmount = orderDTO.TotalAmount;
                await _orderRepository.UpdateAsync(order);
            }
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}

