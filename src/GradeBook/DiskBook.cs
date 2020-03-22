using System.IO;
using System;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        { 
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            //challange: every time its invoked it opens the book with the same name, and print there a grade
            using(var gradewriter = File.AppendText(@"C:\Users\projekty\gradebook\students\" + $"{Name}.txt"))
            { // using statement means, dont clean the memory, before I end my code.
                gradewriter.WriteLine(grade); // so i can add grades to new file without any problems
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }//here is the end of my code
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using(var gradereader = File.OpenText(@"C:\Users\projekty\gradebook\students\" + $"{Name}.txt"))
            {
                var line =  gradereader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = gradereader.ReadLine();
                }
                
            }
            return result;
        }
    }
}