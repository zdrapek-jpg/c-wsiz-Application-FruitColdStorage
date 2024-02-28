using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Project11
{
    public class ToDoWithFruits
    {
        private const string FilePath = @"C:\Users\Acer\source\Project11\Fruits_base.json";

        public static void DodajOwoce()
        {
            try
            {
                Console.Write("Enter the fruit name: ");
                string fruitName = Console.ReadLine();

                Console.Write("Enter the fruit weight: ");
                double fruitWeight;
                if (double.TryParse(Console.ReadLine(), out fruitWeight))
                {
                    // Check if the fruit exists in the file
                    List<Fruit> fruits = ReadFruitsFromFile();
                    Fruit existingFruit = fruits.Find(fruit => fruit.Name == fruitName);

                    if (existingFruit != null)
                    {
                        // Fruit exists, increase the quantity
                        existingFruit.Quantity += fruitWeight;
                    }
                    else
                    {
                        // Fruit doesn't exist, add a new record
                        Fruit newFruit = new Fruit { Name = fruitName, Quantity = fruitWeight };
                        fruits.Add(newFruit);
                    }

                    // Save the updated list of fruits to the file
                    SaveFruitsToFile(fruits);

                    Console.WriteLine("Fruit added/updated successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid weight format. Please enter a numeric value.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding/updating fruits: {ex.Message}");
            }
        }
        public static void UsunOwoce()
        {
            try
            {
                Console.Write("Enter the fruit name: ");
                string fruitName = Console.ReadLine();

                // Check if the fruit exists in the file
                List<Fruit> fruits = ReadFruitsFromFile();
                Fruit existingFruit = fruits.Find(fruit => fruit.Name == fruitName);

                if (existingFruit != null)
                {
                    Console.Write($"Enter the quantity of '{fruitName}' to be removed: ");
                    double quantityToRemove;
                    if (double.TryParse(Console.ReadLine(), out quantityToRemove))
                    {
                        if (quantityToRemove >= existingFruit.Quantity)
                        {
                            // Remove the entire fruit
                            fruits.Remove(existingFruit);
                        }
                        else
                        {
                            // Subtract the specified quantity
                            existingFruit.Quantity -= quantityToRemove;
                        }

                        // Save the updated list of fruits to the file
                        SaveFruitsToFile(fruits);

                        Console.WriteLine("Fruit removed/updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity format. Please enter a numeric value.");
                    }
                }
                else
                {
                    Console.WriteLine($"The fruit '{fruitName}' does not exist in the file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing/updating fruits: {ex.Message}");
            }
        }

        private static List<Fruit> ReadFruitsFromFile()
        {
            if (File.Exists(FilePath))
            {
                string jsonContent = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<List<Fruit>>(jsonContent) ?? new List<Fruit>();
            }
            return new List<Fruit>();
        }

        private static void SaveFruitsToFile(List<Fruit> fruits)
        {
            string jsonContent = JsonConvert.SerializeObject(fruits, Formatting.Indented);
            File.WriteAllText(FilePath, jsonContent);
        }
    }
}
