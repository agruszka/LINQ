using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleLinqToObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Windows\";
            GetFilesNamesAndSizeWithoutLinq(path);
            Console.ReadLine();
        }
        private static void GetFilesNamesAndSizeWithoutLinq(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            var filesInfo = directoryInfo.GetFiles();
            Array.Sort(filesInfo, new FileSizeComparer());
            foreach (var fi in filesInfo)
            {
                Console.WriteLine($"{fi.Name,-25} size: {fi.Length,10:N0}");
            }
        }
    }
    public class FileSizeComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}