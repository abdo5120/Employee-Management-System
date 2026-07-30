using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System.Models
{
    internal class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private static int nextId = 1;

        public Department()
        {
            Id = nextId++;
        }

        public Department(string name)
        {
            Id = nextId++;
            Name = name;
        }
    }
}
