﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //bellek üzerinde yapıyoruz inmemory ile şu an ileride bu entitiy olabilir ado olabilir dapper olabilir vs.
    public class InMemoryProductDal : IProductDal
    {
        //global değişken bu class için
        List<Product> _products;
        public InMemoryProductDal()
        {   //Oracle, Sql Server , Postgres , MongoDB
            _products = new List<Product> {
                
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                 new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                  new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                   new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                    new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1}

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }
        //LINQ - Language Integrated Query
        //remove methodu ile silemeyiz çünkü referans yollarız o referansla aynı adrese sahip değil
        //ama listemiz bir string int vs. deger tipi olsaydı silinirdi
        public void Delete(Product product)
        {
            // First FirstOrDefault da olabilirdi
            //ID bazlı işlemlerde SingleOrDefault kullanırız iki değer gelirse hata verir
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public void Update(Product product)
        {
            //Gonderilen urun id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            product.UnitPrice = product.UnitPrice;
            product.UnitsInStock = product.UnitsInStock;

        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();

        }
        //veritabanından listeyi çekeriz
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

     

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

      

       
    }
}