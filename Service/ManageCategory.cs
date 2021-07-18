using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domaine.Entities;

namespace Service
{
    class ManageCategory
    {
        private List<Categories> categories;
        public ManageCategory(List<Categories> categories)
        {
            this.categories = categories;
        }
    }
}
