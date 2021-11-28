using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBBenchmark.Models
{
    public class DBTest
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public Resolver Resolver { get; set; }
        public TestType TestType { get; set; }
        public TimeSpan Timing { get; set; }
    }

    public enum Resolver { SQL, Dapper, EFCore }

    public enum TestType
    {
        AddOne, AddMany, GetOneId, GetMany, GetFirstString, GetAllString,
        UpdateOne, UpdateAll, DeleteOne, DeleteAll
    }
}
