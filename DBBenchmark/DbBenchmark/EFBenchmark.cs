using DBBenchmark.DbAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBenchmark.DbBenchmark
{
    internal class EFBenchmark : ADbBenchmark
    {
        public EFBenchmark(RandomDBContext context)
        {
            this.ConnectionObject = context;
            DbAction = new EFAction();
        }
    }
}
