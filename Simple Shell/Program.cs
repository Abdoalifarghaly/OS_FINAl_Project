using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_Shell
{
    class Program
    {
        public static string PATH_ON_PC = "miniFat.txt";
        public static Directory current;
        public static string currentPath;
        static void Main(string[] args)
        {
     
            VirtualDisk.initialize(PATH_ON_PC);

            currentPath = new string(current.dir_name);
            currentPath = currentPath.Trim(new char[] { '\0', ' ' });
            Parser parser = new Parser();
            while (true)
            {
                var currentLocation = currentPath;
                Console.Write(currentLocation + "\\>");
                current.ReadDirectory();

                string input = Console.ReadLine();
                parser.parse_input(input);
            }
        }
    }
}
