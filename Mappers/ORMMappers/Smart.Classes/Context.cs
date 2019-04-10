using SmartMapper;

namespace Smart.Classes
{
    public class Context : ContextBase
    {
        public TableSet<Student> Students;
        public TableSet<Course> Courses;
        public Context(string conString) : base(conString)
        {
            Students = new TableSet<Student>(_connection);
            Courses = new TableSet<Course>(_connection);
        }
    }
}
