using System;
using Xunit;

namespace GradeBook.tests
{
    public class BookTests
    {
        // Fact  is an attribute, an attribute it is a way associating metadata, or declarative information with code.
        // In our case, [Fact] is attached to Test1() method.  We "decorate" Test1() method with [Fact] attribute
        // How Xunit use [Fact] attribute is that it will only execute methods with [Fact] attached to methods.
        // That is how Xunit it knows that this method is a test unit method, and to run it.
        [Fact]
        public void TestExample()
        {
            /*  Arrange section - this where you put together your test data.
                you arrange the objects and value you are going to use  
            */ 
            var x = 5;
            var y = 2;
            var expected = 7;

            /* Act section - this where you invoke a method, perform something, you do something to produce a result.
            */
            var actual = x + y;

            // Assert section - you assert something about arrange and act.
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BookCalculatesAverageGrades()
        {
            // arrange
            var book = new InMemoryBook("Test Gradebook");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            var expected  = 85.63;
            // act
            var result = book.GetStatistics();


            // assert
            Assert.Equal(expected, result.Average, 2);
            Assert.Equal(90.5, result.Highest, 1);
            Assert.Equal(77.3, result.Lowest, 1);

        }

        [Fact]
        public void GradeIsBetweenZeroAndOneHundred()
        {
            // arrange
            var book = new InMemoryBook("Grade Book");
            try
            {
                book.AddGrade(-10);

            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            book.AddGrade(100);
            book.AddGrade(50);
           
            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(75, result.Average);
            Assert.Equal(100, result.Highest);
            Assert.Equal(50, result.Lowest);
        }

        [Fact]
        public void GetCorrectLetterGrade()
        {
            // arrange
            var book = new InMemoryBook("Grade Book");
            book.AddGrade(65);
            book.AddGrade(100);
            book.AddGrade(50);
            book.AddGrade(80.6);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(73.9, result.Average);
            Assert.Equal(100, result.Highest);
            Assert.Equal(50, result.Lowest);
            Assert.Equal('C', result.Letter);
        }
    }

}