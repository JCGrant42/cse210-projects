using System;

class Program
{
    static void Main(string[] args)
    {
        Journal Journal = new Journal();
        while (true) {
            Console.WriteLine("\n1. Create Entry \n2. Display Journal \n3. Delete Entry \n4. Save Jounral \n5. Load Jounral \n6. Prompt Management");
            Console.Write("Enter Option (1-6): ");
            string userinput = Console.ReadLine();                
            switch (userinput)
            {
            case "1":
                Journal.Write();
                break;
            case "2":
                Journal.DisplayJounral();
                break;
            case "3":
                Journal.DeleteEntry();
                break;
            case "4":
                Journal.Save();
                break;
            case "5":
                Journal.Load();
                break;
            case "6":
                Prompt prompt = new Prompt();
                prompt.ManagePrompts();
                break;
            default: 
                Console.WriteLine("Invalid input.");
                break;
            }       
        }
    }
}