using System.Collections.Generic;
using System;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name{ get; }
        event GradeAddedDelegate GradeAdded;
    }
    
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name): base(name)
        {

        }
        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
    }
    
    public class InMemoryBook : Book
    {
        public bool valuetest;
        public InMemoryBook(string name) : base(name)
        {
            Name = name;
            grades = new List<double>(); //inicializing the list to get acces for her elements
        }
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                valuetest = true; //unit test
                if(GradeAdded !=null)
                {
                    GradeAdded(this, new EventArgs()); //I sending a values to delegation, that send it to place who can recive it
                }
            }
            else
            {    
                valuetest = false; //unit test
                throw new ArgumentException($"Invalid {nameof(grade)}"); //this throws an exception to the place, where it can be catched
            }
            
        }

        public override event GradeAddedDelegate GradeAdded; //here I creating a object for this delegation 

        public override Statistics GetStatistics() //this function returns a objects in class Statistics
        {
            var result = new Statistics();

            for(var i = 0; i < grades.Count; i++)
            {
                result.Add(grades[i]);
            }
            

            
            
            return result; //returning a whole object, that means i can return 3 diffrent doubles i 1 line. Awesome
        }

        


        private List<double> grades; //creating a list named grades
        
        //readonly string category = "Science"; //this type can be changed only on inicialization or, in constructor and the value will never change, no matter what
        public const string CATEGORY = "Science"; //This variable cannot be changed after the inicialization
        
    }
}