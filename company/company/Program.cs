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

    
    enum PostEnum
    {
        Director = 1,
        SeniorEmployee = 2,
        JuniorEmployee = 3
    }

    class Employee
    {
        public double salary { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string companyName { get; set; }
        public PostEnum post { get; set; } // 1 - Директор, 2 - Старший сотрудник, 3 - Младший сотрудник

        public void Hello()
        {
            switch (post)
            {
                case PostEnum.Director:
                    Console.WriteLine($"Здравствуйте, меня зовут {name}, надеюсь на наше дальнейшее сотрудничество!");
                    break;
                case PostEnum.SeniorEmployee:
                    Console.WriteLine($"Привет, я {name}, будем знакомы.");
                    break;
                case PostEnum.JuniorEmployee:
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
            var companyNames = new List<string>() { "Кондитерская №1" };

            var usedNames = new List<string>();

            for (int i = 0; i < count; i++)
            {
                string newName;
                do
                {
                    newName = string.Format("{0} {1}", firstNames[rnd.Next(firstNames.Count)], lastNames[rnd.Next(lastNames.Count)]);
                } while (usedNames.Contains(newName));
                usedNames.Add(newName);

                var employee = new Employee
                {
                    salary = Math.Round(rnd.NextDouble() * 2000 + 1000, 2),
                    name = newName,
                    age = rnd.Next(18, 100),
                    companyName = companyNames[rnd.Next(companyNames.Count)],
                    post = (PostEnum)rnd.Next(1, Enum.GetValues(typeof(PostEnum)).Length + 1)
            };
                employees.Add(employee);
            }
        }
        public void PrintEmployees()
        {
            Console.WriteLine("{0,-20} {1,-10} {2,-20} {3,-20} {4,-10}", "ФИО", "Возраст", "Должность", "Зарплата", "Компания");
            foreach (var employee in employees)
            {
                Console.WriteLine("{0,-20} {1,-10} {2,-20} {3,-20} {4,-10}", employee.name, employee.age, employee.post, employee.salary, employee.companyName);
            }
            Console.WriteLine();
        }
    }



    
}

