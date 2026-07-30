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
        private List<Employee> employees = new List<Employee>();
        private Dictionary<int, Department> departments = new Dictionary<int, Department>();
        private Queue<Employee> onboardingQueue = new Queue<Employee>();
        private Stack<string> actionHistory = new Stack<string>();
        private HashSet<string> skills = new HashSet<string>();

        

        public void AddDepartment(Department department)
        {
            if (departments.ContainsKey(department.Id))
            {
                Console.WriteLine("Department with this ID already exists.");
                return;
            }
            departments[department.Id] = department;
            actionHistory.Push($"Added department: {department.Name}");
            Console.WriteLine($"Department {department.Name} added successfully.");
        }

        public void AddOnboardingEmployee(Employee employee)
        {
            if (IsEmployeeExists(employee.Id) || IsEmployeeExistsInOnboardingQueue(employee.Id))
                return;
            onboardingQueue.Enqueue(employee);
            actionHistory.Push($"Added onboarding employee: {employee.Name}");
            Console.WriteLine("Employee added to onboarding queue successfully.");
        }


        public void ProcessOnboarding()
        {
            if (onboardingQueue.Count == 0)
            {
                Console.WriteLine("No employees in the onboarding queue.");
                return;
            }

            Employee employee = onboardingQueue.Dequeue();
            AddEmployee(employee);
            actionHistory.Push($"Processed onboarding for employee: {employee.Name}");
            Console.WriteLine($"Employee {employee.Name} has been onboarded successfully.");
        }

        // Helper Methods
        private void AddEmployee(Employee employee)
        {
            if (IsEmployeeExists(employee.Id))
                return;
            employees.Add(employee);
            actionHistory.Push($"Added employee: {employee.Name}");
            Console.WriteLine("Employee added successfully.");
        }

        private bool IsEmployeeExists(int employeeId)
        {
            foreach (var e in employees)
            {
                if (e.Id == employeeId)
                {
                    Console.WriteLine($"Employee {employeeId} is already in the employee list.");
                    return true;
                }
            }
            return false;
        }

        private bool IsEmployeeExistsInOnboardingQueue(int employeeId)
        {
            foreach (var e in onboardingQueue)
            {
                if (e.Id == employeeId)
                {
                    Console.WriteLine($"Employee {employeeId} is already in the onboarding queue.");
                    return true;
                }
            }
            return false;
        }
    }
}
