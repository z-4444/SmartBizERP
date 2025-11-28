using SmartBiz.Core.Entities;
using SmartBiz.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartBiz.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Product>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Product?> GetByIdAsync(Guid id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Product p) => _repo.AddAsync(p);
        public Task UpdateAsync(Product p) => _repo.UpdateAsync(p);
        public Task DeleteAsync(Guid id) => _repo.DeleteAsync(id);
    }
}
