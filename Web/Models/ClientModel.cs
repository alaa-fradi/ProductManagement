using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domaine.Entities;

namespace Web.Models
{
    public class ClientModel
    {
        public int Cin { get; set; }
        public String Prenom { get; set; }
        public String Nom { get; set; }
        public String Email { get; set; }

        public virtual ICollection<Facture> Factures { get; set; }

        public String prixFactures;
        public ClientModel(Client client)
        {
            this.Cin = client.Cin;
            this.Prenom = client.Prenom;
            this.Nom = client.Nom;
            this.Email = client.Email;
            this.Factures = client.Factures;
        }
        

    }
}