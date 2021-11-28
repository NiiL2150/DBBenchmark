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
        //Task<TimeSpan> AddMany();
        Task<TimeSpan> GetFirstIdAsync(int id);
        //Task<TimeSpan> GetMany();
        Task<TimeSpan> GetFirstStringAsync(string searchString);
        //Task<TimeSpan> GetAllString(string searchString);
        Task<TimeSpan> UpdateOneAsync(int id, int newFirst);
        //Task<TimeSpan> UpdateAll(int newFirst);
        Task<TimeSpan> DeleteOneAsync(int id);
        //Task<TimeSpan> DeleteAllAsync();
    }
}
