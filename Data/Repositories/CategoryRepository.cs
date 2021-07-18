using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domaine.Entities;

namespace Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Categories>
    {
        private DatabaseFactory _db = new DatabaseFactory();
        public CategoryRepository(DatabaseFactory db) : base(db)
        {
            _db = db;
        }
    }
}
