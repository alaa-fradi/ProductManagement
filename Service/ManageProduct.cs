using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domaine.Entities;

namespace Service
{
    public class ManageProduct
    {
        private List<Product> products;

        public delegate void FindProduct(string c); // fonction anonyme 
        public delegate void ScanProduct(Categories category); // fonction anonyme 
        // bech nesta3emlouhom fel console ( program.cs) 

        public ManageProduct( List<Product> products)
        {
            this.products = products; 
        }

        public void GetSchemical(double price)
        {
            var result =( from product in products
                         where (product.Price >= price)
                         select product).Take(5);

            foreach(Product product in result)
            {
             //   product.getDetails();
            }
        }

        public void GetProductPrice(double price)
        {
            var result = (from product in products
                          where (product.Price >= price)
                          select product).Skip(2);

            foreach (Product product in result)
            {
             //   product.getDetails();
            }

        }
    }
}
