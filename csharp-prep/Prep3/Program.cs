using System;

class Program
{
    static void Main(string[] args)
    {
        Random RandomGenerator = new Random();
        int RandumNum = RandomGenerator.Next(1,100);


        while (true) {
            Console.Write("Please enter a number ");
            int guessNum = int.Parse(Console.ReadLine());


            if (guessNum > RandumNum) {
                Console.WriteLine("Lower");
            }
            else if (guessNum < RandumNum){
                Console.WriteLine("Higher");
            }
            else{
                Console.WriteLine("You guess correctly!!!");
                break;
            }
        }
    }
}