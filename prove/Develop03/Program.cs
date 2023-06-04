using System.Text.Json;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        
        //Creates a Libary using a json file and the Libary class 
        string fileName = "BookofMormon.json";
        string jsonString = File.ReadAllText(fileName);
        Library BoMLibrary = JsonSerializer.Deserialize<Library>(jsonString);

        bool isHidden = false;
        string userinput = "";

        //Program will continue to run until all words are marked as hiden or the user types "quit"
        while (userinput.ToLower() != "quit" && !isHidden){

            //Gets a reference string from the user
            Console.Write("Please enter a scripture reference, or type 'quit' to quit: ");
            userinput = Console.ReadLine();
            Reference reference = new Reference(userinput, BoMLibrary);

            //The Program will only continue to run if the user gave a valid reference, program would crash other wise
            //If the reference is not valid it will loop back and ask the user for the reference again
            if (reference.GetIsValid()){
                Console.Clear();

                //creates the scripture class by using the reference given to find the scripture's text inside the libary.
                Scripture script = new Scripture(reference, BoMLibrary);
                script.DisplayScripture();
                
                //Loop will continue to run until the user types "back" or "quit" or until all words are hidden
                bool isHidingMode = true;
                while (userinput.ToLower() != "quit" && userinput.ToLower() != "back" && !isHidden) {

                    //This loop is for Hiding Mode
                    while (isHidingMode && !isHidden){

                        Console.Write("\n\nPress enter to remove words, type 'Switch' to switch to revealing words, Type 'back' to select different scripture, or type 'quit' to quit: ");
                        userinput = "";
                        userinput = Console.ReadLine();
                        //Clears the screen before making the changes.
                        Console.Clear();

                        //If the user presses enter it will hide a few random words and display the scripture
                        if (userinput == ""){
                            script.HideRandomWords();
                            //When all words are hidden this function set isHidden to false so that the program will end
                            isHidden = script.IsHidden();
                            
                        }

                        //If the user types "all" all word will be hidden (this does end the program but the user will have to press enter one more time for it to end)
                        else if (userinput.ToLower() == "all"){
                            script.HideAll();
                        }

                        //Changes modes
                        else if (userinput.ToLower() == "switch"){
                            isHidingMode = false;
                            script.DisplayScripture();
                            break;
                        }

                        //Breaks the loop, if the user types "back" it will go back to reference selection, 
                        //if the user type "quits" program will end
                        else if (userinput.ToLower() != "quit" || userinput.ToLower() != "back"){
                            break;
                        }
                        //Displays the scripture after making the changes
                        script.DisplayScripture();
                    }

                    //This loop is for Revealing Mode, SAME CODE AS ABOVE but reveals instead of hides
                    while (!isHidingMode){

                        Console.Write("\n\nPress enter to reveal words, type 'Switch' to switch to hiding words, Type 'back' to select different scripture, or type 'quit' to quit: ");
                        userinput = "";
                        userinput = Console.ReadLine();
                        Console.Clear();

                        if (userinput == ""){
                            script.RevealWord();
                        }

                        else if (userinput.ToLower() == "all"){
                            script.RevealAll();
                        }

                        else if (userinput.ToLower() == "switch"){
                            script.DisplayScripture();
                            isHidingMode = true;
                            break;
                        }

                        else if (userinput.ToLower() != "quit" || userinput.ToLower() != "back"){
                            break;
                        }
                        script.DisplayScripture();

                    }
                }
            }
        }
    }
}