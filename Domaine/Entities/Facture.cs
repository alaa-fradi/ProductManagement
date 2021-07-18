using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domaine.Entities
{
    public class Facture
    {
        [DataType(DataType.Date)]
        [Key,Column(Order =0)]
        public DateTime DateAchat { get; set; }
        public float Prix { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
