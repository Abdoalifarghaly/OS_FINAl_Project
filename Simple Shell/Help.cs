using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_Shell
{
    class HELP
    {
        public static void Help(Token token)
        {
            if (token.value == null)
            {
                Console.WriteLine("cd       - Change the current default directory to .");
                Console.WriteLine("           If the argument is not present, report the current directory.");
                Console.WriteLine("           If the directory does not exist an appropriate error should be reported.");
                Console.WriteLine("cls      - Clear the screen.");
                Console.WriteLine("dir      - List the contents of directory .");
                Console.WriteLine("quit     - Quit the shell.");
                Console.WriteLine("copy     - Copies one or more files to another location");
                Console.WriteLine("del      - Deletes one or more files.");
                Console.WriteLine("help     - Provides Help information for commands.");
                Console.WriteLine("md       - Creates a directory.");
                Console.WriteLine("rd       - Removes a directory.");
                Console.WriteLine("rename   - Renames a file.");
                Console.WriteLine("type     - Displays the contents of a text file.");
                Console.WriteLine("import   – import text file(s) from your computer");
                Console.WriteLine("export   – export text file(s) to your computer");
            }
            else
            {
                if(token.value=="cd")
                {
                    Console.WriteLine("Change the current default directory to the directory given in the argument.");
                    Console.WriteLine("If the argument is not present, report the current directory.");
                    Console.WriteLine("If the directory does not exist an appropriate error should be reported.");
                    Console.WriteLine(token.value + " command syntax is \n cd \n or \n cd [directory]");
                    Console.WriteLine("[directory] can be directory name or fullpath of a directory");
                }
                else if (token.value == "cls")
                {
                    Console.WriteLine("Clear the screen.");
                    Console.WriteLine(token.value + " command syntax is \n cls");
                }
                else if(token.value == "dir")
                {
                    Console.WriteLine("List the contents of directory given in the argument.");
                    Console.WriteLine("If the argument is not present, list the content of the current directory.");
                    Console.WriteLine("If the directory does not exist an appropriate error should be reported.");
                    Console.WriteLine(token.value + " command syntax is \n dir \n or \n dir [directory]");
                    Console.WriteLine("[directory] can be directory name or fullpath of a directory");
                }
                else if (token.value == "quit")
                {
                    Console.WriteLine("Quit the shell.");
                    Console.WriteLine(token.value + " command syntax is \n quit");
                }
                else if(token.value == "copy")
                {
                    Console.WriteLine("Copies one or more files to another location.");
                    Console.WriteLine(token.value + " command syntax is \n copy [source]+ [destination]");
                    Console.WriteLine("+ after [source] represent that you can pass more than file Name (or fullpath of file) or more than directory Name (or fullpath of directory)");
                    Console.WriteLine("[source] can be file Name (or fullpath of file) or directory Name (or fullpath of directory)");
                    Console.WriteLine("[destination] can be directory name or fullpath of a directory");

                }
                else if (token.value == "del")
                {
                    Console.WriteLine("Deletes one or more files.");
                    Console.WriteLine("NOTE: it confirms the user choice to delete the file before deleting");
                    Console.WriteLine(token.value + " command syntax is \n del [file]+");
                    Console.WriteLine("+ after [file] represent that you can pass more than file Name (or fullpath of file)");
                    Console.WriteLine("[file] can be file Name (or fullpath of file)");
                }
                else if (token.value == "help")
                {
                    Console.WriteLine("Provides Help information for commands.");
                    Console.WriteLine(token.value + " command syntax is \n help \n or \n For more information on a specific command, type help [command]");
                    Console.WriteLine("command - displays help information on that command.");
                }
                else if(token.value == "md")
                {
                    Console.WriteLine("Creates a directory.");
                    Console.WriteLine(token.value + " command syntax is \n md [directory]");
                    Console.WriteLine("[directory] can be a new directory name or fullpath of a new directory");
                }
                else  if (token.value == "rd")
                {
                    Console.WriteLine("Removes a directory.");
                    Console.WriteLine("NOTE: it confirms the user choice to delete the directory before deleting");
                    Console.WriteLine(token.value + " command syntax is \n rd [directory]");
                    Console.WriteLine("[directory] can be a directory name or fullpath of a directory");
                }
                else if (token.value == "rename")
                {
                    Console.WriteLine("Renames a file.");
                    Console.WriteLine(token.value + " command syntax is \n rd [fileName] [new fileName]");
                    Console.WriteLine("[fileName] can be a file name or fullpath of a filename ");
                    Console.WriteLine("[new fileName] can be a new file name not fullpath ");
                }
                else if (token.value == "type")
                {
                    Console.WriteLine("Displays the contents of a text file.");
                    Console.WriteLine(token.value + " command syntax is \n type [file]");
                    Console.WriteLine("NOTE: it displays the filename before its content for every file");
                    Console.WriteLine("[file] can be file Name (or fullpath of file) of text file");
                }
                else if (token.value == "import")
                {
                    Console.WriteLine("– import text file(s) from your computer ");
                    Console.WriteLine(token.value + " command syntax is \n import [destination] [file]+");
                    Console.WriteLine("+ after [file] represent that you can pass more than file Name (or fullpath of file) of text file");
                    Console.WriteLine("[file] can be file Name (or fullpath of file) of text file");
                    Console.WriteLine("[destination] can be directory name or fullpath of a directory in your implemented file system");
                }
                else if (token.value == "export")
                {

                    Console.WriteLine("– export text file(s) to your computer ");
                    Console.WriteLine(token.value + " command syntax is \n export [destination] [file]+");
                    Console.WriteLine("+ after [file] represent that you can pass more than file Name (or fullpath of file) of text file");
                    Console.WriteLine("[file] can be file Name (or fullpath of file) of text file in your implemented file system");
                    Console.WriteLine("[destination] can be directory name or fullpath of a directory in your computer");
                }
                else
                {
                    Console.WriteLine("Error: " + token.value + " => This command is not supported by the help utility.");
                }
            }
        }
        public static void CD(string path)
        {
            Directory dir = moveTodir(path, true, false);
            if (dir != null)
            {
                dir.ReadDirectory();
                Program.current = dir;
            }
            else
            {
                Console.WriteLine($"Eroor : path {path} is not exists!");
            }
        }
        public static void moveToDirUsedInAnother(string path)
        {
            Directory dir = moveTodir(path, false, false);
            if (dir != null)
            {
                dir.ReadDirectory();
                Program.current = dir;
            }
            else
            {
                Console.WriteLine("the system cannot find the specified folder.!");
            }
        }
        private static Directory moveTodir(string p, bool usedInCD, bool isUsedInRD)
        {
            Directory d = null;
            string[] arr = p.Split('\\');
            string path;
            if (arr.Length == 1)
            {
                if (arr[0] != "..")
                {
                    int i = Program.current.searchDirectory(arr[0]);
                    if (i == -1)
                        return null;
                    else
                    {
                        string nameOfDiserableFolder = new string(Program.current.entries[i].dir_name);
                        byte attr = Program.current.entries[i].dir_attr;
                        int fisrtcluster = Program.current.entries[i].firs_cluster;
                        d = new Directory(nameOfDiserableFolder, attr, fisrtcluster, Program.current);
                        path = Program.currentPath;
                        path += "\\" + nameOfDiserableFolder.Trim();
                        if (usedInCD)
                            Program.currentPath = path;
                    }
                }
            }
            else if (arr.Length > 1)
            {
                List<string> ListOfHandledPath = new List<string>();
                for (int i = 0; i < arr.Length; i++)
                    if (arr[i] != "")
                        ListOfHandledPath.Add(arr[i]);
                Directory rootDirectory = new Directory("A:", 0x10, 5, null);
                rootDirectory.ReadDirectory();
                if (ListOfHandledPath[0].Equals("a:") || ListOfHandledPath[0].Equals("A:"))
                {
                    path = "A:";
                    int howLongIsMyWay;
                    if (isUsedInRD || usedInCD)
                    {
                        howLongIsMyWay = ListOfHandledPath.Count;
                    }
                    else
                    {
                        howLongIsMyWay = ListOfHandledPath.Count - 1;
                    }
                    for (int i = 1; i < howLongIsMyWay; i++)
                    {
                        int j = rootDirectory.searchDirectory(ListOfHandledPath[i]);
                        if (j != -1)
                        {
                            Directory tempOfParent = rootDirectory;
                            string newName = new string(rootDirectory.entries[j].dir_name);
                            byte attr = rootDirectory.entries[j].dir_attr;
                            int fc = rootDirectory.entries[j].firs_cluster;
                            rootDirectory = new Directory(newName, attr, fc, tempOfParent);
                            rootDirectory.ReadDirectory();
                            path += "\\" + newName.Trim(new char[] { '\0', ' ' });
                        }
                        else
                        {
                            return null;
                        }
                    }
                    d = rootDirectory;
                    if (usedInCD)
                        Program.currentPath = path;
                }
                else
                    return null;
            }
            return d;
        }
        public static void MD(string name)
        {
            string[] arr = name.Split('\\');
            if (arr.Length == 1)
            {
                if (Program.current.searchDirectory(arr[0]) == -1)
                {
                    DirectoryEntry d = new DirectoryEntry(arr[0], 0x10, 0, 0);

                    if (FAT.GetEmptyCulster() != -1)
                    {
                        Program.current.entries.Add(d);
                        Program.current.WriteDirectory();
                        if (Program.current.parent != null)
                        {
                            Program.current.parent.updateContent(Program.current.getDirectoryEntry());
                            Program.current.parent.WriteDirectory();
                        }
                        FAT.writeFat();
                    }
                    else
                        Console.WriteLine("The Disk is Full .");
                }
                else
                    Console.WriteLine($"{arr[0]} is aready existed .");
            }
            else if (arr.Length > 1)
            {
                Directory dir = moveTodir(name, false, false);
                if (dir == null)
                    Console.WriteLine($"The Path {name} Is not exist");
                else
                {
                    if (FAT.GetEmptyCulster() != -1)
                    {

                        DirectoryEntry d = new DirectoryEntry(arr[arr.Length - 1], 0x10, 0, 0);
                        dir.entries.Add(d);
                        dir.WriteDirectory();
                        dir.parent.updateContent(dir.getDirectoryEntry());
                        dir.parent.WriteDirectory();
                        FAT.writeFat();
                    }
                    else
                        Console.WriteLine("The Disk is Full .");
                }
            }
        }
        public static void dir()
        {
            int fc = 0, dc = 0, fz_sum = 0;
            Console.WriteLine("Directory of " + Program.currentPath);
            Console.WriteLine();
            for (int i = 0; i < Program.current.entries.Count; i++)
            {
                if (Program.current.entries[i].dir_attr == 0x0)
                {
                    Console.WriteLine($"\t{Program.current.entries[i].dir_fileSize} \t {new string(Program.current.entries[i].dir_name)}");
                    fc++;
                    fz_sum += Program.current.entries[i].dir_fileSize;
                }
                else if (Program.current.entries[i].dir_attr == 0x10)
                {
                    Console.WriteLine($"\t<DIR> {new string(Program.current.entries[i].dir_name)}");
                    dc++;
                }
            }
            Console.WriteLine($"{"\t\t"}{fc} File(s)    {fz_sum} bytes");
            Console.WriteLine($"{"\t\t"}{dc} Dir(s)    {VirtualDisk.getFreeSpace()} bytes free");
        }
        public static void RD(string name)
        {
            string[] arr = name.Split('\\');
            Directory dir = moveTodir(name, false, true);
            if (dir != null)
            {
                Console.Write($"Are you sure that you want to delete {new string(dir.dir_name).Trim()} , please enter Y for yes or N for no:");
                string choice = Console.ReadLine().ToLower();
                if (choice.Equals("y"))
                {
                    dir.deleteDirectory();
                }
            }
            else
            {
                Console.WriteLine($"directory \" {arr[arr.Length - 1]} \" is not exists!");
            }
        }
        public static void import(string dest)
        {
            if (File.Exists(dest))
            {
                string content = File.ReadAllText(dest);
                int size = content.Length;
                string[] names = dest.Split("\\");
                string name = names[names.Length - 1];
                int j = Program.current.searchDirectory(name);
                if (j == -1)
                {
                    int fc;
                    if (size > 0)
                    {
                        fc = FAT.GetEmptyCulster();
                    }
                    else
                    {
                        fc = 0;
                    }
                    FILE newFile = new FILE(name, 0X0, fc, Program.current, content, size);
                    newFile.writeFile();
                    //FAT.writeFat();
                    DirectoryEntry d = new DirectoryEntry(new string(name), 0X0, fc, size);
                    Program.current.entries.Add(d);
                    Program.current.WriteDirectory();
                }
                else
                {
                    Console.WriteLine($"{name} is already exist in your virtual disk");
                }
            }
            else
            {
                Console.WriteLine("The file you specified does not exist in your compuret");
            }
        }
        public static void type(string name)
        {
            string[] path = name.Split("\\");
            if (path.Length > 1)
            {
                for (int i = 1; i < path.Length - 1; i++)
                {
                    moveToDirUsedInAnother(path[i]);
                }
                name = path[path.Length - 1];
            }
            int j = Program.current.searchDirectory(name);
            if (j != -1)
            {
                int fc = Program.current.entries[j].firs_cluster;
                int sz = Program.current.entries[j].dir_fileSize;
                string content = null;
                FILE file = new FILE(name, 0x0, fc, Program.current, content, sz);
                file.ReadFile();
                Console.WriteLine(file.content);
            }
            else
            {
                Console.WriteLine("The System could not found the file specified");
            }
            Directory rootDirectory = new Directory("M:", 0x10, 5, null);
            Program.current = rootDirectory;
            Program.current.ReadDirectory();
        }
        public static void export(string source, string dest)
        {
            string[] path = source.Split("\\");
            if (path.Length > 1)
            {
                for (int i = 1; i < path.Length - 1; i++)
                {
                    moveToDirUsedInAnother(path[i]);
                }

                source = path[path.Length - 1];
            }
            int j = Program.current.searchDirectory(source);
            if (j != -1)
            {
                if (System.IO.Directory.Exists(dest))
                {
                    int fc = Program.current.entries[j].firs_cluster;
                    int sz = Program.current.entries[j].dir_fileSize;
                    string content = null;
                    FILE file = new FILE(source, 0x0, fc, Program.current, content, sz);
                    file.ReadFile();
                    StreamWriter sw = new StreamWriter(dest + "\\" + source);
                    sw.Write(file.content);
                    sw.Flush();
                    sw.Close();
                }
                else
                {
                    Console.WriteLine("The system cannot find the path specified in hte coputer dis");
                }
            }
            else
            {
                Console.WriteLine("The system cannot find the file you want to export in the virtual disk");
            }
            Directory rootDirectory = new Directory("M:", 0x10, 5, null);
            Program.current = rootDirectory;
            Program.current.ReadDirectory();
        }
        public static void rename(string oldName, string newName)
        {
            string[] path = oldName.Split("\\");
            if (path.Length > 1)
            {
                for (int i = 1; i < path.Length - 1; i++)
                {
                    moveToDirUsedInAnother(path[i]);
                }
                oldName = path[path.Length - 1];
            }
           int j = Program.current.searchDirectory(oldName);
            if (j != -1)
            {
                if (Program.current.searchDirectory(newName) == -1)
                {
                    DirectoryEntry d = Program.current.entries[j];
                    if (d.dir_attr == 0x0)
                    {
                        string[] fileName = newName.Split('.');
                        char[] goodName = DirectoryEntry.HandleFileName(fileName[0].ToCharArray(), fileName[1].ToCharArray());
                        d.dir_name = goodName;
                    }
                    else if (d.dir_attr == 0x10)
                    {
                        char[] goodName = DirectoryEntry.HandleDirName(newName.ToCharArray());
                        d.dir_name = goodName;
                    }
                    Program.current.entries.RemoveAt(j);
                    Program.current.entries.Insert(j, d);
                    Program.current.WriteDirectory();
                }
                else
                {
                    Console.WriteLine("Doublicate File Name exist or file cannot be found");
                }
            }
            else
            {
                Console.WriteLine("The System Cannot Find the File specified");
            }

            Directory rootDirectory = new Directory("M:", 0x10, 5, null);
            Program.current = rootDirectory;
            Program.current.ReadDirectory();
        }  
        public static void del(string fileName)
        {
            string[] path = fileName.Split("\\");
            if (path.Length > 1)
            {
                for (int i = 1; i < path.Length - 1; i++)
                {
                    moveToDirUsedInAnother(path[i]);
                }
                fileName = path[path.Length - 1];
            }
            int j = Program.current.searchDirectory(fileName);
            if (j != -1)
            {
                if (Program.current.entries[j].dir_attr == 0x0)
                {
                    int fc = Program.current.entries[j].firs_cluster;
                    int sz = Program.current.entries[j].dir_fileSize;
                    FILE file = new FILE(fileName, 0x0, fc, Program.current, null, sz);
                    file.deleteFile();
                }
                else
                {
                    Console.WriteLine("The System Cannot Find The file specified");
                }
            }
            else
            {
                Console.WriteLine("The System Cannot Find The file specified");
            }
            Directory rootDirectory = new Directory("M:", 0x10, 5, null);
            Program.current = rootDirectory;
            Program.current.ReadDirectory();
        }
        public static void copy(string source, string dest)
        {
            int j = Program.current.searchDirectory(source), fc, sz;
            if (source == dest)
            {
                Console.WriteLine("the file cannot be copied onto itself");
                return;
            }
            if (j != -1)
            {
                fc = Program.current.entries[j].firs_cluster;
                sz = Program.current.entries[j].dir_fileSize;
                string[] myWay = dest.Split("\\");
                for (int i = 1; i < myWay.Length; i++)
                {
                    moveToDirUsedInAnother(myWay[i]);
                }
                int x = Program.current.searchDirectory(source);
                if (x != -1)
                {
                    Console.Write("The File is aleary existed, Do you want to overwrite it ?, please enter Y for yes or N for no:");
                    string choice = Console.ReadLine().ToLower();
                    if (choice.Equals("y"))
                    {
                        DirectoryEntry d = new DirectoryEntry(new string(source), 0X0, fc, sz);
                        Program.current.entries.Add(d);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    DirectoryEntry d = new DirectoryEntry(new string(source), 0X0, fc, sz);
                    Program.current.entries.Add(d);
                    Program.current.WriteDirectory();
                }
                Directory rootDirectory = new Directory("M:", 0x10, 5, null);
                Program.current = rootDirectory;
                Program.current.ReadDirectory();
            }
            else
            {
                Console.WriteLine($"The File ${source} Is Not Existed In your disk");
            }
        }
    }
}
