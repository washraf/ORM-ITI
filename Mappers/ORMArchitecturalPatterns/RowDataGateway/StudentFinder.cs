using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RowDataGateway
{
    public class StudentFinder
    {
        private static readonly SqlConnection Con
               = new SqlConnection("Data Source=.;Initial Catalog=ORMPatterns;Integrated Security=True");
        public static Student FindById(int id)
        {
            Con.Open();
            String sql = "SELECT * FROM student WHERE id = @key";
            IDbCommand comm = new SqlCommand(sql, Con);
            comm.Parameters.Add(new SqlParameter("key", id));
            IDataReader reader = comm.ExecuteReader();
            reader.Read();
            Object[] result = new Object[reader.FieldCount];
            reader.GetValues(result);
            reader.Close();
            return new Student()
            {
                Id = Convert.ToInt32(result[0]),
                Name = result[1].ToString()
            };
        }

        public static List<Student> FindByName(string name)
        {
            String sql = "SELECT * FROM student WHERE name like %@name%";
            SqlCommand cmd = new SqlCommand(sql, Con);
            cmd.Parameters.Add(new SqlParameter("name", name));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            var students = new List<Student>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                students.Add(new Student()
                {
                    Id = Convert.ToInt32(dt.Rows[i][0]),
                    Name = dt.Rows[i][1].ToString()
                });
            }
            return students;
        }
        public static List<Student> GetAll()
        {
            String sql = "SELECT * FROM student";
            SqlCommand cmd = new SqlCommand(sql, Con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            var students = new List<Student>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                students.Add(new Student()
                {
                    Id = Convert.ToInt64(dt.Rows[i][0]),
                    Name = dt.Rows[i][1].ToString()
                });
            }
            return students;
        }
    }
}