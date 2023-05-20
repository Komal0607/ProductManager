using Microsoft.AspNetCore.Mvc;
using ProductList.Infrastructure.IRepository;
using ProductList.Infrastructure.Repository;
using ProductList.Models;
using System;
using System.Threading.Tasks;

namespace ProductList.Controllers
{   

    public class ProductController : Controller
    {

        public readonly IProduct _product;
        public ProductController(IProduct product)
        {
            _product = product;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task <IActionResult> List()
        {
            var list = await _product.GetAll();
            return View(list);
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        public IActionResult GetDataById()
        {
            return View();
        }
        public async Task<IActionResult> EditProduct(int id)
        {
            var singleproduct = await _product.GetDataById(id);
            return View(singleproduct);
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var singleproduct = await _product.GetDataById(id);
            return View(singleproduct);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductModel model)
        {

            if (ModelState.IsValid) {
                var result = await _product.InsertProduct(model);
                if (result)
                {
                    return RedirectToAction("List");
                }
                return View(model);
            }
            return View(model);
            
        }
        [HttpPost]

        public async Task<IActionResult> DeleteProduct(ProductModel model)
        {
           
                var result = await _product.DeleteRecord(model.Id);
                if (result)
                {
                    return RedirectToAction("List");
                }
                return View(model);
            
            
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(int id,ProductModel model)
        {
                await _product.UpdateProduct(model);
                return RedirectToAction("List");
            
            
        }
    }
}
