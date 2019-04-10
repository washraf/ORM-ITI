using Dummy.Client.Mapper;
using System;

namespace Dummy.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentMapper m = new StudentMapper("Data Source=.;Initial Catalog=ORMMappers;Integrated Security=True");

            m.InsertStudent("ali", "a", "123", "123", "M");
            var x = m.GetAll();
            foreach (var item in x)
            {
                Console.Write(item.StudentId + "\t" + item.Name);
                Console.WriteLine();
            }

            Console.Read();
        }
    }
}
