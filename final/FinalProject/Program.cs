using System;

class Program
{
    static void Main(string[] args)
    {
        bool doGame = true;

        int numberOfPlayers = 3;
        int winner = 0;


        PlayingField field = new PlayingField(numberOfPlayers);
        List<Player> players = new List<Player>();
        string playerName = "";

        for (int i = 0; i < numberOfPlayers; i++){
            Player player = new Player(field, playerName);
            players.Add(player);
        }


        while (doGame) {
            for (int i = 0; i < numberOfPlayers; i++){
                DisplayGame(i);
                players[i].DoPlayerTurn();
                if (players[i].CheckScore()){
                    doGame = true;
                    winner = i;
                    break;
                }
            }
        }
        Console.WriteLine($"Congratulations! {players[winner].GetPlayerName()} wins the game!");



        void DisplayGame(int playerNum){
            field.Display();
            // for (int i = 0; i <= numberOfPlayers; i++){
            //     if (i != playerNum){
            //         players[i].Display();
            //     }
            // }
            //Console.WriteLine($"{game[playerNum].GetPlayerName()}'s Turn!");
            //game[playerNum].Display(); //Make sure the players reserved card is showing
        }   
    }

}