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

        public void AddOnboardingEmployee(Employee employee)
        {
            if (IsEmployeeExists(employee.Id) || IsEmployeeExistsInOnboardingQueue(employee.Id))
                return;
            onboardingQueue.Enqueue(employee);
            actionHistory.Push($"Added onboarding employee: {employee.Name}");
            Console.WriteLine("Employee added to onboarding queue successfully.");
        }

        public void ProcessOnboarding(double salary,int departmentId)
        {
            if (onboardingQueue.Count == 0)
            {
                Console.WriteLine("No employees in the onboarding queue.");
                return;
            }

            Employee employee = onboardingQueue.Dequeue();
            employee.Salary = salary;
            employee.DepartmentId = departmentId;
            AddEmployee(employee);
            foreach (var skill in employee.skills)
            {
                skills.Add(skill);
                actionHistory.Push($"Added skill: {skill} for employee: {employee.Name}");
            }
            actionHistory.Push($"Processed onboarding for employee: {employee.Name}");
            Console.WriteLine($"Employee {employee.Name} has been onboarded successfully.");
        }

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

        public void addSkillForEmployee(int employeeId, string skill)
        {
            Employee employee = GetEmployeeById(employeeId);
            if (employee != null)
            {
                employee.skills.Add(skill);
                skills.Add(skill);
                actionHistory.Push($"Added skill: {skill} for employee: {employee.Name}");
                Console.WriteLine($"Skill {skill} added for employee {employee.Name}.");
            }
        }

        public Employee GetEmployeeById(int employeeId)
        {
            foreach (var employee in employees)
            {
                if (employee.Id == employeeId)
                {
                    return employee;
                }
            }
            Console.WriteLine($"Employee with ID {employeeId} not found.");
            return null;
        }

        public void GetEmployeeByDepartmentId(int departmentId)
        {
            Department department = GetDepartmentById(departmentId);
            if (department == null)
                return;

            foreach (var employee in employees)
            {
                if (employee.DepartmentId == departmentId)
                {
                    Console.WriteLine($"Employee ID: {employee.Id}, Name: {employee.Name}, Hire Date: {employee.HireDate.ToShortDateString()}, Salary: {employee.Salary}");
                }
            }
        }

        public double CalculateAverageSalary()
        {
            double sum = 0;
            foreach (var employee in employees)
                sum+=employee.Salary;
            return sum/employees.Count;
        }

        public void GetEmployeeCountForEachDepartment()
        {
            foreach(var d in departments)
            {
                int count = 0;
                foreach (var e in employees)
                    if (e.DepartmentId == d.Key)
                        count++;
                Console.WriteLine($"Employee Count for Department {d.Value.Name} is {count}");
            }
        }

        public Department GetDepartmentById(int departmentId)
        {
            if (departments.TryGetValue(departmentId, out Department department))
            {
                Console.WriteLine("Department ID: {0}, Name: {1}", department.Id, department.Name);
                return department;
            }
            Console.WriteLine($"Department with ID {departmentId} not found.");
            return null;
        }


        public void GetEmployeesByName(string name)
        {
            foreach (var employee in this.employees)
            {
                if (employee.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Employee ID: {employee.Id}, Name: {employee.Name}, Hire Date: {employee.HireDate.ToShortDateString()}, Salary: {employee.Salary}, Department ID: {employee.DepartmentId}");
                }
            }
            if (employees.Count == 0)
                Console.WriteLine("No employees found with the name: " + name);
        }

        public void ShowActionHistory()
        {
            Console.WriteLine("Action History:");
            foreach (var action in actionHistory)
            {
                Console.WriteLine(action);
            }
        }

        public void ShowUniqeSkills()
        {
            Console.WriteLine("Unique Skills:");
            foreach (var skill in skills)
            {
                Console.WriteLine(skill);
            }
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
