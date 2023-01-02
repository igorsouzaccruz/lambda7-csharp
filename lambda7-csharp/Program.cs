using System;
using System.Globalization;
using lambda7_csharp.Entities;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            Console.Write("Enter salary: ");
            double inputSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<Employee> employees = new List<Employee>();

            using (StreamReader rs = File.OpenText(path))
            {
                while(!rs.EndOfStream)
                {
                    string[] fields = rs.ReadLine().Split(",");
                    string name = fields[0];
                    string email = fields[1]; 
                    double salaray = double.Parse(fields[2],CultureInfo.InvariantCulture);
                    employees.Add(new Employee(name, email, salaray));  
                }
            }

            var emails = employees.OrderBy(p => p.Email).Where(p => p.Salary > inputSalary).Select(p => p.Email);

            var sum = employees.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);

            Console.WriteLine("Email of peole whose salary is more than 2000.00");
            foreach (var mail in emails)
            {
                Console.WriteLine(mail);
            }
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum);
        }
    }
}