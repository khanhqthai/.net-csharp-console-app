using System;
using System.Collections.Generic;

namespace GradeBook
{
    // fundamentally C# is an object oriented programing langauge, and classes in C# define objects.  
    // in C# a class defines a new type
    // a type allows us to get work done.
    // a string array(sting[]) is a type, a list array of double is a type(List<double>)
    // and even Console is a type
    // each of these have different behavior, and store different information
    // List<double> has float numbers stored in it.
    // Console has the WriteLine method that we can use
    // So in order to do anything in C#, type is involed.
    // every is organize in a type

    class Program
    {

        static void Main(string[] args) // <- this called a method
        {

            IBook book = new DiskBook("Khanh's Gradebook");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var gradeStatistics = book.GetStatistics();

            Console.WriteLine($"The highest grade is: {gradeStatistics.Highest}");
            Console.WriteLine($"The lowest grade is: {gradeStatistics.Lowest}");
            Console.WriteLine($"The average grade is: {gradeStatistics.Average}");
            Console.WriteLine($"The letter grade is: {gradeStatistics.Letter}");

            

        }

        private static void HereForNotes(string[] args)
        {
            double x = 34.1; // this is variable declaration statement. 
            double y = 2.4;

            // c# has var keyword.  some people love it some people dont.
            // when declaring  with var keyword, depending on what you asign the value of the variable to, c# can figure out the type of the variable automatically set it.
            // so you won't have to explicitly declare variables with the correct type.
            // for example, above we declared "double x = 34.1", we know that x is double type.
            // when can also declare "var z = 10.1" and c# will set the type of x to double because it 10.1 is a double -- you can highlight over z and see 
            // when var, you must explicity set the value, so compiler can resolve the type.
            // you can't just declare it and not intialize it
            // ei... var tempVar; <-- this will get a compiler error;
            // var tempVar = "something"; <- this will work
            var z = x + y;


            double[] numbers; // this is only reference, nothing has been intialize, it just pointing to an array that doesn exists. we can't immediately do this "numbers[0]= 12.0"
            numbers = new double[3]; // this creates a array of doubles in memory, gets assinged to numbers, aka numbers now points to an existsing array
            numbers[0] = 2;
            numbers[1] = 3;
            numbers[2] = 5;

            // the above can be refactored to use var keyword instead
            var anotherNumber = new double[3];

            var result = numbers[0] + numbers[1] + numbers[2];
            Console.WriteLine(result);

            // instead initializing the array, line by line as above we use that following.
            // c# has array intialization syntax--cool!
            var moreNumbers = new double[] { 5.5, 32.2, 1.2 };

            // we can further refactor the abover line
            // we don't even, need the double keyword, because c# can infer from the values we initialize that it is doubles (5.4,100, 2.0)
            var evenMoreNumbers = new[] { 5.4, 100, 2 };
            var evenMoreResult = 0.0;

            // looping through array
            foreach (double number in evenMoreNumbers)
            {
                evenMoreResult += number;
            }
            System.Console.WriteLine($"This is even more results: {evenMoreResult}");


            // arrays require that we know the size of the array before we can declare but for our task,
            // students can have variable amount of grade entries, we may not know, it can change
            // this is where we can use  data structures in c#, they are provide in system.collection namespace --- such as queues, stacks, lists,

            // we'll need to include this class, it is in another namespace.  namespace help reduce colisions, so if I write a class called List and you
            // write a class called List.  They can be differiated because they are in different namespaces.
            // for List we will need to include the correct namespace -- "using System.Collections.Generic;"

            // when we declare a List, we will need to declare what type the List will contain.  We betwen the "<>" for our case
            // we want doubles, you can have List hold classes, or other types
            List<double> grades = new List<double>(); // the () at the calls the List constructor method to initialize and create the List object.
            grades.Add(5.4); // value to list

            // we can also intialize List with {}
            List<double> anotherGrades = new List<double>() { 70.0, 25.0, 100.0330, 45.10 };
            var anotherGradesTotal = 0.0;
            foreach (double number in anotherGrades)
            {
                anotherGradesTotal += number;
            }

            // we can format the results, in this we add "N5" to have our double go upto 5 places
            // you can format date time, left align or right align string, manu more.. google to find out
            Console.WriteLine($"The average grade is: {anotherGradesTotal / anotherGrades.Count:N5}");



            if (args.Length > 0) // <-- this is called a if statement, it evaluates an expression
            {
                System.Console.WriteLine(z);
                Console.WriteLine($"Hello, {args[0]}!"); // <- this is  called a statement
            }
            else
            {
                Console.WriteLine($"Hello there!");
            }
        }

        private static bool EnterGrades(IBook book)
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("Press 'q' to quit or enter a grade: ");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    System.Console.WriteLine("Goodbye!");
                    done = true;
                    continue;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
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
                    //..
                }

            }

            return done;
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Grade was just added");
        }

        

    }
}


