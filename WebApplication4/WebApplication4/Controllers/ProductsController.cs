using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Helpers;

namespace WebApplication4.Models
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;

        private IHelper _helper;

        private readonly ProductRepository _productRepository;

        public ProductsController(AppDbContext context, IHelper helper)
        {
            _productRepository = new ProductRepository();
            _helper = helper;
            _context = context;


            //if (!_context.Products.Any())
            //{
            //    _context.Products.Add(new Product() { Name = "kalem1", Price = 200, Stock = 100 });
            //    _context.Products.Add(new Product() { Name = "kalem2", Price = 200, Stock = 200 });
            //    _context.Products.Add(new Product() { Name = "kalem3", Price = 200, Stock = 300 });

            //    _context.SaveChanges();
            //}
        }

        public IActionResult Index()
        {

            var text = "Asp.Net";

            var upperText = _helper.Upper(text);

            var products = _context.Products.ToList();

            return View(products);
        }




        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);

            _context.Products.Remove(product);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public IActionResult Add()//bu gizli bir [HttpGet]'tir. 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string NAME,IFormCollection col)
        {

            //var name = NAME;
            var price = decimal.Parse(col["Price"].ToString());//decimal
            var stock = int.Parse(col["Stock"].ToString());//int
            var color =col["Color"].ToString();


            Product newProduct = new Product() { Name = NAME, Price = price, Color = color, Stock = stock };

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            TempData["status"] = "Ürün başarıyla eklendi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);

            return View(product);
        }


        [HttpPost]
        public IActionResult Update(Product updateProduct)
        {

            _context.Products.Update(updateProduct);
            _context.SaveChanges();

            TempData["status"] = "Ürün başarıyla güncellendi.";
            return RedirectToAction("Index");
        }




    }
}
