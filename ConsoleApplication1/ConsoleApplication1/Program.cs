using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Globalization;
namespace ConsoleLinqToObjects
{
    class Program
    {

        static void Main(string[] args)
        {
            string path = @"C:\Windows\";
            //GetFilesNamesAndSizeWithoutLinq(path);
            //GetCulturesWithCommaSeparatorWithoutLinq();
            //GetCulturesWithCommaSeparatorUsingLinq();
            //GetCulturesWithDotSeparatorUsingLinq();
            GetNameOfDaysUsingLinq(path);
            Console.ReadLine();
        }

        private static void GetNameOfDaysUsingLinq(string path)
        {
            throw new NotImplementedException();
        }

        private static void GetCulturesWithCommaSeparatorWithoutLinq()
        {
            var availableCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (var ci in availableCultures)
            {
                if (ci.NumberFormat.NumberDecimalSeparator == ",")
                {
                    Console.WriteLine($"{ci.Name}");
                }
            }
        }
        private static void GetCulturesWithCommaSeparatorUsingLinq()
        {
            var availableCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

            var culturesWithCommaSeparator = from ci in availableCultures
                                             where ci.NumberFormat.CurrencyDecimalSeparator.Equals(",")
                                             orderby ci.DisplayName
                                             select ci;

            foreach (var ci in culturesWithCommaSeparator)
            {
                Console.WriteLine($"{ci.DisplayName}");
            }

            Console.WriteLine($"{culturesWithCommaSeparator.Count()} ustawień kulturowych korzysta z przecinka jako separatora dziesiętnego");
        }
            
        private static void GetCulturesWithDotSeparatorUsingLinq()
        {
            var availableCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

            var culturesWithDotSeparator = from ci in availableCultures
                                             where ci.NumberFormat.CurrencyDecimalSeparator.Equals(".")
                                             orderby ci.DisplayName
                                             select ci;

            foreach (var ci in culturesWithDotSeparator)
            {
                Console.WriteLine($"{ci.DisplayName}");
            }

            Console.WriteLine($"{culturesWithDotSeparator.Count()} ustawień kulturowych korzysta z kropki jako separatora dziesiętnego");

        }
        private static void GetNameOfDaysUsingLinq()

        {
            {

                /* Lambda*/
                var availableCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
                var albanianCulture = availableCultures.Where(c => c.DisplayName.Contains("Alban")).First();

                /* Inna wersja zamiast lambdy - linq*/
                var anotherAlbanian = from ci in availableCultures
                                      where ci.DisplayName.Contains("Alban")
                                      select ci;
         

                var anotherDayNames = anotherAlbanian.First();

                var dayNames = albanianCulture.DateTimeFormat.FullDateTimePattern;

                foreach (var dayName in dayNames)
                {
                    Console.WriteLine(dayName);
                }

            }



        }
        private static void GetFilesNamesAndSizeWithoutLinq(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            var filesInfo = directoryInfo.GetFiles();
            Array.Sort(filesInfo, new FileSizeComparer());
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{filesInfo[i],-25} size: {filesInfo[i].Length,10:N0}");
            }
        }
        private static void GetTop5LargestFileUsingLinq(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            var filesInfo = from file in directoryInfo.GetFiles()
                            orderby file.Length descending
                            select file;
            foreach (var fi in filesInfo.Take(5))
            {
                Console.WriteLine($"{fi.Name,-25} size: {fi.Length,10:N0}");
            }
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
