using ProductList.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductList.Infrastructure.IRepository
{
    public interface IProduct
    {
        Task<List<ProductModel>> GetAll();
        Task<ProductModel> GetDataById(int id);
        Task<Boolean> InsertProduct(ProductModel product);
        Task<Boolean> UpdateProduct(ProductModel product);
        Task<Boolean> DeleteRecord(int id);
    }
}
