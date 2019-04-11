using SmartMapper;
using SmartMapper.Attributes;

namespace Smart.Classes
{
    public class Student
    {
        [AutoCalculate]
        [EntityKey]
        public int Student_ID { private set; get; }
        public string Name { set; get; }
        public string EMail { set; get; }
        public string Mobile { set; get; }

        public string Address { set; get; }
        public string Gender { set; get; }
        [NonPersisted]
        private int Age
        {
            set { }
            get { return 18; }
        }
    }
}
