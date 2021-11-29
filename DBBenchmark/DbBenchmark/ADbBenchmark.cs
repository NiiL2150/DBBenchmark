using DBBenchmark.DbAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBenchmark.DbBenchmark
{
    internal abstract class ADbBenchmark : IDbBenchmark
    {
        public IDbAction DbAction { get; set; }
        public Object ConnectionObject { get; set; }

        public virtual async Task<TimeSpan> AddOneAsync()
        {
            DateTime start = DateTime.Now;
            await DbAction.AddRandomValueAsync(ConnectionObject);
            DateTime end = DateTime.Now;
            return end - start;
        }

        public virtual async Task<TimeSpan> AddManyAsync()
        {
            DateTime start = DateTime.Now;
            await DbAction.AddRandomValuesAsync(ConnectionObject);
            DateTime end = DateTime.Now;
            return end - start;
        }

        public virtual async Task<TimeSpan> DeleteOneAsync(int id)
        {
            DateTime start = DateTime.Now;
            await DbAction.DeleteRandomValueAsync(ConnectionObject, id);
            DateTime end = DateTime.Now;
            return end - start;
        }

        public virtual async Task<TimeSpan> DeleteAllAsync()
        {
            DateTime start = DateTime.Now;
            await DbAction.DeleteAllRandomValuesAsync(ConnectionObject);
            DateTime end = DateTime.Now;
            return end - start;
        }

        public virtual async Task<TimeSpan> GetFirstIdAsync(int id)
        {
            DateTime start = DateTime.Now;
            await DbAction.GetRandomValueAsync(ConnectionObject, id);
            DateTime end = DateTime.Now;
            return end - start;
        }

        public virtual async Task<TimeSpan> GetManyAsync()
        {
            DateTime start = DateTime.Now;
            await DbAction.GetRandomValuesAsync(ConnectionObject);
            DateTime end = DateTime.Now;
            return end - start;
        }

        public virtual async Task<TimeSpan> GetFirstStringAsync(string searchString)
        {
            DateTime start = DateTime.Now;
            await DbAction.SearchByStringAsync(ConnectionObject, searchString);
            DateTime end = DateTime.Now;
            return end - start;
        }

        public virtual async Task<TimeSpan> GetAllStringAsync(string searchString)
        {
            DateTime start = DateTime.Now;
            await DbAction.SearchMultByStringAsync(ConnectionObject, searchString);
            DateTime end = DateTime.Now;
            return end - start;
        }

        public virtual async Task<TimeSpan> UpdateOneAsync(int id, int newFirst)
        {
            DateTime start = DateTime.Now;
            await DbAction.UpdateRandomValueAsync(ConnectionObject, id, newFirst);
            DateTime end = DateTime.Now;
            return end - start;
        }

        public virtual async Task<TimeSpan> UpdateAllAsync(int newFirst)
        {
            DateTime start = DateTime.Now;
            await DbAction.UpdateAllRandomValuesAsync(ConnectionObject, newFirst);
            DateTime end = DateTime.Now;
            return end - start;
        }
    }
}
