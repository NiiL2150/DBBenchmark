using DBBenchmark.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBenchmark.DbAction
{
    internal class EFAction : IDbAction
    {
        public async Task AddRandomValueAsync(object conn)
        {
            RandomDBContext? context = conn as RandomDBContext;
            if(context == null) { return; }

            Random random = new();
            RandomValue value = new()
            {
                FirstValue = random.Next(),
                SecondValue = random.NextString(),
                ThirdValue = random.NextDateTime(),
                FourthValue = random.NextDouble()
            };
            await context.RandomValues.AddAsync(value);
            await context.SaveChangesAsync();
        }

        public async Task DeleteRandomValueAsync(object conn, int id)
        {
            RandomDBContext? context = conn as RandomDBContext;
            if(context == null) { return; }

            context.RandomValues.Remove(context.RandomValues.First(x => x.Id == id));
            await context.SaveChangesAsync();
        }

        public async Task<object?> GetRandomValueAsync(object conn, int id)
        {
            RandomDBContext? context = conn as RandomDBContext;
            if(context == null) { return null; }

            return await context.RandomValues.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<object?> SearchByStringAsync(object conn, string searchString)
        {
            RandomDBContext? context = conn as RandomDBContext;
            if(context == null) { return null; }

            return await context.RandomValues.FirstOrDefaultAsync(x => x.SecondValue == searchString);
        }

        public async Task UpdateRandomValueAsync(object conn, int id, int newFirst)
        {
            RandomDBContext? context = conn as RandomDBContext;
            if (context == null) { return; }

            RandomValue? random = await this.GetRandomValueAsync(conn, id) as RandomValue;
            if (random == null) { return; }

            random.FirstValue = newFirst;

            await context.SaveChangesAsync();
        }
    }
}
