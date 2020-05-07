using System;
using System.Data;
using System.Data.SqlClient;

namespace RowDataGateway
{
    public class StudentRowGateway
    {
        private static readonly SqlConnection Con
            = new SqlConnection("Data Source=.;Initial Catalog=ORMPatterns;Integrated Security=True");

        public long Id { get; set; }
        public string Name { get; set; }

        public StudentRowGateway()
        {
            Con.Open();
        }

        public StudentRowGateway(Student student)
        {
            Con.Open();
            this.Id = student.Id;
            this.Name = student.Name;
        }

        public int InsertStudent()
        {

            string sql = "INSERT INTO student VALUES (@key,@name)";
            long key = DateTime.Now.Ticks;
            IDbCommand comm = new SqlCommand(sql, Con);
            comm.Parameters.Add(new SqlParameter("key", Id));
            comm.Parameters.Add(new SqlParameter("name", Name));
            return comm.ExecuteNonQuery();
        }


        public int UpdateStudent()
        {
            string sql = @"UPDATE student SET name = @name WHERE id = @key";
            IDbCommand comm = new SqlCommand(sql, Con);
            comm.Parameters.Add(new SqlParameter("name", Name));
            comm.Parameters.Add(new SqlParameter("key", Id));
            return comm.ExecuteNonQuery();
        }


        
    }
}