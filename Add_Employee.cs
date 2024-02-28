using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project11
{
    public class Add_Employee
    {
        private const string EmployeesFilePath = @"C:\Users\Acer\source\Project11\employeeData.json";

        public static void AddEmployee(string name, string surname, string login, string password)
        {
            try
            {
                List<Dictionary<string, string>> employees = ReadEmployeesFromFile();

                // Utwórz słownik reprezentujący nowego pracownika
                var newEmployee = new Dictionary<string, string>
            {
                { "Name", name },
                { "Surname", surname },
                { "Login", login },
                { "Password", password }
            };

                // Dodaj nowego pracownika do listy
                employees.Add(newEmployee);

                // Zapisz listę słowników do pliku
                SaveEmployeesToFile(employees);

                Console.WriteLine($"Employee '{login}' added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding employee: {ex.Message}");
            }
        }

        private static List<Dictionary<string, string>> ReadEmployeesFromFile()
        {
            try
            {
                if (File.Exists(EmployeesFilePath))
                {
                    string jsonContent = File.ReadAllText(EmployeesFilePath);
                    return JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonContent) ?? new List<Dictionary<string, string>>();
                }

                Console.WriteLine($"File '{EmployeesFilePath}' does not exist.");
                return new List<Dictionary<string, string>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading employees from file: {ex.Message}");
                return new List<Dictionary<string, string>>();
            }
        }

        private static void SaveEmployeesToFile(List<Dictionary<string, string>> employees)
        {
            try
            {
                // Zapisz listę słowników do pliku
                string jsonContent = JsonConvert.SerializeObject(employees, Formatting.Indented);
                File.WriteAllText(EmployeesFilePath, jsonContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving employees to file: {ex.Message}");
            }
        }
    }
}
