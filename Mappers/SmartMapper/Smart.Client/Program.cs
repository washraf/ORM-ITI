using Smart.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smart.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context("Data Source =.; Initial Catalog = ORMMappers; Integrated Security = True");

            IEnumerable<Student> students = context.Students.GetAll();
            foreach (var s in students)
            {
                Console.Write(s.Student_ID);
                Console.Write("\t");
                Console.Write(s.Name);
                Console.WriteLine();
            }

            context.Students.Add(new Student()
            {
                // Student_ID = 456,
                Name = "ali",
                EMail = "a",
                Address = "123",
                Mobile = "123",
                Gender = "M"
            });
            var ss = students.ToList()[0];
            ss.Name = "Ahmed";
            context.Students.Update(ss);

            context.Courses.Add(new Course()
            {
                CourseName = "ORM",
                CourseContents = "ORM",
                CourseDescription = "ORM",
                CourseDuration = 2,
            });
            
            List<Course> course = context.Courses.Find(x => x.Course_ID > 0).ToList();
            foreach (var s in course)
            {
                Console.Write(s.Course_ID);
                Console.Write("\t");
                Console.Write(s.CourseName);
                Console.WriteLine();
                Console.WriteLine(s.Intakes.FirstOrDefault()?.course.Course_ID);
            }
        }
    }
}
