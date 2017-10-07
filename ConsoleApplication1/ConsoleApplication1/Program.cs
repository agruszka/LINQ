﻿using System;
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
            //GetNameOfDaysUsingLinq();
            //GetNameOfDatesUsingLinq();
            //ShowFibonacciNumbers();
            //ShowFibonacciSecondNumbers();
            TakeTwoNextNumbers();
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
        private static void GetNameOfDatesUsingLinq()

        {
            var availableCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var test = from ci in availableCultures
                       select ci.DateTimeFormat.FullDateTimePattern;
            var dates = test.Distinct();
            foreach (var DistinctDate in dates)

            {
                Console.WriteLine(DistinctDate);
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

        private static void ShowFibonacciNumbers()
        {
            int[] fibonacci = { 0, 1, 1, 2, 3, 5 };
            // query created, and immediately executed
            var numbersGreaterThanTwo = fibonacci.Where(x => x > 2).ToArray();
            fibonacci[0] = 99;
            foreach (var number in numbersGreaterThanTwo)
            {
                Console.WriteLine(number);
            }
        }
        private static void ShowFibonacciSecondNumbers()
        {
            int[] fibonacci = { 0, 1, 1, 2, 3, 5 };
            // query created, and immediately executed
            var SecondNumbers = fibonacci.Where((x, i) => i % 2 != 0).ToArray();
            fibonacci[0] = 99;
            foreach (var number in SecondNumbers)
            {
                Console.WriteLine(number);
            }
        }
        private static void TakeTwoNextNumbers()
        {
            int[] fibonacci = { 0, 1, 1, 2, 3, 5 };
            // query created, and immediately executed
            var TakeNextNumbers = fibonacci.Skip(2).Take(2);
      
            foreach (var number in TakeNextNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
    }
    private static void Filtering()
    {
    }


}
private static void Filtering()
{
}
public class FileSizeComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
