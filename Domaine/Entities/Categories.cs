using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Entities
{
    public class Categories
    {
        [Key]
        public int categoryId { get; set; }
        public string name { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
