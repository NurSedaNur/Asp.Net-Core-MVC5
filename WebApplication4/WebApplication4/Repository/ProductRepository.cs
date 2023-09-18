﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {

            new() { Id = 1, Name = "Kalem1", Price = 100, Stock = 200 },
            new() { Id = 2, Name = "Kalem2", Price = 200, Stock = 300 },
            new() { Id = 3, Name = "Kalem3", Price = 300, Stock = 400 }
        };


        //ALTINDAKİ SATIRLA AYNI
        //public List<Product> Products()
        //{
        //    return _products;
        //}
        public List<Product> GetAll() => _products;

        public void Add(Product newProduct) => _products.Add(newProduct);

        public void Remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == id);

            if (hasProduct == null)
            {
                throw new Exception($"Bu id {id}'ye sahip urun bulunamamaktadır.");
            }
            _products.Remove(hasProduct);
            
        }

        public void Update(Product updateProduct)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == updateProduct.Id);

            if (hasProduct == null)
            {
                throw new Exception($"Bu id {updateProduct}'ye sahip urun bulunamamaktadır.");
            }

            hasProduct.Name = updateProduct.Name;
            hasProduct.Price = updateProduct.Price;
            hasProduct.Stock = updateProduct.Stock;

            var index = _products.FindIndex(x => x.Id == updateProduct.Id);
          
            _products[index] = hasProduct;



        }



    }
}
