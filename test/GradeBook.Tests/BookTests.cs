using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //arange (setting a values)
            var book = new InMemoryBook("");
            book.AddGrade(50.5);
            book.AddGrade(60.5);
            book.AddGrade(70.5);
            

            //act (using the data for example ShowStatistics())

            var stats = book.GetStatistics(); //variation for object that get returned from this function

            //assert (check true or false)
            Assert.Equal(70.5, stats.High, 1);
            Assert.Equal(50.5, stats.Low, 1);
            Assert.Equal(60.5, stats.Average, 1);
            Assert.Equal('D', stats.Letter);
        }

        [Fact]
        public void IsGradeAnCorrectValue()
        {
            var book = new InMemoryBook("");
            book.AddGrade(99.3);

            Assert.True(book.valuetest);
        }
    }
}
