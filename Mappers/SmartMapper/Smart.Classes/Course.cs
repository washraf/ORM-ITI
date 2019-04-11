using SmartMapper;
using SmartMapper.Attributes;
using System.Collections.Generic;

namespace Smart.Classes
{
    public class Course
    {
        [AutoCalculate]
        [EntityKey]
        public int Course_ID { private set; get; }
        public string CourseName { set; get; }
        public string CourseDescription { set; get; }
        public string CourseContents { set; get; }
        public int CourseDuration { set; get; }

        public virtual IEnumerable<Intake> Intakes { get; set; }
    }
}
