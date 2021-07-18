using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
namespace Domaine.Entities
{
   // [ComplexType]
    public class Adresse 
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
    }
}
