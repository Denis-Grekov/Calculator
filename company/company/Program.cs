using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;


namespace company
{
    class Program
    {
        static void Main(string[] args)
        {
            int post, toDo;
            Company company = new Company();
            company.GenerateEmployees(10);
            company.PrintEmployees();
            Console.WriteLine("Что сделать? 1 - показать определенных сотрудников; 2 - Удалить сотрудника с наименьшей зарплатой; 3 - поздароваться");
            toDo = Convert.ToInt32(Console.ReadLine());
            switch (toDo)
            {
                case 1:
                    Console.WriteLine("Каких сотрудников вывести? 1 - Director; 2 - SeniorEmployee; 3 - JuniorEmployee");
                    post = Convert.ToInt32(Console.ReadLine());

                    if (post == 1 || post == 2 || post == 3)
                    {
                        company.PrintEmployeesWithPost(post);
                        
                    }
                    else
                    {
                        Console.WriteLine("Выберите из перечисленных!");
                    }
                    break;
                case 2:
                    company.RemoveEmployee();
                    company.PrintEmployees();
                    break;
                case 3:
                    company.GreetDirector();
                    company.GreetSeniorEmployees();
                    company.GreetJuniorEmployees();
                    break;
                default:
                    Console.WriteLine("Выберите из перечисленных!");
                    break;
            }
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
        public double Salary { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string CompanyName { get; set; }
        public PostEnum Post { get; set; } // 1 - Директор, 2 - Старший сотрудник, 3 - Младший сотрудник
        public Employee(string name)
        {
            Name = name;
        }
        public virtual void Hello() { }
    }

    class Director : Employee
    {
        public List<Director> Directors { get; } = new List<Director>();
        public Director(string name)  : base(name)
        {  
            Post = PostEnum.Director;
        }
        
        public override void Hello()
        {
            Console.WriteLine($"Здравствуйте, меня зовут {Name}, надеюсь на наше дальнейшее сотрудничество!");
        }
    }

    class SeniorEmployee : Employee
    {
        public SeniorEmployee(string name) : base(name)
        {
            Post = PostEnum.Director;
        }

        public override void Hello()
        {
            Console.WriteLine($"Привет, я {Name}, будем знакомы.");
        }
    }

    class JuniorEmployee: Employee
    {
        public JuniorEmployee(string name) : base(name)
        {
            Post = PostEnum.JuniorEmployee;
        }

        public override void Hello()
        {
            Console.WriteLine($"Ку, я {Name}, теперь мы в одной лодке :)");
        }
    }

    public class Company
    {
        private List<Employee> employees;
        private string directorName;
        private string seniorName;
        private string juniorName;

        private Director director = new Director("d");
        public Company()
        {
            employees = new List<Employee>();
        }

        public void GenerateEmployees(int count)
        {
            var rnd = new Random();
            var firstNames = new List<string>() { "Иван", "Петр", "Андрей", "Сергей", "Олег" };
            var lastNames = new List<string>() { "Иванов", "Петров", "Сидоров", "Кузнецов", "Соловьев" };
            var companyNames = new List<string>() { "Кондитерская №1" };

            var usedNames = new List<string>();

            var directorEmployees = new List<Employee>();
            var seniorEmployees = new List<Employee>();
            var juniorEmployees = new List<Employee>();


            for (int i = 0; i < count; i++)
            {
                string newName;
                do
                {
                    newName = string.Format("{0} {1}", firstNames[rnd.Next(firstNames.Count)], lastNames[rnd.Next(lastNames.Count)]);
                } while (usedNames.Contains(newName));
                usedNames.Add(newName);
                PostEnum postEnum = (PostEnum)rnd.Next(1, Enum.GetValues(typeof(PostEnum)).Length + 1);

                var employee = new Employee(newName)
                {
                    Salary = Math.Round(rnd.NextDouble() * 2000 + 1000, 2),
                    Name = newName,
                    Age = rnd.Next(18, 100),
                    CompanyName = companyNames[rnd.Next(companyNames.Count)],
                    Post = postEnum

                };

                var directors = director.Directors;

                switch (postEnum)
                {
                    case PostEnum.Director:
                        
                        directorName = employee.Name;
                        directors.Add(director);
                        break;
                    case PostEnum.SeniorEmployee:
                        seniorEmployees.Add(employee);
                        seniorName = employee.Name;
                        break;
                    case PostEnum.JuniorEmployee:
                        juniorEmployees.Add(employee);
                        juniorName = employee.Name;
                        break;
                    default:
                        break;
                }


                employees.Add(employee);

            }

            
        }
        public void PrintEmployees()
        {
            Console.WriteLine("{0,-20} {1,-10} {2,-20} {3,-20} {4,-10}", "ФИО", "Возраст", "Должность", "Зарплата", "Компания");
            foreach (var employee in employees)
            {
                Console.WriteLine("{0,-20} {1,-10} {2,-20} {3,-20} {4,-10}", employee.Name, employee.Age, employee.Post, employee.Salary, employee.CompanyName);
            }
            Console.WriteLine();
        }
       
        public void PrintEmployeesWithPost(int post)
        {

            var filteredEmployees = employees.Where(e => (int)e.Post == post).OrderByDescending(e => e.Name);
            Console.WriteLine("{0,-20} {1,-10} {2,-20} {3,-20} {4,-10}", "ФИО", "Возраст", "Должность", "Зарплата", "Компания");
            foreach (var employee in filteredEmployees)
            {
                Console.WriteLine("{0,-20} {1,-10} {2,-20} {3,-20} {4,-10}", employee.Name, employee.Age, employee.Post, employee.Salary, employee.CompanyName);
            }
            Console.WriteLine();
        }

        public void RemoveEmployee()
        {
            var employeeToRemove = employees.OrderBy(e => e.Salary).First();
            employees.Remove(employeeToRemove);
            Console.WriteLine("Удаленный сотрудник:");
            Console.WriteLine(employeeToRemove.Name);
        }

        public void GreetJuniorEmployees()
        {
            JuniorEmployee juniorEmployee = new JuniorEmployee(juniorName); 
            juniorEmployee.Hello();
        }

        public void GreetDirector()
        {
            Director director = new Director(directorName);
            director = employees.OfType<Director>().FirstOrDefault();

            director.Hello();
        }

        public void GreetSeniorEmployees()
        {
            SeniorEmployee seniorEmployee = new SeniorEmployee(seniorName); 
            seniorEmployee.Hello();
        }
    }
}

