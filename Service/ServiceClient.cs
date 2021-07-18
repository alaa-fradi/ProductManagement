using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domaine.Entities;

namespace Service
{
    public class ServiceClient : EntityService<Client>
    {
        public ServiceClient() : base()
        {

        }

        public Client GetProviderById(int id)
        {
            return this._unitOfWork.GetRepository<Client>().GetAll().Where(f => (f.Cin == id)).FirstOrDefault();
        }

        public float GetTotalPrice(int clientId)
        {
            float totalPrice = 0;

            Client c = this.GetAll().Where( c => c.Cin == clientId).FirstOrDefault();
            var listFacture = c.Factures;

            foreach(Facture f in listFacture)
            {
                totalPrice += f.Prix;
            }
            //Client.facture

            return totalPrice;
        }
    }
}
