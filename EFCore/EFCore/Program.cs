using EFCore.DBContext;
using EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entity Framework Example");
            ReadProduct();

            // InsertProducts();
            //InsertMultiple();


            //UpdateProduct();

        
              DeleteProduct();
           

            ReadProduct();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }


        static void InsertProducts()
        {
            using(var db=new EFContext())
            {
                Product ps = new Product();
                 ps.Name = "Pen Drive";
                db.Add(ps);
              

                db.SaveChanges();


            }
        }

        static void InsertMultiple()
        {
            using(var db = new EFContext())
            {
               List< Product>  ps = new List<Product>();

                ps.Add(new Product { Name = "Key Board" });
                ps.Add(new Product { Name = "Mouse" });
                ps.Add(new Product { Name = "Camera" });

                db.Products.AddRange(ps);

                db.SaveChanges();
            }
        }

        static void ReadProduct()
        {
            using(var db=new EFContext())
            {
                List<Product> prdList = db.Products.ToList();

                foreach(Product p in prdList)
                {
                    Console.WriteLine("ID : {0} | Name: {1}", p.Id, p.Name);
                }

            }
        }

        static void UpdateProduct()
        {
            using(var db=new EFContext())
            {
                Product prd = db.Products.Find(1);

                prd.Name = "USB Drive";

                db.SaveChanges();
            }
        }

        static void DeleteProduct()
        {
            using(var db=new EFContext())
            {
                Product prd = db.Products.Find(1);

                if (prd is not null)
                {
                    db.Products.Remove(prd);
                    db.SaveChanges();
                }

                
            }
        }
    }
}
