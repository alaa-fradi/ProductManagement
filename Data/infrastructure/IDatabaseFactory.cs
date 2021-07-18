using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Runtime.Remoting.Contexts;

namespace Data.Infrastructure
{
   public interface IDatabaseFactory : IDisposable
    {
        // instancié l'objet Context
        GestionProduitsContext DataContext { get; }
        GestionProduitsContext Get();

    }

}
