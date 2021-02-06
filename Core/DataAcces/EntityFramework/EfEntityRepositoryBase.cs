using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAcces.EntityFramework
{
  public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity: class , IEntity , new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var addedEntity = context.Entry(entity);  //veri kaynağı ile veri kaynağı ile classı ilişkilendir
                addedEntity.State = EntityState.Added;   // ekleme durumu olarak set et
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var deletedEntity = context.Entry(entity);  //veri kaynağı ile veri kaynağı ile classı ilişkilendir
                deletedEntity.State = EntityState.Deleted;   // silme durumu olarak set et
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {

                var updatedEntity = context.Entry(entity);  //veri kaynağı ile veri kaynağı ile classı ilişkilendir
                updatedEntity.State = EntityState.Modified;   // güncelleme durumu olarak set et
                context.SaveChanges();
            }
        }
        //standart gördüğün yerde generic base haline getir kod tekrarı yapma
        public TEntity Get(Expression<Func<TEntity, bool>> filter) // tek data getiren metot
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); // producta bağlan filtreden gelen değeri döndür context.Set<Product>() -> tablomuz
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList() // Db setteki product tablosuna yerleş veritabanındaki tabloyu listeye çevir ve returnle
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }
    }
}
