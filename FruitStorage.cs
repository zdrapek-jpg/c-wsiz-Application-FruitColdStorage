using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace Project11
{
        public class ToDoFruitColdStorage: Add_Employee
        {
            private List<Fruit> fruits;
            private List<Employee> employees;
            private Employee loggedInUser;
            private Loging loging;

            public ToDoFruitColdStorage()
            {
                fruits = new List<Fruit>();
                employees = new List<Employee>();
                loggedInUser = null;
            }

            public bool Login(string username, string password)
            {
                Employee employee = employees.Find(e => e.Login == username && e.Password == password);
                if (employee != null)
                {
                    loggedInUser = employee;
                    Console.WriteLine($"Logged in as '{username}'.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid username or password.");
                    return false;
                }
            }

            public void DisplayMenu()
            {
                Console.WriteLine("\n===== Fruit Cold Storage Management System =====");
                Console.WriteLine("1. Add Fruit");
                Console.WriteLine("2. Remove Fruit");
                Console.WriteLine("3. Add Employee");
                Console.WriteLine("4. Login");
                Console.WriteLine("5. Display  all Data");

            Console.WriteLine("0. Exit");
            }

            public void Run()
            {
                while (true)
                {
                    DisplayMenu();
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                    case "1":
                        // Utilize the ManageFruits class to add or update fruits
                        ToDoWithFruits.DodajOwoce();
                        break;

                    case "2":
                        // Utilize the ManageFruits class to remove or update fruits
                        ToDoWithFruits.UsunOwoce();
                        break;

                    case "3":
                        Console.Write("Enter employee name: ");
                        string employeeName = Console.ReadLine();
                        Console.Write("Enter employee surname: ");
                        string employeeSurname = Console.ReadLine();
                        Console.Write("Enter employee login: ");
                        string employeeLogin = Console.ReadLine();
                        Console.Write("Enter employee password: ");
                        string employeePassword = Console.ReadLine();

                        // Add employee to the system
                        AddEmployee(employeeName, employeeSurname, employeeLogin, employeePassword);
                        break;
                    case "4":
                        if (loggedInUser == null)
                        {
                            // Get credentials using the Login class
                            var credentials = Loging.GetCredentials();
                            string loginUsername = credentials.Item1;
                            string loginPassword = credentials.Item2;

                            // Check if the entered credentials exist in the file
                            if (Loging.CheckCredentials(loginUsername, loginPassword))
                            {
                                Console.WriteLine("Login successful!");   
                            }
                            else
                            {
                                Console.WriteLine("Invalid username or password. Login failed.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Already logged in.");
                        }
                        break;

                    
                    case "5":
                        // Utilize the Displayed class to display fruits and employees data
                        DisplayData.DisplayFruits();
                        DisplayData.DisplayEmployees();
                        break;

                    case "0":
                            Console.WriteLine("Exiting the program. Goodbye!");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }


}
