using System;
using System.Linq;

namespace _1QuickStartEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ctrate a DB Connections with using block
            using (var dbContext = new NorthwindSlimEntities())
            {
                //Lecture-1 or Day-1
                //Show all sql in console display
                //dbContext.Database.Log = Console.Write;
                //Get & Display products
                var products = from p in dbContext.Products
                               where p.CategoryId == 1
                               orderby p.ProductName ascending
                               select p;
                foreach (Product product in products)
                {
                    Console.WriteLine("ID-{0} Name-{1} Price-{2}", product.ProductId, product.ProductName, product.UnitPrice.GetValueOrDefault().ToString("C"));
                }

                //Update Product Price in Single Product
                Console.WriteLine("Do you want to update Price? \nPlease Enter your product Id below:");
                int id = Convert.ToInt32(Console.ReadLine());
                var chai = dbContext.Products.Single(a => a.ProductId == id);
                chai.UnitPrice++;
                dbContext.SaveChanges();
                //Dislay Update Price
                Console.WriteLine("ID-{0} Name-{1} Price-{2}", chai.ProductId, chai.ProductName, chai.UnitPrice.GetValueOrDefault().ToString("C"));




                //Create a New Products
                Console.WriteLine("Create a New Products");
                var chocolato = new Product()
                {
                    ProductName = "Orio",
                    CategoryId = 1,
                    UnitPrice = 15,
                };
                dbContext.Products.Add(chocolato);
                dbContext.SaveChanges();
                //Display New Product
                Console.WriteLine("ID-{0} Name-{1} Price-{2}", chocolato.ProductId, chocolato.ProductName, chocolato.UnitPrice.GetValueOrDefault().ToString("C"));




                //Delete a  Product
                Console.WriteLine("Enter your deleting product ID:");
                int deleteId = Convert.ToInt32(Console.ReadLine());
                var delete = dbContext.Products.Single(b => b.ProductId == deleteId);
                dbContext.Products.Remove(delete);
                dbContext.SaveChanges();
                //Display Deleting Product
                Console.WriteLine("ID-{0} Name-{1} Price-{2}", delete.ProductId, delete.ProductName, delete.UnitPrice.GetValueOrDefault().ToString("C"));








            }





            Console.ReadKey();
        }
    }
}
