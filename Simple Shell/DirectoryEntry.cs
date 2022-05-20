using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_Shell
{
    internal class DirectoryEntry
    {
        public char[] dir_name = new char[11];
        public byte dir_attr;
        public byte[] dir_empty = new byte[12];
        public int firs_cluster;
        public int dir_fileSize;
        public DirectoryEntry(string name, byte attr, int fcluster,int fileSize)
        {
            dir_attr = attr;
            firs_cluster = fcluster;
            this.dir_fileSize = fileSize;  
            if (attr == 0X0)
            {
                string[] fileName = name.Split('.');
                this.dir_name = HandleFileName(fileName[0].ToCharArray(), fileName[1].ToCharArray());
            }
            else if (attr == 0x10)
            {
                this.dir_name= HandleDirName(name.ToCharArray());
            }
        }
        public static char[] HandleFileName(char[] fname, char[] extension)
        {
            char[] dir_name = new char[11];

            int length = fname.Length, count = 0, lenOfEx = extension.Length;
            if (fname.Length >= 7)
            {
                for (int i = 0; i < 7; i++)
                {
                    dir_name[count] = fname[i];
                    count++;
                }
                dir_name[count] = '.';
                count++;
            }
            else if (length < 7)
            {
                for (int i = 0; i < length; i++)
                {
                    dir_name[count] = fname[i];
                    count++;
                }
                for (int i = 0; i < 7 - length; i++)
                {
                    dir_name[count] = '_';
                    count++;
                }
                dir_name[count] = '.';
                count++;
            }
            for (int i = 0; i < lenOfEx; i++)
            {
                dir_name[count] = extension[i];
                count++;
            }
            for (int i = 0; i < 3 - lenOfEx; i++)
            {
                dir_name[count] = ' ';
                count++;
            }
            return dir_name;
        }
        public static char[] HandleDirName(char[] name)
        {
            char[] dir_name = new char[11];

            if (name.Length <= 11)
            {
                int j = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    j++;
                    dir_name[i] = name[i];
                }
                for (int i = ++j; i < dir_name.Length; i++)
                {
                    dir_name[i] = ' ';
                }
            }
            else
            {
                int j = 0;
                for (int i = 0; i < 11; i++)
                {
                    j++;
                    dir_name[i] = name[i];
                }
            }
            return dir_name;
        }
    }
}
