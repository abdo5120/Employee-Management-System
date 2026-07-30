using Employee_Management_System.Models;
using Employee_Management_System.Services;
using System.Diagnostics;

namespace Employee_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();

            while (true)
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("        Employee Management System");
                Console.WriteLine("===========================================");

             
                Console.WriteLine("Choose number :");
                Console.WriteLine("1. Add Employee to Onboarding");
                Console.WriteLine("2. Process Onboarding");
                Console.WriteLine("3. Add Department");
                Console.WriteLine("4. Add Skill for Employee");
                Console.WriteLine("5. Search Employee using id");  
                Console.WriteLine("6. Search Employee using name");
                Console.WriteLine("7. Display Department's Employees");
                Console.WriteLine("8. Average Salary");
                Console.WriteLine("9. Report Employee Count For Each Department");
                Console.WriteLine("10. Show History");     
                Console.WriteLine("11. Show Skills");     
                Console.WriteLine("0. Exit");     
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                try
                {
                    switch (choice)
                    {
                        case 1:
                            Employee employee = new Employee();
                            Console.Write("Enter Employee Name: ");
                            employee.Name = Console.ReadLine();
                            while(true)
                            {
                                Console.Write("Enter his skills: ");
                                string skill = Console.ReadLine();
                                employee.skills.Add(skill);
                                Console.Write("Add more skills? (y/n): ");
                                char check = Convert.ToChar(Console.ReadLine());
                                if (check == 'n' || check == 'N')
                                    break;
                            }
                            company.AddOnboardingEmployee(employee);
                            break;
                        case 2:
                            Console.Write("Enter Employee Salary: ");
                            int salary = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Dpartment id: ");
                            int departmentId = Convert.ToInt32(Console.ReadLine());
                            company.ProcessOnboarding(salary,departmentId);
                            break;
                        case 3:                          
                            Console.Write("Enter Department Name: ");
                            string dapartmentName = Console.ReadLine();
                            company.AddDepartment(new Department { Name = dapartmentName });
                            break;
                        case 4:
                            Console.Write("Enter Employee Id : ");
                            int employeeId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter his skills: ");
                            string skill1 = Console.ReadLine();
                            company.addSkillForEmployee(employeeId, skill1);
                            break;
                        case 5:
                            Console.Write("Enter Employee Id :");
                            employeeId = Convert.ToInt32(Console.ReadLine());
                            employee = company.GetEmployeeById(employeeId);
                            Console.WriteLine($"Employee ID: {employee.Id}, Name: {employee.Name}, Hire Date: {employee.HireDate.ToShortDateString()}, Salary: {employee.Salary}, Department ID: {employee.DepartmentId}");
                            break;
                        case 6:
                            Console.Write("Enter Employee Name :");
                            string name1 = Console.ReadLine();
                            company.GetEmployeesByName(name1);
                            break;
                        case 7:
                            Console.Write("Enter Department Id :");
                            int departmentId1 = Convert.ToInt32(Console.ReadLine());
                            company.GetEmployeeByDepartmentId(departmentId1);
                            break;
                        case 8:
                            Console.WriteLine($"Avarage Salary = {company.CalculateAverageSalary()}");
                            break;
                        case 9:
                            company.GetEmployeeCountForEachDepartment();
                            break;
                        case 10:
                            company.ShowActionHistory();
                            break;
                        case 11:
                            company.ShowUniqeSkills();
                            break;
                        case 0:
                            Console.WriteLine("Exiting the program...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                Console.ReadKey();
                Console.Clear();



            }
        }
    }
}
