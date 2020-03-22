using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args) // operations on lists
        {
            IBook book = new DiskBook("Book of Stachu");
            book.GradeAdded += OnGradeAdded; //I can add here, becouse there are in one delegation, if I change the type, I cannot do this

            EnterGrades(book);

            var result = book.GetStatistics(); //variation for object that get returned from this function

            //Console.WriteLine($"The category name is: {InMemoryBook.CATEGORY}");//const act like a static member, so I can get to it only by class, not by the object like "book"
            Console.WriteLine($"The name of studnet is: {book.Name}");
            Console.WriteLine($"The highest grade is: {result.High}");
            Console.WriteLine($"The lowest grade is: {result.Low}");
            Console.WriteLine($"The average grade is: {result.Average:N1}"); // N1 means, that it shows 1 digit after decimal numer
            Console.WriteLine($"The letter grade is: {result.Letter}");

        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {

                Console.WriteLine("Enter the grade or 'q' to quit:");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var inputgrade = double.Parse(input);
                    book.AddGrade(inputgrade); //if higher line throws an exception, this line didn't get executed
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                    //there I can place a code, that must be executed after throwing and an exception
                    //for example. closing a program, or getting out from database
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs e) //this place can recive delegation so it start to execute the instruction
        {
            Console.WriteLine("Grade was added");
        }
    }
}
