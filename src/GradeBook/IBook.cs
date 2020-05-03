using System;

namespace GradeBook 
{
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name {get;}
        event Delegates.GradeAddedDelegate GradeAdded;
    } 
}