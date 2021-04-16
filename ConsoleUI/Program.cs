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
            //ProductTest();
            //CategoryTest();
             
        }

        /*private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {

            PrdouctManager productManager = new PrdouctManager(new EFProductDal());
            var result = productManager.GetProductDetails();
            if(result.Success==true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine("ProductName: " + product.ProductName + " - CategoryName: " + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
      
      
        }
           */

    }
}
