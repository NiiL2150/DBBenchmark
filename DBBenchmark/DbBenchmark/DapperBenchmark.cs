using DBBenchmark.DbAction;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBenchmark.DbBenchmark
{
    internal class DapperBenchmark : IDbBenchmark
    {
        public IDbAction DbAction { get; set; }
        string connStr;

        public DapperBenchmark(string connection)
        {
            this.connStr = connection;
            DbAction = new DapperAction();
        }

        public async Task<TimeSpan> AddOneAsync()
        {
            DateTime start = DateTime.Now;
            await DbAction.AddRandomValueAsync(connStr);
            DateTime end = DateTime.Now;
            return end - start;
        }

        public async Task<TimeSpan> DeleteOneAsync(int id)
        {
            DateTime start = DateTime.Now;
            await DbAction.DeleteRandomValueAsync(connStr, id);
            DateTime end = DateTime.Now;
            return end - start;
        }

        public async Task<TimeSpan> GetFirstIdAsync(int id)
        {
            DateTime start = DateTime.Now;
            await DbAction.GetRandomValueAsync(connStr, id);
            DateTime end = DateTime.Now;
            return end - start;
        }

        public async Task<TimeSpan> GetFirstStringAsync(string searchString)
        {
            DateTime start = DateTime.Now;
            await DbAction.SearchByStringAsync(connStr, searchString);
            DateTime end = DateTime.Now;
            return end - start;
        }

        public async Task<TimeSpan> UpdateOneAsync(int id, int newFirst)
        {
            DateTime start = DateTime.Now;
            await DbAction.UpdateRandomValueAsync(connStr, id, newFirst);
            DateTime end = DateTime.Now;
            return end - start;
        }
    }
}
