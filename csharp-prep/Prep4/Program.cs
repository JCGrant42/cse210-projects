using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        while (true) {
            //get input
            Console.Write("Enter a number (enter 0 to quit:) ");
            int num = int.Parse(Console.ReadLine());

            //ends to loop if 0 is entered
            if (num == 0) {
                break;
            } 
            //otherwises adds the number
            numbers.Add(num);    
        }

        // set initial values
        int sum = 0;
        int largest = numbers[0];

        //goes through each number and adds them together and finds the largest at the same time
        foreach (int num in numbers) {
            sum += num;
            if (largest < num) {
                largest = num;
            }
        }

        //Finds the avarage of the numbers
        float average = sum / numbers.Count();

        //displays results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest is: {largest}");

    }
}