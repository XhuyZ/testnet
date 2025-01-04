using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
namespace BLL.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<OrderDetailDto> GetOrderDetailByIdAsync(int id)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(id);
            return new OrderDetailDto
            {
                Id = orderDetail.Id,
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                Quantity = orderDetail.Quantity,
                Price = orderDetail.Price
            };
        }

        public async Task<IEnumerable<OrderDetailDto>> GetAllOrderDetailsAsync()
        {
            var orderDetails = await _orderDetailRepository.GetAllAsync();
            var orderDetailDTOs = new List<OrderDetailDto>();
            foreach (var orderDetail in orderDetails)
            {
                orderDetailDTOs.Add(new OrderDetailDto
                {
                    Id = orderDetail.Id,
                    OrderId = orderDetail.OrderId,
                    ProductId = orderDetail.ProductId,
                    Quantity = orderDetail.Quantity,
                    Price = orderDetail.Price
                });
            }
            return orderDetailDTOs;
        }

        public async Task AddOrderDetailAsync(OrderDetailDto orderDetailDTO)
        {
            var orderDetail = new OrderDetail
            {
                OrderId = orderDetailDTO.OrderId,
                ProductId = orderDetailDTO.ProductId,
                Quantity = orderDetailDTO.Quantity,
                Price = orderDetailDTO.Price
            };
            await _orderDetailRepository.AddAsync(orderDetail);
        }

        public async Task UpdateOrderDetailAsync(OrderDetailDto orderDetailDTO)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(orderDetailDTO.Id);
            if (orderDetail != null)
            {
                orderDetail.OrderId = orderDetailDTO.OrderId;
                orderDetail.ProductId = orderDetailDTO.ProductId;
                orderDetail.Quantity =

