using Business.Concrete;
using DataAccess.Concrete.EntitiyFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PrdouctManager productManager = new PrdouctManager(new EFProductDal());

          
            foreach (var product in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine("Ürün Adı: " + product.ProductName);
            }
            
            foreach (var product in productManager.GetByUnitPrice(50,100))
            {
                Console.WriteLine(product.UnitPrice);
            }
         
        }
    }
}
