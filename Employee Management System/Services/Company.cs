using Employee_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System.Services
{
    internal class Company
    {
        private List<Employee> Employees = new List<Employee>();
        private Dictionary<int, Department> Departments = new Dictionary<int, Department>();
        private Queue<Employee> onboardingQueue = new Queue<Employee>();
        private Stack<string> actionHistory = new Stack<string>();
        private HashSet<string> skills = new HashSet<string>();
    }
}
