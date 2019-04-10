using SmartMapper;
using SmartMapper.Attributes;
using System;

namespace Smart.Classes
{
    public class Intake
    {
        [EntityKey]
        [AutoCalculate]
        public int Intake_ID { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public string Times { set; get; }
        public int Course_ID { set; get; }

        public virtual Course course { set; get; }
        public float Price { set; get; }
    }
}
