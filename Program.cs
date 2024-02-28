using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
namespace Project11
{
    
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Witamy! porszę się zalogować: ");
            Tuple<string, string> credentials = Loging.GetCredentials();

            ToDoFruitColdStorage coldStorage = new ToDoFruitColdStorage();

            coldStorage.Run();
        }
    }

}