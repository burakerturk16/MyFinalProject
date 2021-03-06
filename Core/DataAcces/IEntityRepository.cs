﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAcces
{
    //core katmanı diğer katmanları referans almamalı evrensellik kalıcı tutulmalı
    // generic constraint
    //class : referans tip 
    //IEntity : IEntity veya Entity implemente eden bir nesne olabilir
    //new() : new'lenebilir olmalı
    public interface IEntityRepository<T>
        where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter =null); // filter null dersek tüm datayı istediğimizi kastederiz
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
} 
