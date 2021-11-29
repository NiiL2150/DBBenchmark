using DBBenchmark.DbAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBenchmark.DbBenchmark
{
    internal interface IDbBenchmark
    {
        public IDbAction DbAction { get; set; }

        Task<TimeSpan> AddOneAsync();
        Task<TimeSpan> AddManyAsync();
        Task<TimeSpan> GetFirstIdAsync(int id);
        Task<TimeSpan> GetManyAsync();
        Task<TimeSpan> GetFirstStringAsync(string searchString);
        Task<TimeSpan> GetAllStringAsync(string searchString);
        Task<TimeSpan> UpdateOneAsync(int id, int newFirst);
        Task<TimeSpan> UpdateAllAsync(int newFirst);
        Task<TimeSpan> DeleteOneAsync(int id);
        Task<TimeSpan> DeleteAllAsync();
    }
}
