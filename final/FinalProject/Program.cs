using System;

class Program
{
    static void Main(string[] args)
    {
        
        //get the amount of players
        int numberOfPlayers = 1;
        bool loop = true;
        while(loop){
            Console.Write($"How many people are playing? 1-4: ");
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out int userNum);
            if (userNum >= 1 && userNum <= 4) {
                loop = false;
                numberOfPlayers = userNum;
            }
            else{
                Console.WriteLine("Invald Choose.");
            }
        }

        //Sets up the games, Playing feild creates the several decks that the game will be using
        PlayingField field = new PlayingField(numberOfPlayers);
        List<Options> options = new List<Options>();
        options.Add(new PurchaseCard(field));
        options.Add(new TakeTwoTokens(field));
        options.Add(new TakeThreeTokens(field));
        options.Add(new ReserveCard(field)); 

        //Assigns the players and gets the player names
        List<Player> players = new List<Player>();
        for (int i = 1; i <= numberOfPlayers; i++){
            Console.Write($"Player {i} enter your name: ");
            string playerName = Console.ReadLine();
            Console.WriteLine();
            Player player = new Player(field, options, players, playerName);
            players.Add(player);
        }
        
        //Runs the game until a player gets 15 points then loop ends
        int winner = 0;
        bool doGame = true;
        while (doGame) {
            for (int i = 0; i < numberOfPlayers; i++){
                players[i].DoPlayerTurn();
                if (players[i].CheckScore()){
                    doGame = false;
                    winner = i;
                    break;
                }
            }
        }
        Console.WriteLine($"Congratulations! {players[winner].GetPlayerName()} has won the game!");
        Console.WriteLine("\n\n\n\n\n\n");
    }

}