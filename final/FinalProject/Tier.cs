class Tier {
    private List<Tile> _deck;
    private List<Tile> _shownCards = new List<Tile>();
    private bool _hasDeck;


    public Tier(){
        _hasDeck = false;
    }

    public Tier(string fileName, string type = "cards", int numOfCards = 4){
        _deck = CreateDeck(fileName, type);
        _hasDeck = true;
        for(int i = 0; i < numOfCards; i++){
            ReplenishCard(i);    
        } 
    }

    public Tile GetCard(int index){
        return _shownCards[index];
    }

    public List<Tile> GetShownCards(){
        return _shownCards;
    }

    public void AddCard(Tile card){
        _shownCards.Add(card);
    }

    public int GetCount(){
        return _shownCards.Count;
    }


    public void DisplayTier(){
        for(int i = 1; i <= 7; i++){      
            foreach(Tile t in _shownCards){
                Console.Write(t.GetLine(i));
            }
            Console.WriteLine();
        }  
    }

    public Tile TakeCard(int cardIndex){
        Tile pulledCard = _shownCards[cardIndex];
        _shownCards.RemoveAt(cardIndex);
        if (_hasDeck && _deck.Count != 0){
            ReplenishCard(cardIndex);
        }
        return pulledCard;
    }

    public void ReplenishCard(int shownCardIndex){
        Random ranGen = new Random();
        int randomIndex = ranGen.Next(_deck.Count); 
        Tile newCard = _deck[randomIndex];
        _deck.RemoveAt(randomIndex);
        _shownCards.Insert(shownCardIndex, newCard);
    }


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
       
}