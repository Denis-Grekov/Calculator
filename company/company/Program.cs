using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company
{
    class Program
    {
        static void Main(string[] args)
        {

            Company company = new Company();
            company.GenerateEmployees(10);
            company.PrintEmployees();


            Console.ReadKey();
        }

       

    }

    class Employee
    {
        public double salary { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string companyName { get; set; }
        public int post { get; set; } // 1 - Директор, 2 - Старший сотрудник, 3 - Младший сотрудник

        public void Hello()
        {
            switch (post)
            {
                case 1:
                    Console.WriteLine($"Здравствуйте, меня зовут {name}, надеюсь на наше дальнейшее сотрудничество!");
                    break;
                case 2:
                    Console.WriteLine($"Привет, я {name}, будем знакомы.");
                    break;
                case 3:
                    Console.WriteLine($"Ку, я {name}, теперь мы в одной лодке :)");
                    break;
            }
        }
    }

    public class Company
    {
        private List<Employee> employees;

        public Company()
        {
            employees = new List<Employee>();
        }

        public void GenerateEmployees(int count)
        {
            var rnd = new Random();
            employees = new List<Employee>();

            var firstNames = new List<string>() { "Иван", "Петр", "Андрей", "Сергей", "Олег" };
            var lastNames = new List<string>() { "Иванов", "Петров", "Сидоров", "Кузнецов", "Соловьев" };
            var companyNames = new List<string>() { "Кондитерская №1", "Кондитерская №2", "Кондитерская №3", "Кондитерская №4" };

            for (int i = 0; i < count; i++)
            {
                var employee = new Employee
                {
                    salary = rnd.NextDouble() * 2000 + 1000,
                    name = string.Format("{0} {1}", firstNames[rnd.Next(firstNames.Count)], lastNames[rnd.Next(lastNames.Count)]),
                    age = rnd.Next(18, 60),
                    companyName = companyNames[rnd.Next(companyNames.Count)],
                    post = rnd.Next(1, 4)
                };
                employees.Add(employee);
            }
        }

        public void PrintEmployees()
        {
            Console.WriteLine("{0,-20} {1,-10} {2,-10} {3,-20} {4,-10}", "ФИО", "Возраст", "Должность", "Зарплата", "Компания");
            foreach (var employee in employees)
            {
                Console.WriteLine("{0,-20} {1,-10} {2,-10} {3,-20} {4,-10}", employee.name, employee.age, employee.post, employee.salary, employee.companyName);
            }
            Console.WriteLine();
        }
    }

}

