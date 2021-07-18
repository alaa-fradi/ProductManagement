using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;

namespace Service
{
    public class EntityService<T>:IEntityService<T> where T:class
    {
        private UnitOfWork uow;
        public EntityService()
        {
            uow = new UnitOfWork() ;
        }

        public UnitOfWork _unitOfWork { get { return uow; } }
        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            uow.GetRepository<T>().Add(entity);
            uow.Commit();
        }
        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            uow.GetRepository<T>().Delete(entity);
            uow.Commit();
        }
        public virtual IEnumerable<T> GetAll()
        {
            return uow.GetRepository<T>().GetAll();
        }
        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            uow.GetRepository<T>().Update(entity);
            uow.Commit();

        }
        public virtual T GetById(int Id)
        {
            return uow.GetRepository<T>().GetById(Id);
        }

    }
}
