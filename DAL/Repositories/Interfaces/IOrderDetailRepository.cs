using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetail> GetByIdAsync(int id);
        Task<IEnumerable<OrderDetail>> GetAllAsync();
        Task AddAsync(OrderDetail orderDetail);
        Task UpdateAsync(OrderDetail orderDetail);
        Task DeleteAsync(int id);
    }
}

