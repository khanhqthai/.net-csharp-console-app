namespace GradeBook
{
    // abstract class - is the same as a regular class, it has incomplete implementation.
    // it is intended only to be used as a base class of other classes, not instantiated on its own.
    // memebers(property, methods) marked as abstract must be implemented by non-abstract classes that derive from it.
    // abstract class does not care of the detail how the method/members are implemented, it asks/forces the dervie class to do that.
    // so in a way abstract modifier allows us to implement Polymorphism in our classes.
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {

        }

        public abstract event Delegates.GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }
}