using DBBenchmark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBenchmark.DbAction
{
    internal interface IDbAction
    {
        Task AddRandomValueAsync(object conn);
        Task AddRandomValuesAsync(object conn);
        Task<object?> GetRandomValueAsync(object conn, int id);
        Task<object?> GetRandomValuesAsync(object conn);
        Task<object?> SearchByStringAsync(object conn, string searchString);
        Task<object?> SearchMultByStringAsync(object conn, string searchString);
        Task UpdateRandomValueAsync(object conn, int id, int newFirst);
        Task UpdateAllRandomValuesAsync(object conn, int newFirst);
        Task DeleteRandomValueAsync(object conn, int id);
        Task DeleteAllRandomValuesAsync(object conn);
    }
}
