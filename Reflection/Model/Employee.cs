using System;

namespace Model
{
    public class Employee
    {
        public Employee()
        {

        }
        public void SetAll(int id,string name, int age, int salary)
        {
            ID = id;
            Name = name;
            Age = age;
            Salary = salary;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; private set; }
        private bool Married { get; set; }

        public void ChangeMaritalStatus()
        {
            Console.WriteLine("I am Called");
            Married = !Married;
        }


        public override string ToString()
        {
            return $"Employee {ID}, {Name},{Age},{Salary},{Married}";
        }
    }
}
