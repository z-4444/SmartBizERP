using SmartBiz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartBiz.Core.Interfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetAllAsync();
        Task<Inventory?> GetByProductIdAsync(Guid productId);
        Task<Inventory?> GetByIdAsync(int id);
        Task AddAsync(Inventory inv);
        Task UpdateAsync(Inventory inv);
        Task DeleteAsync(int id);

        Task<bool> AdjustStockAsync(Guid productId, int quantityChange);
    }
}
