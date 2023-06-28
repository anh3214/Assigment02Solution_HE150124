﻿using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class ProductRepository : IRepositoryProduct
    {
        private readonly EStoreAPContext _context;
        public ProductRepository(EStoreAPContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(Guid id)
        {
            var product = await _context.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
            var orderDetail = await _context.OrderDetails.Where(x => x.ProductId == id).FirstOrDefaultAsync();
            if(product != null && orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                _context.Products.Remove(product);
                return true;
            }
            return false;
        }

        public async Task<Product> GetById(Guid id)
        {
            var product = await _context.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
            if(product != null)
            {
                return product;
            }
            return null;
        }

        public async Task<IEnumerable<Product>> GetList()
        {
            var product = await _context.Products.ToListAsync();
            if(product.Count > 0)
            {
                return product;
            }
            return new List<Product>();
        }

        public async Task<bool> Update(Product newValue)
        {
            _context.Products.Update(newValue);
            bool result = await _context.SaveChangesAsync() > 0;
            return await Task.FromResult(result);
        }
    }
}
