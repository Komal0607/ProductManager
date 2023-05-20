using Dapper;
using Microsoft.VisualBasic;
using ProductList.Infrastructure.IRepository;
using ProductList.Models;
using ProductList.Models.dbContext;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductList.Infrastructure.Repository
{
    public class Product:IProduct
    {
        private readonly DapperContext _context;

        public Product(DapperContext context)
        {
            _context = context;
        }
        public async Task<List<ProductModel>> GetAll() {

            string sqlQuery = "SELECT * FROM PRODUCT ORDER BY CREATED_DATE DESC";
            using (var connection = _context.CreateConnection())
            {
                var users = await connection.QueryAsync<ProductModel>(sqlQuery);
                return users.ToList();
            }
            
        
        }
        public async Task<ProductModel> GetDataById(int id)
        {

            string sqlQuery = "SELECT  * FROM PRODUCT WHERE Product_Id= @Id";
            
            using (var connection = _context.CreateConnection())
            {
                var databyid = await connection.QuerySingleOrDefaultAsync<ProductModel>(sqlQuery, new { id });
                return databyid;
            }


        }
        public async Task<Boolean> InsertProduct(ProductModel product)
        {
            string insertQuery = "INSERT INTO PRODUCT VALUES(@productName,@productPrice,GETDATE())";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("productName", product.Product_Name, DbType.String);
            parameters.Add("productPrice", product.Product_Price, DbType.Decimal);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(insertQuery, parameters);
                return true;
            }
            
        }
        public async Task<Boolean> UpdateProduct(ProductModel product)
        {
            string insertQuery = "UPDATE PRODUCT SET Product_Name =@productName, Product_Price=@productPrice WHERE Product_Id = @Id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("productName", product.Product_Name, DbType.String);
            parameters.Add("productPrice", product.Product_Price, DbType.Decimal);
            parameters.Add("productName", product.Product_Name, DbType.String);
            parameters.Add("Id", product.Id, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(insertQuery, parameters);
                return true;
            }

        }
        public async Task<Boolean> DeleteRecord(int id)
        {

            string deleteQuery = "DELETE FROM PRODUCT WHERE Product_Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(deleteQuery, new { id });
                return true;
            }
        }

    }

}
