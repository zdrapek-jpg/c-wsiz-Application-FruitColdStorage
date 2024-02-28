using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project11
{
    public class Loging
    {
        public static Tuple<string, string> GetCredentials()
        {
            string username = "";
            string password = "";

            try
            {
                Console.Write("Enter your username: ");
                username = Console.ReadLine();

                Console.Write("Enter your password: ");
                password = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading credentials: {ex.Message}");
            }

            return Tuple.Create(username, password);
        }

        public static bool CheckCredentials(string username, string password)
        {
            string filePath = @"C:\Users\Acer\source\Project11\employeeData.json";

            try
            {
                // Read existing JSON data from the file
                string existingJsonData = File.ReadAllText(filePath);

                // Deserialize existing JSON data to a list of dictionaries
                var existingDataList = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(existingJsonData)
                                        ?? new List<Dictionary<string, string>>();

                // Check if the entered credentials match any record in the list
                return existingDataList.Any(employeeData =>
                    employeeData.TryGetValue("Login", out string storedUsername) &&
                    employeeData.TryGetValue("Password", out string storedPassword) &&
                    storedUsername == username &&
                    storedPassword == password);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking credentials: {ex.Message}");
                return false;
            }
        }

    }
}
