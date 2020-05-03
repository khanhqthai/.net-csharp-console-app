using System;
namespace GradeBook
{
    public class Statistics 
    {

        public double Average
        {
            get
            {
                return GradeTotal / TotalNumbOfGradeEntries;
            }
        }
        public double Highest;
        public double Lowest; 
        public char Letter
        {
            get
            {
                switch(Average)
                {
                    case var grade when grade >= 90.0:
                        return 'A';
                    case var grade when grade >= 80.0 && grade <=89.0:
                        return 'B';
                        
                    case var grade when grade >= 70.0 && grade <=79.0:
                        return 'C';
                    case var grade when grade >= 60.0 && grade <=69.0:
                        return 'D';
                    default:
                        return 'F';
                        
                }
                
            }

        }
        public double TotalNumbOfGradeEntries;
        public double GradeTotal;
        
        public Statistics()
        {
            Highest = double.MinValue;
            Lowest = double.MaxValue;
            GradeTotal = 0.0;
            TotalNumbOfGradeEntries = 0.0;
        }
        public void Add(double number)
        {
            Highest = Math.Max(number, Highest);
            Lowest = Math.Min(number, Lowest);
            GradeTotal += number;
            TotalNumbOfGradeEntries += 1;
        }

    }
}