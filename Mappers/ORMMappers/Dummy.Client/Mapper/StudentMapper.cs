using Dummy.Client.Model;
using Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dummy.Client.Mapper
{
    public class StudentMapper : IDisposable
    {
        private SqlConnection _connection;
        public StudentMapper(SqlConnection con)
        {
            _connection = con;
            _connection.Open();
        }
        public StudentMapper(string conString)
        {
            _connection = new SqlConnection(conString);
            _connection.Open();
        }
        public Student GetStudentById(int Id)
        {
            string cmd = "select * from Student where Student_ID = @ID";

            var dr = SqlHelpers.GetRow(_connection, cmd, new SqlParameter("ID", Id));
            if (dr == null) return null;
            return new Student()
            {
                StudentId = int.Parse(dr["Student_ID"].ToString()),
                Name = dr["Name"].ToString(),
                EMail = dr["EMail"].ToString(),
                Mobile = dr["Mobile"].ToString(),
                Address = dr["Address"].ToString(),
                Gender = dr["Gender"].ToString(),
            };
        }
        public List<Student> GetAll()
        {
            string cmd = "select * from Student";

            var dt = SqlHelpers.GetDataTable(_connection, cmd);
            List<Student> students = new List<Student>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                students.Add(
                    new Student()
                    {
                        StudentId = int.Parse(dt.Rows[i]["Student_ID"].ToString()),
                        Name = dt.Rows[i]["Name"].ToString(),
                        EMail = dt.Rows[i]["EMail"].ToString(),
                        Mobile = dt.Rows[i]["Mobile"].ToString(),
                        Address = dt.Rows[i]["Address"].ToString(),
                        Gender = dt.Rows[i]["Gender"].ToString(),
                    });
            }
            return students;
        }
        public int InsertStudent(string name, string email,
            string mobile, string address, string gender)
        {
            string cmd = "insert into student(Name,Email, Mobile,Address,Gender) " +
                         "values(@name,@email,@mobile,@address,@gender)";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("name", name),
                new SqlParameter("email", email),
                new SqlParameter("mobile", mobile),
                new SqlParameter("address", address),
                new SqlParameter("gender", gender)
            };
            return SqlHelpers.Insert(_connection, cmd, parameters);
        }
        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
