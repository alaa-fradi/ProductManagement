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
    public class ServiceFacture:EntityService<Facture>
    {
        public ServiceFacture(): base()
        {

        }

        public Facture GetFactureById(int IdProduct, int IdClient, DateTime DateAchat)
        {
            return this._unitOfWork.GetRepository<Facture>().GetAll().Where(f => f.ProductId == IdProduct && f.ClientId == IdClient && f.DateAchat == DateAchat).FirstOrDefault();
        }
    }
}
