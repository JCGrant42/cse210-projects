class PlayingField : Entity{
    private List<Tier> _field = new List<Tier>();

    public PlayingField(int playerNum) : base(playerNum){
        //creates the decks for the game
        _field.Add(new Tier("noble.txt", "noble", playerNum + 1));
        _field.Add(new Tier("highTier.txt"));
        _field.Add(new Tier("midTier.txt"));
        _field.Add(new Tier("lowTier.txt"));
    }

    public Tier GetTier(int index){
        return _field[index];
    }

    public void Display(){
        //displays all the cards on the board
        foreach (Tier T in _field){
            T.DisplayTier();
        }
        DisplayGems("\nGem Bank: ");
        Console.WriteLine();
    }
}