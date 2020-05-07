using System;
using System.Linq;

namespace TPT
{
    class Program
    {
        //Add-Migration InitialCreate
        //update-database
        static void Main(string[] args)
        {
            using (var context = new TPTContext())
            {
                Console.WriteLine("All courses:");
                foreach (var course in context.Courses)
                {
                    Console.WriteLine("{0}\t{1}", course.CourseId, course.CourseName);
                }

                Console.WriteLine("Online only: ");
                foreach (var course in context.OnlineCourses)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", course.CourseId, course.Course.CourseName, course.SelfPaced);
                }

                Console.WriteLine("Lab only: ");
                foreach (var course in context.LabCourses)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", course.CourseId, course.Course.CourseName, course.Location);
                }
                OnlineCourse online = new OnlineCourse()
                {
                    Course = new Course()
                    {
                        CourseName = "Added In time " + DateTime.Now,
                        Price = 123
                    },
                    SelfPaced = true
                };

                LabCourse lab = new LabCourse()
                {
                    Course = new Course()
                    {
                        CourseName = "Added In time " + DateTime.Now,
                        Price = 123
                    },
                        Location = "Home Center",
                };
                context.OnlineCourses.Add(online);
                context.LabCourses.Add(lab);

                context.SaveChanges();
            }
        }
    }
}
