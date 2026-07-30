using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System.Models
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
        public double Salary { get; set; }
        public int DepartmentId { get; set; }
        public List<string> skills = new List<string>();

        private static int nextId = 1;

        public Employee()
        {
            Id = nextId++;
        }

        public Employee(int id, string name, DateTime hireDate, double salary, int departmentId)
        {
            Id = nextId++;
            Name = name;
            HireDate = hireDate;
            Salary = salary;
            DepartmentId = departmentId;
        }

    }
}
