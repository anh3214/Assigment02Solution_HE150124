using AutoMapper;
using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class ProductService
    {
        private readonly IRepositoryProduct _repositoryProduct;
        private IMapper _mapper;

        public ProductService
            (
            IRepositoryProduct repositoryProduct,
            IMapper mapper
            )
        {
            _repositoryProduct = repositoryProduct;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> GetPagingList()
        {
            try
            {
                var products = await _repositoryProduct.GetList();
                return _mapper.Map<List<ProductDto>>(products);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<bool> AddProduct(ProductAddDto product)
        {
            try
            {
                var productAdd = _mapper.Map<Product>(product);
                var addd = await _repositoryProduct.Add(productAdd);
                return addd;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
