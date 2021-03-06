using DBBenchmark.DbAction;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBenchmark.DbBenchmark
{
    internal class DapperBenchmark : ADbBenchmark
    {
        public DapperBenchmark(SqlConnection connection)
        {
            this.ConnectionObject = connection;
            DbAction = new DapperAction();
        }
        public DapperBenchmark(string connection) : this(new SqlConnection(connection)) { }
    }
}
