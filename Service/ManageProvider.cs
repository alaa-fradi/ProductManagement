using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domaine.Entities;

namespace Service
{
    public class ManageProvider
    {
        private List<Provider> providers;
        public ManageProvider(List<Provider> providers)
        {
            this.providers = providers;
        }
    }
}
