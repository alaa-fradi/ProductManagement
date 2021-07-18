using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domaine.Entities
{
    public class Provider 
    {
        public string ConfirmPassword { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public bool IsApproved { get; set; }

        private string Password;
        public string password { 
            get { return Password; } 
            set {
                if ((value.Length >= 5) && (value.Length <= 20))
                {
                    Password = value; 
                }
                else
                {
                    Console.WriteLine("password taille doit etre entre 5 et 20 ");
                }
            } 
        }
        public string UserName { get; set; }
        public virtual ICollection<Product> Product { get; set; }

        //public override void getDetails()
        //{
        //    Console.WriteLine("Email: " + Email + " + UserName: " + UserName + " + ID " + Id + " + ISapproved: " + IsApproved + " +DAteCreated: " + DateCreated);
        //}

        public static void SetIsApproved(Provider P) // passage par obbj so el IsApproved tetbadel 
        {
            P.IsApproved = String.Compare(P.Password, P.ConfirmPassword) == 0;
        }

        public static void SetIsApproved(string Password , string ConfirmPassword, bool IsApproved) // passage par valeur so IsApproved tetbadalech
        {
            IsApproved = String.Compare(Password, ConfirmPassword) == 0;
        }


    }
}
