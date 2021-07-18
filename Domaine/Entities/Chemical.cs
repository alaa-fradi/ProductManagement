using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Entities
{
    public class Chemical : Product
    {
        public string LabName { get; set; }

        public Adresse labadresse { get; set; }
    }
}
