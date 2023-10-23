using System;

public enum Department
{
    ComputerScience,
    Engineering,
    Mathematics,
    Physics,
}


public class Person
{
    public string Name { get; set; }

    public Person()
    {
        Name = null; // Default value for name (string)
    }

    public Person(string name)
    {
        Name = name;
    }
}

// Student class derived from Person
public class Student : Person
{
    public string RegNo { get; set; }
    public int Age { get; set; }
    public Department Program { get; set; }

    public Student()
    {
        RegNo = null;        
        Age = 0;            
        Program = Department.ComputerScience; 
    }

    public Student(string name, string regNo, int age, Department program)
        : base(name) 
    {
        RegNo = regNo;
        Age = age;
        Program = program;
    }
}

class Program
{
    static void Main()
    {
        
        Student student1 = new Student("Sikandar", "213003", 20, Department.ComputerScience);

        
        Console.WriteLine($"Name: {student1.Name}");
        Console.WriteLine($"RegNo: {student1.RegNo}");
        Console.WriteLine($"Age: {student1.Age}");
        Console.WriteLine($"Program: {student1.Program}");
    }
}
