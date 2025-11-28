using SmartBiz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartBiz.Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(Guid id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task AddAsync(Order order);
    }
}
