using System;

class Program
{
    static void Main(string[] args)
    {
        bool run = true;
        
        while (run) {
            Console.Clear();
            Console.WriteLine("Menu Options");
            Console.WriteLine("1. Breathing Activity \n2. Reflection Activity \n3. Listing Activity \n4. Quit");
            Console.Write("Enter Option: ");
            string userinput = Console.ReadLine();                
            switch (userinput)
            {
            case "1":
                Breathing breath = new Breathing();
                breath.DoActivity();
                break;
            case "2":
                Reflection reflect = new Reflection();
                reflect.DoActivity();
                break;
            case "3":
                Listing list = new Listing();
                list.DoActivity();
                break;
            case "4":
                run = false;
                break;
            default: 
                Console.WriteLine("Invalid input. Please enter a choice of 1-4");
                break;

            }
        }
    }
}