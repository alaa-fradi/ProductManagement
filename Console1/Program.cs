using Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domaine.Entities;
using Service;
using Data;

namespace Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            // seance 3
            //Provider P1 = new Provider() { ConfirmPassword = "1234", password = "1234" };

            //Provider.SetIsApproved(P1.password, P1.ConfirmPassword, P1.IsApproved); // passage par valeur ==> fel affichage IsApproved matbadletech 
            //System.Console.WriteLine(" is approved : " + P1.IsApproved);
            //System.Console.ReadKey();

            //// passage par obj 
            //Provider.SetIsApproved(P1); // hedhi rbatnahech b obj like P1 cuz methode static 
            //System.Console.WriteLine(" is approved : " + P1.IsApproved);
            ////System.Console.WriteLine(" details : \n");
            ////P1.getDetails();
            //System.Console.ReadKey();
            //Console.ReadKey();

            // ******************************************************

            // seance 4 
            /*** Donnees d'initialisation **/
            //Categories
           Categories fruit = new Categories() { name = "Fruit" };
            // Categories Alimentaire = new Categories() { name = "Alimentaire" };

            // //Products
            // Product acide = new Chemical()
            // {
            //     DateProd = new DateTime(2000, 12, 12),
            //     Name = "ACIDE CITRIQUE",
            //     Description = "Monohydrate - E330 - USP32",
            //     categories = Alimentaire,
            //     Price = 90,
            //     Quantity = 30,
            //     City = "Sousse"
            // };
            // Product cacao = new Chemical()
            // {
            //     DateProd = new DateTime(2000, 12, 12),
            //     Name = "POUDRE DE CACAO NATURELLE",
            //     Description = "10% -12%",
            //     categories = Alimentaire,
            //     Price = 419,
            //     Quantity = 80,
            //     City = "Sfax"
            // };

            // Product dioxyde = new Chemical()
            // {
            //     DateProd = new DateTime(2000, 12, 12),
            //     Name = "DIOXYDE DE TITANE",
            //     Description = "TiO2 grade alimentaire, cosmétique et pharmaceutique.",
            //     categories = Alimentaire,
            //     Price = 200,
            //     Quantity = 50,
            //     City = "Tunis"
            // };
            // Product amidon = new Chemical()
            // {
            //     DateProd = new DateTime(2000, 12, 12),
            //     Name = "AMIDON DE MAÏS",
            //     Description = "Amidon de maïs natif",
            //     categories = Alimentaire,
            //     Price = 70,
            //     Quantity = 30,
            //     City = "Tunis"
            // };
            // Product blackberry = new Biological()
            // {
            //     DateProd = new DateTime(2000, 12, 12),
            //     Name = "Blackberry",
            //     Description = "",
            //     categories = fruit,
            //     Price = 60,
            //     ProductID = 0,
            //     Quantity = 0

            // };

            // Product apple = new Biological()
            // {
            //     DateProd = new DateTime(2000, 12, 12),
            //     Description = "",
            //     categories = fruit,
            //     Name = "Apple",
            //     Price = 100.00,
            //     ProductID = 0,
            //     Quantity = 100

            // };

            // Product avocado = new Biological()
            // {
            //     DateProd = new DateTime(2000, 12, 12),
            //     Description = "",
            //     categories = fruit,
            //     Name = "Avocado",
            //     Price = 100.00,
            //     ProductID = 0,
            //     Quantity = 100

            // };

            // List<Product> products = new List<Product>() { acide, cacao, dioxyde, amidon, blackberry, apple, avocado };
            // ManageProduct manageProduct = new ManageProduct(products);

            // Provider sater = new Provider() { Id = 1, UserName = "Medical Provider" };
            // Provider sudMedical = new Provider() { Id = 2, UserName = "Fruit-SA Provider" };
            // Provider palliserSa = new Provider() { Id = 3, UserName = "Fruit-CP  Provider" };
            // Provider prov4 = new Provider() { Id = 4, UserName = "Chemical Med-Provider" };
            // Provider prov5 = new Provider() { Id = 5, UserName = "Bio Provider" };
            // List<Provider> providers = new List<Provider>() { sater, sudMedical, palliserSa, prov4, prov5 };
            // ManageProvider manageProvider = new ManageProvider(providers);


            // // utilisation des fontion anonyme :
            // ManageProduct.FindProduct findproduct1 = delegate (string c)
            // {
            //     foreach (Product product1 in products)
            //     {
            //         if (product1.Name.ToUpper().StartsWith(c.ToUpper())) ;
            //             //product1.getDetails();
            //     }
            // };

            // // findproduct1("a");

            //// manageProduct.GetSchemical(50);       

            // manageProduct.GetProductPrice(50);

            //***************************************************************
            //seance 5 Data w kol 

            GestionProduitsContext context = new GestionProduitsContext();
            Product product1 = new Product() { Name = "tomate", Price = 5, Quantity = 3, DateProd = DateTime.Now, categories=fruit };
            context.Product.Add(product1);
            context.SaveChanges();


            System.Console.ReadKey();
        }

    }
}
