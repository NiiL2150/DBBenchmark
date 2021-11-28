using DBBenchmark.DbAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBenchmark.DbBenchmark
{
    internal class EFBenchmark : IDbBenchmark
    {
        public IDbAction DbAction { get; set; }
        RandomDBContext context;

        public EFBenchmark(RandomDBContext context)
        {
            this.context = context;
            DbAction = new EFAction();
        }
        public EFBenchmark() : this(new RandomDBContext()) { }

        public async Task<TimeSpan> AddOneAsync()
        {
            DateTime start = DateTime.Now;
            await DbAction.AddRandomValueAsync(context);
            DateTime end = DateTime.Now;
            return end - start;
        }

        public async Task<TimeSpan> DeleteOneAsync(int id)
        {
            DateTime start = DateTime.Now;
            await DbAction.DeleteRandomValueAsync(context, id);
            DateTime end = DateTime.Now;
            return end - start;
        }

        public async Task<TimeSpan> GetFirstIdAsync(int id)
        {
            DateTime start = DateTime.Now;
            await DbAction.GetRandomValueAsync(context, id);
            DateTime end = DateTime.Now;
            return end - start;
        }

        public async Task<TimeSpan> GetFirstStringAsync(string searchString)
        {
            DateTime start = DateTime.Now;
            await DbAction.SearchByStringAsync(context, searchString);
            DateTime end = DateTime.Now;
            return end - start;
        }

        public async Task<TimeSpan> UpdateOneAsync(int id, int newFirst)
        {
            DateTime start = DateTime.Now;
            await DbAction.UpdateRandomValueAsync(context, id, newFirst);
            DateTime end = DateTime.Now;
            return end - start;
        }
    }
}
