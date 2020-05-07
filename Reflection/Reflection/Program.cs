using System;
using System.Reflection;
using System.Linq;
using Model;

namespace Reflection
{
    /// <summary>
    /// What Is Reflection:
    /// In computer science, reflection is the ability of a computer program to examine and modify the structure and behavior of the program at runtime.
    /// Reflection allows you to obtain information about  types defined within assemblies,  information about fields, properties and methods.
    /// Reflection in .NET
    /// The classes in the System.Reflection namespace, together with System.Type, 
    /// enable you to obtain information about loaded assemblies and the types defined within, such as classes, interfaces, and value types.
    /// You can also use reflection to create type instances at run time and to invoke them.
    /// 
    /// The Common Language Runtime (ClR) loader manages application domains, which constitute defined boundaries around objects that have the same application scope. 
    /// This management includes 
    /// 1. loading each assembly into the appropriate application domain 
    /// 2. controlling the memory layout of the type hierarchy  within each assembly.
    /// Assemblies contain modules, modules contain types and types contain members.
    /// 
    /// Reflection provides objects that encapsulate assemblies, modules and types.
    /// You can use reflection to dynamically create an instance of a type, bind the type to an existing object, or get the type from an existing object. 
    /// You can then invoke the type's methods or access its fields and properties.
    /// </summary>


    class Program
    {
        static void Main(string[] args)
        {
            // Getting Type
            int i = 5;
            Console.WriteLine(i.GetType());
            // Getting Assembly 
            var assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine("Assembly Name: " + assembly.GetName().Name);
            Console.WriteLine("Version: " + assembly.GetName().Version.ToString());
            // Getting Types in Local Assembly
            Console.WriteLine("\nLocal Assembly:");
            foreach (var item in assembly.DefinedTypes)
            {
                Console.WriteLine(item.GetTypeInfo().FullName);
            }
            //Getting Types in reference assembly
            Console.WriteLine("\nReference Assembly:");
            
            var refereceassembly = Assembly.GetAssembly(new Employee().GetType());
            foreach (var item in refereceassembly.ExportedTypes)
            {
                Console.WriteLine(item.GetTypeInfo().FullName);
            }

            // Reading Details of A Class
            Employee employee = new Employee();
            employee.SetAll(1, "Hamada", 5, 100);
            var employeeTypeInfo = typeof(Employee).GetTypeInfo();
            // 1. Propoerties 
            Console.WriteLine("\nPropoerties:");

            foreach (var item in employeeTypeInfo.DeclaredProperties)
            {
                Console.WriteLine($"{item.Name}, {item.PropertyType}");
            }

            // 2. Methods
            Console.WriteLine("\nMethods:");
            foreach (var item in employeeTypeInfo.DeclaredMethods)
            {
                Console.WriteLine($" - {item.ReturnType} {item.Name}:");
                foreach (var p in item.GetParameters())
                {
                    Console.WriteLine($" \t- {p.ParameterType},{p.Name}");
                }

            }

            // Making changes in an object
            employeeTypeInfo.GetProperty("Name").SetValue(employee, "Mr Hamada");

            //Making change in private object
            employeeTypeInfo.GetProperty("Salary").SetValue(employee, -100);

            // Invoke Method
            var method = employeeTypeInfo.GetMethods().Single(x => x.Name == "ChangeMaritalStatus");
            method.Invoke(employee, null);
            Console.WriteLine(employee.ToString());

        }
    }
}
