using BLL.DTOs;
namespace BLL.Interfaces
{
    public interface IOrderDetailService
    {
        Task<OrderDetailDto> GetOrderDetailByIdAsync(int id);
        Task<IEnumerable<OrderDetailDto>> GetAllOrderDetailsAsync();
        Task AddOrderDetailAsync(OrderDetailDto orderDetail);
        Task UpdateOrderDetailAsync(OrderDetailDto orderDetail);
        Task DeleteOrderDetailAsync(int id);
    }
}

