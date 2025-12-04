using Microsoft.EntityFrameworkCore;
using SmartBiz.Core.Entities;
using SmartBiz.Core.Interfaces;
using SmartBiz.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartBiz.Infrastructure.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly SmartBizDbContext _context;

        public InventoryRepository(SmartBizDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            return await _context.Inventory
                .Include(i => i.Product)
                .ToListAsync();
        }

        public async Task<Inventory?> GetByIdAsync(int id)
        {
            return await _context.Inventory
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Inventory?> GetByProductIdAsync(Guid productId)
        {
            return await _context.Inventory
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.ProductId == productId);
        }

        public async Task AddAsync(Inventory inv)
        {
            _context.Inventory.Add(inv);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Inventory inv)
        {
            _context.Inventory.Update(inv);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var inv = await _context.Inventory.FindAsync(id);
            if (inv != null)
            {
                _context.Inventory.Remove(inv);
                await _context.SaveChangesAsync();
            }
        }

        // Adjust stock (+ or -)
        public async Task<bool> AdjustStockAsync(Guid productId, int quantityChange)
        {
            var inventory = await GetByProductIdAsync(productId);

            if (inventory == null)
                return false;

            inventory.Quantity += quantityChange;

            if (inventory.Quantity < 0)
                return false; // no negative stock

            _context.Inventory.Update(inventory);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
