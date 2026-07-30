using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System.Models
{
    internal class Manager : Employee
    {
        public List<Employee> TeamMembers = new List<Employee>();

        public Manager() : base()
        {
        }

        public Manager(int id, string name, DateTime hireDate, double salary, int departmentId): base(id, name, hireDate, salary, departmentId)
        {
        }
    }
}
