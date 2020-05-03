using System;
using Xunit;

namespace GradeBook.tests
{

    /*
        How do we know if we are working a Reference Type or Value Type? 
        
        The rules are simple:
         -If we are working with something that has been defined by a class, we are working with a Reference Type. 
         -If we are working with struct, we are working with specialized Value Type.
         for the 90% of day to day work, we will be working with classes(Reference Type) not Structs, but there cases for it.
         You can also check if something a Value Type or Reference Type, you can press f12 in VS Code to see the meta data.

         C# Has two category of Types in dot net.  
         There Reference Type defined by Classes, and Value Type define by structs.
         We also learn that when we pass parameters to methods we pass by Value, always always.
         And most importanly, we can use unit to explore and understand how C# behaves
    */
    public class TypeTests
    {


        // delegate are like callback functions in JavaScript.  They point to function.
        // which you can invoke later.  but with delegates you can add multiple function and there invoke multiple functions.
        // You do by using add it using "+="  or subtract "-="... the methods will be invoked sequentially
        // delegates gives us a variable that we can invoke like a method.
        public delegate string WriteLogDelegate(string logMessage);


        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;
            log = new WriteLogDelegate(ReturnMessage); // or just log = ReturnMessage;
            log += ReturnMessageToLower; // we can add more functions to log with +=
            log += ReturnMessage; // add more!

            var result = log("Hello");

            Assert.Equal("Hello", result);
        }

        private string ReturnMessageToLower(string message)
        {
            
            return message.ToLower();
        }

        private string ReturnMessage(string message)
        {
            
            return message;
        }

        [Fact]
        public void StringIsReferenceTypeButBehavesLikeValueType() // String are immutable, once created can't be changed.
        {
            String name = "Khanh";
            MakeUpperCase(name);

            Assert.Equal("Khanh", name);
        }

        private void MakeUpperCase(string name)
        {
            name.ToUpper();
        }

        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(x);

            Assert.Equal(3,x);
        }

        private void SetInt(int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            // arrange
            var book1 = GetBook("Book 1");
    
            // if you wanted to pass by value, you can use ref keyword or out, except with out, it does not need to intialize before passing it.
            GetBookSetNameByRef(ref book1, "New Name"); //
            // act

            // assert
            Assert.Equal("New Name", book1.Name);
         
            

        }

        private void GetBookSetNameByRef(ref InMemoryBook book, string bookName)
        {
            book = new InMemoryBook(bookName);
            
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;
            // In C#, when you are passing a parameter to a method, you are always/100% passing by value, unless there is a keyword
            // but always always always passing by value
            GetBookSetName(book1, "New Name"); //
            // act

            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);
            

        }

        private void GetBookSetName(InMemoryBook book, string bookName)
        {
            book = new InMemoryBook(bookName);
            
        }
        [Fact]
        public void CanSetNameFromReference()
        {
            // arrange
            var book1 = GetBook("Book 1");
            
            // In C#, when you are passing a parameter to a method, you are always/100% passing by value, unless there is a keyword
            // but always always always passing by value
            SetName(book1, "New Name"); //
            // act

            // assert
            Assert.Equal("New Name", book1.Name);
            

        }

        private void SetName(InMemoryBook book, string bookName)
        {
            book.Name = bookName;            
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            // act

            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1,book2);

        }
        
        [Fact]
        public void TwoVariableCanReferenceTheSameObject()
        {
            // arrange:
            var book1 = GetBook("Book 1");
            var book2 = book1;

            // act:

            // assert:

            // under the hood Same method is using Object.ReferenceEquals method from  in the Object base class.
            // we'll come to find out, everything in C# inherits from Object class.
            Assert.Same(book1,book2); 

            // under the hood.
            Assert.True(Object.ReferenceEquals(book1,book2));
            

        }

        InMemoryBook GetBook(string bookName)
        {

            return new InMemoryBook(bookName);
        }

    }

}