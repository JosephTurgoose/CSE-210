using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("John", "Chemistry");
        Console.WriteLine(assignment.GetSummary());

        Math mathAssignment = new Math("John", "Math", "Problems 1-4", "Section 3");
        Console.WriteLine(mathAssignment.GetHomeworkList());

        Writing writingAssignment = new Writing("John", "Writing", "Shakespeare Essay");
        Console.WriteLine(writingAssignment.GetWritingInformation());

    }
}