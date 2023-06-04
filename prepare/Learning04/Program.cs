using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assign = new Assignment("Jade Grant", "Math");
        Console.WriteLine(assign.GetSummary());

        MathAssignment MathAssign = new MathAssignment("Jade Grant", "Math", "Section 7.3", "Problems 8-19");
        Console.WriteLine(MathAssign.GetSummary());
        Console.WriteLine(MathAssign.GetHomeworkList());

        WritingAssignment WriteAssign = new WritingAssignment("Jade Grant", "Writing", "Basic Math");
        Console.WriteLine(WriteAssign.GetSummary());
        Console.WriteLine(WriteAssign.GetWritingInformation());

    }
}