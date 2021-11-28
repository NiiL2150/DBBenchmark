using DBBenchmark.DbBenchmark;
using DBBenchmark.Models;
using System;

namespace DBBenchmark
{
    internal class Program
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; 
Initial Catalog=RandomDB; 
Integrated Security=true;";
        static RandomDBContext context = new RandomDBContext();

        static async Task Main(string[] args)
        {
            await context.Database.EnsureCreatedAsync();
            await ChooseDB();
        }

        static async Task ChooseDB()
        {
            int i = 0;
            IDbBenchmark? benchmark;
            do
            {
                Console.Clear();
                benchmark = null;
                Console.WriteLine("1 - SQL, 2 - Dapper, 3 - EFCore, 0 - Quit");
                i = Int32.Parse(Console.ReadLine());
                if (i == 1)
                {
                    //TODO: Implement SqlAction and SqlBenchmark
                }
                else if (i == 2)
                {
                    benchmark = new DapperBenchmark(connectionString);
                }
                else if (i == 3)
                {
                    benchmark = new EFBenchmark();
                }
                await ChooseTask(benchmark, i - 1);
            } while (i != 0);
        }

        static async Task ChooseTask(IDbBenchmark? benchmark, int DbInt)
        {
            if(benchmark == null) { return; }
            int i = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(@"1 - AddOne, 2 - AddMany, 
3 - GetOneId, 4 - GetMany, 5 - GetFirstString, 6 - GetAllString, 
7 - UpdateOne, 8 - UpdateAll, 9 - DeleteOne, 10 - DeleteAll 0 - Quit");
                i = Int32.Parse(Console.ReadLine());
                if (i == 1)
                {
                    TimeSpan time = await benchmark.AddOneAsync();
                    DBTest test = new DBTest()
                    {
                        Resolver = (Resolver)DbInt,
                        Start = DateTime.Now - time,
                        TestType = (TestType)0,
                        Timing = time
                    };
                    context.DBTests.Add(test);
                }
                else if (i == 2)
                {
                    //TODO: Implement IDbBenchmark.AddMany
                }
                if (i == 3)
                {
                    Console.WriteLine("Enter id");
                    int id = Int32.Parse(Console.ReadLine());
                    TimeSpan time = await benchmark.GetFirstIdAsync(id);
                    DBTest test = new DBTest()
                    {
                        Resolver = (Resolver)DbInt,
                        Start = DateTime.Now - time,
                        TestType = (TestType)2,
                        Timing = time
                    };
                    context.DBTests.Add(test);
                }
                else if (i == 4)
                {
                    //TODO: Implement IDbBenchmark.GetMany
                }
                if (i == 5)
                {
                    Console.WriteLine("Enter string");
                    string str = Console.ReadLine();
                    TimeSpan time = await benchmark.GetFirstStringAsync(str);
                    DBTest test = new DBTest()
                    {
                        Resolver = (Resolver)DbInt,
                        Start = DateTime.Now - time,
                        TestType = (TestType)4,
                        Timing = time
                    };
                    context.DBTests.Add(test);
                }
                else if (i == 6)
                {
                    //TODO: Implement IDbBenchmark.GetAllString
                }
                if (i == 7)
                {
                    Console.WriteLine("Enter id");
                    int id = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new value");
                    int newFirst = Int32.Parse(Console.ReadLine());
                    TimeSpan time = await benchmark.UpdateOneAsync(id, newFirst);
                    DBTest test = new DBTest()
                    {
                        Resolver = (Resolver)DbInt,
                        Start = DateTime.Now - time,
                        TestType = (TestType)6,
                        Timing = time
                    };
                    context.DBTests.Add(test);
                }
                else if (i == 8)
                {
                    //TODO: Implement IDbBenchmark.UpdateAll
                }
                if (i == 9)
                {
                    Console.WriteLine("Enter id");
                    int id = Int32.Parse(Console.ReadLine());
                    TimeSpan time = await benchmark.DeleteOneAsync(id);
                    DBTest test = new DBTest()
                    {
                        Resolver = (Resolver)DbInt,
                        Start = DateTime.Now - time,
                        TestType = (TestType)8,
                        Timing = time
                    };
                    context.DBTests.Add(test);
                }
                else if (i == 10)
                {
                    //TODO: Implement IDbBenchmark.DeleteAll
                }
                await context.SaveChangesAsync();
            } while (i != 0);
        }
    }
}
