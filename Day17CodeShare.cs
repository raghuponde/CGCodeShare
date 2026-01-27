
record record_name(data_type Property1, data_type Property2, …);

-- would be compiled as:

Compiled code of Record

class record_name
{
   public data_type Property1 { get; init; }
   public data_type Property2 { get; init; }
 
   public record_name(data_type Parameter1, data_type Parameter2)
   {
      this.Property1 = Parameter1;
      this.Property2 = Parameter2;
   }
}


Features:

Records are 'immutable' by default.

All the record members become as 'init-only' properties.

Records can also be partially / fully mutable - by adding mutable properties.

Supports value-based equality.

Supports inheritance.

Supports non-destructive mutation using 'with' expression.

  namespace RecordDemo
{

    public record Person(string Name,int Age);
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("John", 20);
            Person p2 = new Person("Scott", 34);
            Console.WriteLine($"{p1.Name}--{p1.Age}");
            Console.WriteLine($"{p2.Name}--{p2.Age}");
//            p1.Name="David"//error
     // only in constructor u can set the values 

            Console.ReadLine();
        }
    }
}
