class Tier {
    private List<Tile> _deck;
    private List<Tile> _shownCards = new List<Tile>();


    public Tier(){}
    public Tier(string fileName, string type = "cards", int numOfCards = 4){
        _deck = CreateDeck(fileName, type);

        for(int i = 0; i < numOfCards; i++){
            ReplenishCard(i);    
        } 
    }
    public Tile GetCard(int index){
        return _shownCards[index];
    }


    public void DisplayTier(){
        for(int i = 1; i <= 7; i++){
            if (_shownCards.Count == 3){
                Console.Write("       ");
            }        
            foreach(Tile t in _shownCards){
                Console.Write(t.Getline(i));
            }
            Console.WriteLine();
        }  
    }
    // Example of what will be shown
    //   _________   _________   _________   _________  
    //  | ■    1P | | ■    1P | | ■    1P | | ■    1P |
    //  |     1 ● | |     1 ● | |     1 ● | |     1 ● |
    //  |     1 ● | |     1 ● | |     1 ● | |     1 ● |
    //  |     1 ● | |     1 ● | |     1 ● | |     1 ● |
    //  |     1 ● | |     1 ● | |     1 ● | |     1 ● |
    //   ͞ ͞ ͞ ͞ ͞ ͞ ͞ ͞ ͞    ͞ ͞ ͞ ͞ ͞ ͞ ͞ ͞ ͞    ͞ ͞ ͞ ͞ ͞ ͞ ͞ ͞ ͞    ͞ ͞ ͞ ͞ ͞ ͞ ͞ ͞ ͞   

    private List<Tile> CreateDeck(string deckName, string type){
        List<Tile> deck = new List<Tile>();
        try{
            string[] lines = System.IO.File.ReadAllLines(deckName);
            
            foreach (string line in lines)
            {
                string[] parts = line.Split(",");
                Tile tile;
                if (type == "noble"){
                    tile = new Noble(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), parts[6]);  
                }
                else {
                    tile = new Card(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), parts[6]);  
                }
                deck.Add(tile);
            }
        } catch {
            Console.WriteLine("File does not exist.");
        }
        return deck;
    }

    public Tile TakeCard(int cardIndex){
        Tile pulledCard = _shownCards[cardIndex];
        _shownCards.RemoveAt(cardIndex);
        ReplenishCard(cardIndex);
        return pulledCard;
    }

    public void ReplenishCard(int shownCardIndex){
        Random ranGen = new Random();
        int randomIndex = ranGen.Next(_deck.Count); 
        Tile newCard = _deck[randomIndex];
        _deck.RemoveAt(randomIndex);
        _shownCards.Insert(shownCardIndex, newCard);
    }


    
       
}