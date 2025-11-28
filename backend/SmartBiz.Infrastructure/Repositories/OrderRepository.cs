using SmartBiz.Core.Entities;
using Microsoft.EntityFrameworkCore;
using SmartBiz.Core.Interfaces;
using SmartBiz.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartBiz.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SmartBizDbContext _context;

        public OrderRepository(SmartBizDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
