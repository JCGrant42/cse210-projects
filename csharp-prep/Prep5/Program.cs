using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome(){
             Console.WriteLine("Welcome to the program!");
        }

        static string PromptUserName(){
            Console.Write("Please enter your name: ");
            string userInput = Console.ReadLine();
            return userInput;
        } 

        static int PromptUserNumber(){
            Console.Write("Please enter your favorite number: ");
            int userNumber = int.Parse(Console.ReadLine());
            return userNumber;
        } 
        
        static int SquareNumber(int number){
            int squaredNumber = number * number;
            return squaredNumber;
        } 
        
        static void DisplayResult(string name, int squaredNumber){
             Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
        } 
        

        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        DisplayResult(userName, squaredNumber);


    }
}