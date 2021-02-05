using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EFProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
             
                var addedEntity = context.Entry(entity);  //veri kaynağı ile veri kaynağı ile classı ilişkilendir
                addedEntity.State = EntityState.Added;   // ekleme durumu olarak set et
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var deletedEntity = context.Entry(entity);  //veri kaynağı ile veri kaynağı ile classı ilişkilendir
                deletedEntity.State = EntityState.Deleted;   // silme durumu olarak set et
                context.SaveChanges();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                var updatedEntity = context.Entry(entity);  //veri kaynağı ile veri kaynağı ile classı ilişkilendir
                updatedEntity.State = EntityState.Modified;   // güncelleme durumu olarak set et
                context.SaveChanges();
            }
        }
        //standart gördüğün yerde generic base haline getir kod tekrarı yapma
        public Product Get(Expression<Func<Product, bool>> filter) // tek data getiren metot
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter); // producta bağlan filtreden gelen değeri döndür context.Set<Product>() -> tablomuz
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null
                    ? context.Set<Product>().ToList() // Db setteki product tablosuna yerleş veritabanındaki tabloyu listeye çevir ve returnle
                    : context.Set<Product>().Where(filter).ToList(); 
            }
        }

      
    }
}
