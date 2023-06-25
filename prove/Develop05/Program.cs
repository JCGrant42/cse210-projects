using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        GoalControls GoalControls = new GoalControls();
        bool run = true;
        while (run) {
            Console.WriteLine();
            GoalControls.DisplayReminders();
            Console.WriteLine($"\nYou have {GoalControls.GetTotalPoints()} points.");

            Console.WriteLine("\n1. Create Goal \n2. Display Goals \n3. Record Event \n4. Save Goals \n5. Load Goals \n6. Quit");
            Console.Write("Enter Option (1-6): ");
            string userinput = Console.ReadLine();
            Console.WriteLine();
            switch (userinput)
            {
            case "1":
                GoalControls.CreateGoal();
                break;
            case "2":
                GoalControls.ListGoals();
                Thread.Sleep(2000);
                break;
            case "3":
                GoalControls.Record();
                break;
            case "4":
                GoalControls.SaveFile();
                break;
            case "5":
                GoalControls.LoadFile();
                break;
            case "6":
                run = false;
                break;
            default: 
                Console.WriteLine("Invalid input.");
                break;
            }       
        }
    }
}