using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your grade percentage: ");
        string grade = Console.ReadLine();
        int number = int.Parse(grade);
        string letterGrade = "";

        if (number >= 90){
            letterGrade = "A";
        }
        else if(number >= 80){
            letterGrade = "B";
        }
        else if(number >= 70){
            letterGrade = "C";        
        }
        else if(number >= 60){
            letterGrade = "D";           
        }
        else {
            letterGrade = "F";    
        }

        string symbol = "";
        if (number >= 60 && number <= 96){
            int firstDigit = number % 10;
            if (firstDigit >= 7){
                symbol = "+";
            }
            else if(number < 3){
                symbol = "-";
            }
        }

        Console.WriteLine($"Your grade is {letterGrade}{symbol}.");
             

        if (number >= 70){
            Console.WriteLine("congratulations, You Pass");
        }
        else {
            Console.WriteLine("Your grade was not high enough, keep on trying");
        }


    }
}