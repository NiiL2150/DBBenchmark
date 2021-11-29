using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBBenchmark.DbAction
{
    internal class SqlAction : IDbAction
    {
        public async Task AddRandomValueAsync(object conn)
        {
            Random random = new Random();
            SqlConnection sqlConnection = new SqlConnection(conn as string);
            if (sqlConnection == null) { return; }
            if (sqlConnection.State != ConnectionState.Closed) { await sqlConnection.CloseAsync(); }

            using (sqlConnection)
            {
                await sqlConnection.OpenAsync();
                string query = @"INSERT INTO RandomValues 
    (FirstValue, SecondValue, ThirdValue, FourthValue)
    VALUES(@IntV, @StringV, @DateTimeV, @DoubleV)";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                SqlParameter[] parameters = new SqlParameter[4]
                {
                    new SqlParameter("@IntV", SqlDbType.Int),
                    new SqlParameter("@StringV", SqlDbType.NVarChar),
                    new SqlParameter("@DateTimeV", SqlDbType.DateTime),
                    new SqlParameter("@DoubleV", SqlDbType.Float)
                };

                parameters[0].Value = random.Next();
                parameters[1].Value = random.NextString();
                parameters[2].Value = random.NextDateTime();
                parameters[3].Value = random.NextDouble();

                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }

                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task AddRandomValuesAsync(object conn)
        {
            Random random = new Random();
            SqlConnection sqlConnection = new SqlConnection(conn as string);
            if (sqlConnection == null) { return; }
            if (sqlConnection.State != ConnectionState.Closed) { await sqlConnection.CloseAsync(); }

            using (sqlConnection)
            {
                await sqlConnection.OpenAsync();
                string query = @"INSERT INTO RandomValues 
(FirstValue, SecondValue, ThirdValue, FourthValue)
VALUES(@IntV, @StringV, @DateTimeV, @DoubleV)";

                for (int i = 0; i < 1000; i++)
                {
                    SqlCommand cmd = new SqlCommand(query, sqlConnection);

                    SqlParameter[] parameters = new SqlParameter[4]
                    {
                    new SqlParameter("@IntV", SqlDbType.Int),
                    new SqlParameter("@StringV", SqlDbType.NVarChar),
                    new SqlParameter("@DateTimeV", SqlDbType.DateTime),
                    new SqlParameter("@DoubleV", SqlDbType.Float)
                    };

                    parameters[0].Value = random.Next();
                    parameters[1].Value = random.NextString();
                    parameters[2].Value = random.NextDateTime();
                    parameters[3].Value = random.NextDouble();

                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteRandomValueAsync(object conn, int id)
        {
            SqlConnection sqlConnection = new SqlConnection(conn as string);
            if (sqlConnection == null) { return; }
            if (sqlConnection.State != ConnectionState.Closed) { await sqlConnection.CloseAsync(); }

            using (sqlConnection)
            {
                await sqlConnection.OpenAsync();
                string query = @"DELETE FROM RandomValues WHERE Id = @IdV";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlParameter parameter = new SqlParameter("@IdV", SqlDbType.Int);
                parameter.Value = id;
                cmd.Parameters.Add(parameter);

                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteAllRandomValuesAsync(object conn)
        {
            SqlConnection sqlConnection = new SqlConnection(conn as string);
            if (sqlConnection == null) { return; }
            if (sqlConnection.State != ConnectionState.Closed) { await sqlConnection.CloseAsync(); }

            using (sqlConnection)
            {
                await sqlConnection.OpenAsync();
                string query = @"DELETE FROM RandomValues";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                await cmd.ExecuteNonQueryAsync();
            }
        }


        public async Task UpdateRandomValueAsync(object conn, int id, int newFirst)
        {
            SqlConnection sqlConnection = new SqlConnection(conn as string);
            if (sqlConnection == null) { return; }
            if (sqlConnection.State != ConnectionState.Closed) { await sqlConnection.CloseAsync(); }

            using (sqlConnection)
            {
                await sqlConnection.OpenAsync();
                string query = @"UPDATE RandomValues
SET FirstValue = @NewFirst
WHERE Id = @IdV";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                SqlParameter[] parameters = new SqlParameter[2]
                {
                new SqlParameter("@NewFirst", SqlDbType.Int),
                new SqlParameter("@IdV", SqlDbType.Int)
                };

                parameters[0].Value = newFirst;
                parameters[1].Value = id;

                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }

                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateAllRandomValuesAsync(object conn, int newFirst)
        {
            SqlConnection sqlConnection = new SqlConnection(conn as string);
            if (sqlConnection == null) { return; }
            if (sqlConnection.State != ConnectionState.Closed) { await sqlConnection.CloseAsync(); }

            using (sqlConnection)
            {
                await sqlConnection.OpenAsync();
                string query = @"UPDATE RandomValues
SET FirstValue = @NewFirst";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                SqlParameter parameter = new SqlParameter("@NewFirst", SqlDbType.Int);

                parameter.Value = newFirst;

                cmd.Parameters.Add(parameter);

                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<object?> GetRandomValueAsync(object conn, int id)
        {
            SqlConnection sqlConnection = new SqlConnection(conn as string);
            if (sqlConnection == null) { return null; }
            if(sqlConnection.State != ConnectionState.Closed) { await sqlConnection.CloseAsync(); }

            using (sqlConnection)
            {
                await sqlConnection.OpenAsync();
                string query = @"SELECT * FROM RandomValues WHERE Id = @IdV";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlParameter parameter = new SqlParameter("@IdV", SqlDbType.Int);
                parameter.Value = id;
                cmd.Parameters.Add(parameter);

                return await cmd.ExecuteReaderAsync();
            }
        }

        public async Task<object?> GetRandomValuesAsync(object conn)
        {
            SqlConnection sqlConnection = new SqlConnection(conn as string);
            if (sqlConnection == null) { return null; }

            using (sqlConnection)
            {
                await sqlConnection.OpenAsync();
                string query = @"SELECT * FROM RandomValues";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                return await cmd.ExecuteReaderAsync();
            }
        }

        public async Task<object?> SearchByStringAsync(object conn, string searchString)
        {
            SqlConnection sqlConnection = new SqlConnection(conn as string);
            if (sqlConnection == null) { return null; }

            using (sqlConnection)
            {
                await sqlConnection.OpenAsync();
                string query = @"SELECT TOP 1 * FROM RandomValues WHERE SecondValue = @str ORDER BY Id";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlParameter parameter = new SqlParameter("@str", SqlDbType.NVarChar);
                parameter.Value = searchString;
                cmd.Parameters.Add(parameter);

                return await cmd.ExecuteReaderAsync();
            }
        }

        public async Task<object?> SearchMultByStringAsync(object conn, string searchString)
        {
            SqlConnection sqlConnection = new SqlConnection(conn as string);
            if (sqlConnection == null) { return null; }

            using (sqlConnection)
            {
                await sqlConnection.OpenAsync();
                string query = @"SELECT * FROM RandomValues WHERE SecondValue = @str";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                SqlParameter parameter = new SqlParameter("@str", SqlDbType.NVarChar);
                parameter.Value = searchString;
                cmd.Parameters.Add(parameter);

                return await cmd.ExecuteReaderAsync();
            }
        }
    }
}
