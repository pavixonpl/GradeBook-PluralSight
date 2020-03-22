using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate (string LogMessage); //I create a delegate to this type (string, and variable also a string)
    //the only this that matters for the delegate is method type, number of parametrs, and type of this parametrs
    public class TypeTests
    {
        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage; //creating a variable in delegate

            log += IncrementCount;
            log += ReturnMessage; //seting a pointing to the method "ReturnMessage" by variable "log"
            
            var result = log("Hello"); //sending to the log varible type string, that points to Return message
            Assert.Equal(3, count);
        }
        string IncrementCount(string message)
        {
            count ++;
            return message;
        }
        string ReturnMessage(string message)
        {
            count ++;
            return message;
        }
        
        [Fact]
        public void StringBehavesLikeValueTypes()
        {
            string name = "Paweł";
            var upper = MakeUppercase(name);//string is a reference type, that means i can only change his copy not him self
            
            Assert.Equal("Paweł", name);
            Assert.Equal("PAWEŁ", upper);
        }

        private string MakeUppercase(string name)
        {
            return name.ToUpper(); // I can't change the value of string, but i can return a changed copy of him

        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
           var book1 = GetBook("Book 1");
           GetBookSetName(ref book1, "New Book"); //reference allow me to change default values 

           Assert.Equal("New Book", book1.Name);

        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name); //book is pointing to book1, which is pointing to "New Name"
            //also i can use "out" instead of "ref", but there I need to inicialize this parametrs, to not get an error
        }


        [Fact]
        public void CSharpIsPassByValue()
        {
           var book1 = GetBook("Book 1");
           GetBookSetName(book1, "New Book"); 

           Assert.Equal("Book 1", book1.Name); //I don't change the value, I just create a new student, but the value doesn't changed

        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name); //In this moment I creating a new object, with new student named "name"
        }

        [Fact]
        public void CanSetNewNameFromReference()
        {
           var book1 = GetBook("Book 1");
           SetName(book1, "New Book"); 

           Assert.Equal("New Book", book1.Name); //I have not created new object, I just change the value of the reference

        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDiffrentObjects()
        {
           var book1 = GetBook("Book 1");
           var book2 = GetBook("Book 2");

           Assert.Equal("Book 1", book1.Name); //this is 2 another objects in 1 method
           Assert.Equal("Book 2", book2.Name); //that gives a oportunity to act like this
        }

        [Fact]
        public void TwoVarsCanReferenceOneObject()
        {
           var book1 = GetBook("Book 1");
           var book2 = book1;

           Assert.Same(book1,book2);
           Assert.True(object.ReferenceEquals(book1,book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
