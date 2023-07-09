class Card : Tile {
    public Card(int points, int diamond, int sapphire, int emerald, int ruby, int onyx, string gemName) : base (points, diamond, sapphire, emerald, ruby, onyx, gemName){

    }

    public override (string, string, string, string, string, string, string) BuildTileLines(){
        Gems gem = new Gems();
        string gemSymbol = gem.GetSymbol(GetCardType());

        string _cardPoints = "  ";
        int points = GetPoints(); 
        if (points != 0){
            _cardPoints = $"{points}P";
        }
    
        string line1 =  " _________  ";
        string line2 = $"| {gemSymbol}   {_cardPoints} | ";
        string line3 = $"|    {GetGemCost(3)} | ";
        string line4 = $"|    {GetGemCost(2)} | ";
        string line5 = $"|    {GetGemCost(1)} | ";
        string line6 = $"|    {GetGemCost(0)} | ";
        string line7 =  "|_________| ";
        //   _________  Example of what each line will look like.
        //  | ♦    1P | 
        //  |     1 ● | 
        //  |     1 ◄ | 
        //  |     1 ■ | 
        //  |     1 □ |
        //  |_________|   
        return (line1, line2, line3, line4, line5, line6, line7);
    }
    
//  _________  
// | 3P      | 
// |    3 () |
// |    3 <> | 
// |    3 // | 
// |_________| 
    

    


    

}