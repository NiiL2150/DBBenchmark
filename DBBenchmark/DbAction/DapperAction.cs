using DBBenchmark.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DBBenchmark.DbAction
{
    internal class DapperAction : IDbAction
    {
        public async Task AddRandomValueAsync(object conn)
        {
            Random random = new Random();
            SqlConnection sqlConnection = new SqlConnection(conn as string);
            string query = @"INSERT INTO RandomValues 
(FirstValue, SecondValue, ThirdValue, FourthValue)
VALUES(@IntV, @StringV, @DateTimeV, @DoubleV)";

            await sqlConnection.ExecuteAsync(query,
                new
                {
                    IntV = random.Next(),
                    StringV = random.NextString(),
                    DateTimeV = random.NextDateTime(),
                    DoubleV = random.NextDouble()
                })
                .ConfigureAwait(false);
        }

        public async Task DeleteRandomValueAsync(object conn, int id)
        {
            SqlConnection sqlConnection = new SqlConnection(conn as string);
            string query = @"DELETE FROM RandomValues WHERE Id = @IdV";

            await sqlConnection.ExecuteAsync(query, new { IdV = id }).ConfigureAwait(false);
        }

        public async Task UpdateRandomValueAsync(object conn, int id, int newFirst)
        {
            SqlConnection sqlConnection = new SqlConnection(conn as string);
            string query = @"UPDATE RandomValues
SET FirstValue = @NewFirst
WHERE Id = @IdV";

            await sqlConnection.ExecuteAsync(query, new { IdV = id, NewFirst = newFirst }).ConfigureAwait(false);
        }

        public async Task<object?> GetRandomValueAsync(object conn, int id)
        {
            SqlConnection sqlConnection = new SqlConnection(conn as string);
            string query = @"SELECT * FROM RandomValues WHERE Id = @IdV";

            var item = await sqlConnection.QueryFirstOrDefaultAsync(query, new { IdV = id });
            return item;
        }

        public async Task<object?> SearchByStringAsync(object conn, string searchString)
        {
            SqlConnection sqlConnection = new SqlConnection(conn as string);
            string query = @"SELECT * FROM RandomValues WHERE SecondValue = @str";

            var item = await sqlConnection.QueryFirstOrDefaultAsync(query, new { str = searchString });
            return item;
        }
    }
}
