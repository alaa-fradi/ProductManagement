using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private GestionProduitsContext _dataContext;
        IDatabaseFactory databaseFactory;

        public UnitOfWork()
        {
           this.databaseFactory = new DatabaseFactory();
        }

        public GestionProduitsContext DataContext
        {
            get { return _dataContext = databaseFactory.DataContext; }
        }
        public void Commit()
        {
            DataContext.SaveChanges();
        }
        public void Dispose()
        {
            DataContext.Dispose();
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            IRepository<T> repo = new RepositoryBase<T>(databaseFactory);
            return repo;

        }



    }
}
