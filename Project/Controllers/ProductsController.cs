using Microsoft.AspNetCore.Mvc;
using Project.Data.Interfaces;
using Project.Models;
using Project.ViewModels;

namespace Project.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IAllProducts _allProducts;
        private readonly IProductCategory _allCategory;

        public ProductsController(IAllProducts iAllProducts, IProductCategory iProductCategory)
        {
            _allProducts = iAllProducts;
            _allCategory = iProductCategory;
        }

        public IActionResult List()
        {
            var products = _allProducts.Products;

            var model = new ProductsListViewModel
            {
                AllProducts = products,
                ProductCategory = "Products"
            };

            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }
        
        public IActionResult Edit(int id)
        {
            var product = _allProducts.GetProductById(id);
            if (product == null)
            {
                return NotFound(); // Вернуть страницу 404, если продукт не найден
            }
            return View(product);
        }
        
        //редактирование(не вышло,нужна бд)
        [HttpPost]
        public IActionResult Edit(Products product)
        {
            if (ModelState.IsValid)
            {
                _allProducts.UpdateProduct(product);
                return RedirectToAction("List");
            }
            return View(product); 
        }
        
        //метод добавления объектов
        [HttpPost]
        public IActionResult Add(Products product)
        {
            _allProducts.AddProduct(product);

            var products = _allProducts.Products;

            var model = new ProductsListViewModel
            {
                AllProducts = products,
                ProductCategory = "Products"
            };

            return View("List", model);
        }

        //метод для реализаци удаления объекта
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _allProducts.DeleteProduct(id);

            return RedirectToAction("List");
        }
       
        //метод для реализации фильтрации
        [HttpGet]
        public IActionResult FilterByCategory(string categoryName)
        {
            var filteredProducts = _allProducts.Products
                .Where(p => string.IsNullOrEmpty(categoryName) || p.CategoryName == categoryName);

            var model = new ProductsListViewModel
            {
                AllProducts = filteredProducts,
                ProductCategory = "Filtered Products"
            };

            return View("List", model);
        }


    }
}
