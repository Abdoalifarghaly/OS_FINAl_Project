using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_Shell
{
    public struct Token
    {
        public string command;
        public string value;
        public string sec_value;
    }
    class Parser
    {
        public void parse_input(string str)
        {
            Token token = new Token();
            var argument = str.Split(' ');
            if (argument.Length == 1)
            {
                token.command = argument[0];
                token.value = null;
                token.sec_value = null;
                Action(token);
            }
            else if (argument.Length == 2)
            {
                token.command = argument[0];
                token.value = argument[1];
                token.sec_value = null;
                Action(token);
            }
            else if (argument.Length == 3)
            {
                token.command = argument[0];
                token.value = argument[1];
                token.sec_value = argument[2];
                Action(token);
            }
        }
        void Action(Token token)
        {

            if (token.command == "cls")
            {
                Console.Clear();
            }

            else if (token.value == "quit")
            {
                Environment.Exit(0);
            }

            else if (token.command == "help")
            {
                HELP.Help(token);
            }

            else if (token.command == "cd")
            {
                if (token.value == null || token.value == ".")
                {
                    return;
                }
                else
                {
                    HELP.CD(token.value);
                }

            }

            else if (token.command == "md")
            {
                if (token.value == null)
                {
                    Console.WriteLine("ERROR,\n you shold specify folder name to make\n md[path]name");
                    return;
                }
                else
                {
                    HELP.MD(token.value);
                }
            }

            else if (token.command == "dir")
            {
                HELP.dir();
            }

            else if (token.command == "rd")
            {
                if (token.value == null)
                {
                    Console.WriteLine("ERROR,\n you shold specify folder name to delete\n rd[pah]Name");
                }
                else
                {
                    HELP.RD(token.value);
                }
            }

            else if (token.command == "import")
            {
                if (token.value == null)
                {
                    Console.WriteLine("ERROR\n, you shold specify File name to import\n import [dest]filename");
                }
                else
                {
                    HELP.import(token.value);
                }
            }

            else if (token.command == "type")
            {

                if (token.value == null || token.sec_value != null)
                {
                    Console.WriteLine("ERROR\n, you shold specify file name to show its contnet\n type [dest]filename");
                }
                else
                {
                    HELP.type(token.value);
                }
            }

            else if (token.command == "export")
            {

                if (token.value == null || token.sec_value == null)
                {
                    Console.WriteLine("ERROR,\n The Correct syntax is \n import   [Source File] [destination]\n");
                }
                else
                {
                    HELP.export(token.value, token.sec_value);
                }
            }

            else if (token.command == "rename")
            {

                if (token.value == null || token.sec_value == null)
                {
                    Console.WriteLine("ERROR,\n The Correct syntax is \n rename   [old name] [new name]\n");
                }
                else
                {
                    HELP.rename(token.value, token.sec_value);
                }
            }

            else if (token.command == "del")
            {
                if (token.value == null)
                {
                    Console.WriteLine("ERROR,\n The Correct syntax is \n del   [file name]\n");
                }
                else
                {
                    HELP.del(token.value);
                }
            }

            else if (token.command == "copy")
            {
                if (token.value == null || token.sec_value == null)
                {
                    Console.WriteLine("ERROR,\n The Correct syntax is \n copy   [Source File] [destination]\n");   
                }
                else
                {
                    HELP.copy(token.value, token.sec_value);
                }
            }
            else
            {
                Console.WriteLine(token.command + " is not recognized as an internal or external command,operable program or batch file.");

            }
        }
    }
}