using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project11
{
    public class DisplayData
    {
        private const string FruitsFilePath = @"C:\Users\Acer\source\Project11\Fruits_base.json";
        private const string EmployeesFilePath = @"C:\Users\Acer\source\Project11\employeeData.json";

        public static void DisplayFruits()
        {
            try
            {
                List<Fruit> fruits = ReadFruitsFromFile(FruitsFilePath);

                Console.WriteLine("===== Fruits Data =====");
                foreach (var fruit in fruits)
                {
                    Console.WriteLine($"Name: {fruit.Name}, Quantity: {fruit.Quantity}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error displaying fruits: {ex.Message}");
            }
        }

        public static void DisplayEmployees()
        {
            try
            {
                List<Employee> employees = ReadEmployeesFromFile(EmployeesFilePath);

                Console.WriteLine("===== Employees Data =====");
                foreach (var employee in employees)
                {
                    Console.WriteLine($"Name: {employee.Name}, Surname: {employee.Surname}, Login: {employee.Login}, Password: {employee.Password}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error displaying employees: {ex.Message}");
            }
        }

        private static List<Fruit> ReadFruitsFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Fruit>>(jsonContent) ?? new List<Fruit>();
            }
            return new List<Fruit>();
        }

        private static List<Employee> ReadEmployeesFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Employee>>(jsonContent) ?? new List<Employee>();
            }
            return new List<Employee>();
        }
    }
}