using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Data.Repositories;
using Domaine.Entities;

namespace Service
{
    public class ServiceProduct: EntityService<Product>
    {
        public ServiceProduct() : base()
        {

        }
        public IEnumerable<Product> GetProductByName(string Name)
        {
            
            return this._unitOfWork.GetRepository<Product>().GetAll().Where(f => f.Name.ToLower().Contains(Name.ToLower()));

        }
    }
}
