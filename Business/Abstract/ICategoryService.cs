using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //dış dünyaya açmak istediğimiz işlemleri yapıyoruz
   public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int categoryId);
    }
}
