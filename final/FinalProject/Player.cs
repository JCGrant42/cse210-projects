class Player : Entity {

    List<List<Tile>> _allCards = new List<List<Tile>>();
    private Gems _cardDiscounts = new Gems(0,0,0,0,0,0);
    private Tier _reservedCards = new Tier();
    private List<Tile> _nobles = new List<Tile>();
    private string _playerName; 
    private int _points;
    private bool _isTurn;
    private PlayingField _field;
    private List<Options> _options;
    private List<Player> _otherPlayers;

    public Player(PlayingField field, List<Options> options, List<Player> otherPlayers, string playerName) : base(0){
        _playerName = playerName;
        _field = field;
        _options = options;
        _otherPlayers = otherPlayers;

        for (int i = 0; i < 5; i++){
            _allCards.Add(new List<Tile>());
        }
    }

    public void DoPlayerTurn(){
        Console.WriteLine("\n\n\n\n\n\n");
        _isTurn = true;
        while (_isTurn){
            //Console.Clear();
            _field.Display();
            Console.Write($"\n\n{_playerName}'s turn: ");
            DisplayPlayer();
            Console.WriteLine("\n1. Purchase Card \n2. Take two of one Gem \n3. Take three unique Gems \n4. Reserve Card \n5. Display Other Players");
            Console.Write("Enter Option (1-4): ");
            string userinput = Console.ReadLine();
            Console.WriteLine("\n");
            switch (userinput)
            {   
            case "1":
                _options[0].DoAction(this);
                break;
            case "2":
                _options[1].DoAction(this);
                break;
            case "3":
                _options[2].DoAction(this);
                break;
            case "4":
                _options[3].DoAction(this);
                break;
            case "5":
                DisplayOtherPlayers();
                break;
            default: 
                Console.WriteLine("Invalid input.");
                break;
            }
        }
        CheckNobles();
        Console.WriteLine("\n_____________________________________________________________________________________\n");
        DisplayPlayer();
        Console.WriteLine("\n\nEnding turn...\n");
        Console.WriteLine("Press enter to continue");
        Console.ReadLine();
    }

    

    public bool endTurn(){
        return _isTurn = false;;
    }

    public string GetPlayerName(){
        return _playerName;
    }

    public Tier GetReservedCards(){
        return _reservedCards;
    }
    
    public Gems GetCardDiscounts(){
        return _cardDiscounts;
    }
      
    public bool CheckScore(){
        bool hasWon = false;
        if (_points >= 15){
            hasWon = true;
        }
        return hasWon;
    }

    public void AddCard(Tile card){
        int index = card.GetCardTypeIndex();
        _allCards[index].Add(card);
        _cardDiscounts.ChangeAmount(card.GetCardTypeIndex(), 1);
        _points += card.GetPoints();
    }

    private void CheckNobles(){
        List<Tile> nobles = _field.GetTier(0).GetShownCards();
        foreach (Tile nobleTile in nobles){
            if (CheckPlayerResources(_cardDiscounts, nobleTile.GetGems())){
                _nobles.Add(nobleTile);
                _points += 3;
                nobleTile.DisplayCard("\nYou have gained a Noble: ");
                Console.WriteLine();
            }
        }
        foreach(Tile noble in _nobles){
            nobles.Remove(noble);
        }
    }

    public bool CheckPlayerResources(Gems playerResources, Gems resourcesNeeded){
        bool hasEnough = true;
        for(int i = 0; i < 5; i++){ 
            if (!playerResources.CheckIfEnough(i, resourcesNeeded.GetAmount(i))){
                hasEnough = false;
                break;
            }
        }
        return hasEnough;
    }
    public void DisplayOtherPlayers(){
        foreach (Player p in _otherPlayers){
            if (p != this){
                Console.WriteLine("\n____________________________________________________________________________\n");
                Console.Write($"{p.GetPlayerName()}: ");
                p.DisplayPlayer();
            }
        }
        Console.WriteLine("Press enter to continue");
        Console.ReadLine();
    }
    private void DisplayPlayer(){
        Console.Write($"{_points} points");
        DisplayNobles();
        DisplayGems("\nTokens: \n");
        DisplayCards();
        Console.WriteLine();
        if (_reservedCards.GetCount() > 0){
            Console.WriteLine("\nReserved Cards: ");
            _reservedCards.DisplayTier();
        }
    }

    private void DisplayCards(){
        Console.WriteLine("\nCards: ");
        int highestCount = 0;
        foreach (List<Tile> list in _allCards){
            if (list.Count > highestCount){
                highestCount = list.Count;
            }
        }
        for (int i = 0; i < highestCount; i++){
            for (int j = 0; j < 5; j++){
                if (_allCards[j].Count != 0){
                    if (_allCards[j].Count > i){
                        Tile card = _allCards[j][i];
                        Console.Write(card.GetLine(2));
                    }
                    else{
                        Console.Write($"            ");
                    }
                }
            }
            Console.WriteLine();
        } 
    }

    private void DisplayNobles(){
        if (_nobles.Count > 0){
            for(int i = 1; i <= 7; i++){      
                foreach(Tile t in _nobles){
                    Console.Write(t.GetLine(i));
                }
                Console.WriteLine();
            } 
        }
    }   

}