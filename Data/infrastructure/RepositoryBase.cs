﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Data.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private GestionProduitsContext dataContext;
        private IDbSet<T> dbset;
        IDatabaseFactory databaseFactory;

        //Constructeur
        public RepositoryBase(IDatabaseFactory dbFactory)
        {
            this.databaseFactory = dbFactory;
            dbset = DataContext.Set<T>();
        }

        public GestionProduitsContext DataContext
        {
            get { return dataContext = databaseFactory.DataContext; }
        }

        //Attaché et préparé a être prés a ajouter
        public virtual void Add(T entity)
        {
            dbset.Add(entity);
            
        }
        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }
        public virtual T GetById(long id)
        {
            return dbset.Find(id);
        }
        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }

        public void Save()
        {
            dataContext.SaveChanges();
        }  
    }
}
