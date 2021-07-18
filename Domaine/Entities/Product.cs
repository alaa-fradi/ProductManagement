using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domaine.Entities
{
    public class Product 
    {
        [DataType(DataType.Date)]
        public DateTime DateProd { get; set; }

        [DataType(DataType.MultilineText)]
        public String Description { get; set; }

        [Required(ErrorMessage ="champ obligatoire")]
        [StringLength(25,ErrorMessage ="taille max = 25")]
        [MaxLength(50)]
        public String Name { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Display(Name="Date de production")]
        [DataType(DataType.Date)]
        public int ProductID { get; set; }

        public int? categoryId { get; set; }

        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }

        public string ImageName { get; set; }

        public virtual Categories categories { get; set; }

        public virtual ICollection<Provider> Provider { get; set; }

        public virtual ICollection<Facture> Factures { get; set; }



        //public override void getdetails()
        //{
        //    console.writeline("product id: " + productid + " + name: " + name + " + description "+description+" + quantity: "+quantity+" +price: "+price);
        //}
    }
}
