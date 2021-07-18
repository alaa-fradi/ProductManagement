using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data.CustomConvention
{
    public class DataTime2Convention: Convention
    {
        public DataTime2Convention()
        {
            this.Properties<DateTime>()
                .Configure(c => c.HasColumnType("DateTime2"));
        }
    }
}
