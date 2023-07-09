class PlayingField : Entity{
    private List<Tier> _field = new List<Tier>();

    //private List<Player> _players = new List<Player>();

    public PlayingField(int playerNum) : base("PlayingField"){
        _field.Add(new Tier("noble.txt", "noble", playerNum + 1));
        _field.Add(new Tier("highTier.txt"));
        _field.Add(new Tier("midTier.txt"));
        _field.Add(new Tier("lowTier.txt"));

    }

    public Tier GetTier(int index){
        return _field[index];
    }

    public void Display(){
        foreach (Tier T in _field){
            T.DisplayTier();
        }
    }

    // public void playerTurn(int playerIndex){
    //     Player player = _players[playerIndex];
    //     player.DoPlayerTurn();
    // }
}