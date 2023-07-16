class Entity{
    protected Gems _tokens;
    
    public Entity(int num){
        //for Playing Feild and Players, 
        //0 is for palyer who have no tokens  
        //the rest are for the token bank based on the number of palyer palying
        switch (num){
            case 0:
                _tokens = new Gems(0, 0, 0, 0, 0, 0);
                //_tokens = new Gems(100, 100, 100, 100, 100, 0); for testing purposes
                break;
            case 1:
                _tokens = new Gems(7, 7, 7, 7, 7, 5);
                break;
            case 2:
                _tokens = new Gems(4, 4, 4, 4, 4, 5);
                break;
            case 3:
                _tokens = new Gems(5, 5, 5, 5, 5, 5);
                break;
            case 4:
                _tokens = new Gems(7, 7, 7, 7, 7, 5);
                break;
        }
    }

    public Gems GetTokens(){
        return _tokens;
    }


    public void DisplayGems(string startingString){
        //For displaying the amount of tokens in the gem bank and the players hand. 
        string displayString = startingString;
        for (int i = 0; i < 6; i++){
            if (_tokens.GetAmount(i) > 0){
                displayString += $" {_tokens.GetSymbol(i)} {_tokens.GetAmount(i)} {_tokens.GetName(i)}  ";
            }
        } 
        Console.Write(displayString);
    }
}
