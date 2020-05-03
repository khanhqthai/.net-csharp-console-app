using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {

        }

        public override event Delegates.GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            // using - is  wrapping our code in try and finally code block. 
            // it will handle closing the file/clean up of memory for us.
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if(GradeAdded !=null )
                {
                        GradeAdded(this, new EventArgs());
                }
            }

  
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            string line;
            using(var reader = File.OpenText($"{Name}.txt")){
                
                while((line = reader.ReadLine()) != null){
                    var number = double.Parse(line);
                    statistics.Add(number);
                }
            }
            return statistics;
        }
    }
}