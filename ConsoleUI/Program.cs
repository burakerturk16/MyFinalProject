using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        //IoC
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            EFProductDal eFProductDal = new EFProductDal();
            PrdouctManager productManager = new PrdouctManager(eFProductDal);
           
            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine("ProductName: " + product.ProductName + " - CategoryName: " + product.CategoryName);
            }
        }
    }
}
