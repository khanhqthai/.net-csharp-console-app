using System;
using System.Collections.Generic;

namespace GradeBook
{
    // creating a class, you want to think of what the behavoir or things that this class can do
    // and what kind of data it can hold
    public class InMemoryBook : Book
    {
        
        // Constuctor method, constructors must have the same name as your class and no return type.
        // if you do not define a constructor C# has a default one.
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>(); // we can instaniate a list here

        }


        // when we declare a varaible inside a class, not inside a function, it is consider a field, because it is not being declared inside a function
        // we can not use var keyword when declaring a field.
        // we want field because we want the book class to cary this data with it.
        // if we did put it inside a function(like AddGrade below), the List would only exists inside that scope, it is a local variable
        private List<double> grades;
        


        // readonly keyword makes it so that the field can only be changed/intialized inside the constructor and variable intializer.
        // this is a way to have constants.
        readonly string category;

        // const field are static, and as convention capitalized
        // const field can not being changed, not even in constructors.
        // you access const field like static members.
        // you can't access static member via reference, but only through Type name
        /// e.i. Book.MORE_CATEGORY
        public const string MORE_CATEGORY = "Science";


        //DELAGATE: we usually put delegates in it's own file, because it is a Type and usually Type get their own file per convention
        // but we will place it here for demonstration
        // first parameter is type object because object is the base type for everyting in dotnet C#.
        // wether it's book, integer, double, string, class...they all have a relation to object  
        // so when we declare a parameter to be object type, we can pass anything into it(string,int,class, whatever)
        // the second parameter is a event arguments -- this is where can pass anything with this event
         
        public override event Delegates.GradeAddedDelegate GradeAdded; // an event can be memeber of a class.

        public override void AddGrade(double grade)
        {
            if(grade <=100 && grade >=0 ){
                grades.Add(grade);
                

                // we only want to announce the event if its not null, if no one is subscribed to it we do not need to  invoke it.
                if(GradeAdded !=null )
                {
                        GradeAdded(this, new EventArgs());
                }
            }else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}, grade must be between 0-100");
            }

        }


        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            // generally you want to use foreach, as it is more of a pure function, last things to keep track of
            // code is cleaner and easier to read/understand, less remove for syntax error
            for(var index = 0; index<grades.Count; index += 1)
            {
                if(grades[index]== 4244.1){
                    // jumping statements -- break, continue, goto
                    // break - breaks out of the loop
                    // continue - allows you to skip on iteration, continues looping
                    // goto - jump to a lable --- do use this.
                    //break;  breaks out of loop
                }
                statistics.Add(grades[index]);
            }

            return statistics;
        }

        public void AddGrade(char letter)// method overload it!
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'F':
                    AddGrade(50);
                    break;

                default:
                    AddGrade(0);
                    break;
            }

        }

    }


}
