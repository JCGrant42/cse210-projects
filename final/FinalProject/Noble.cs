class Noble : Tile{

    public Noble(int points, int diamond, int sapphire, int emerald, int ruby, int onyx, string cardType) : base (points, diamond, sapphire, emerald, ruby, onyx, cardType){

    }

    protected override (string, string, string, string, string, string, string) BuildTileLines(){
        string line1 = "";
        string line2 =  " ________  ";
        string line3 = $"| 3P     | ";
        string line4 = $"|   {GetGemCost(2)} | ";
        string line5 = $"|   {GetGemCost(1)} | ";
        string line6 = $"|   {GetGemCost(0)} | ";
        string line7 =  "|________| ";
        return (line1, line2, line3, line4, line5, line6, line7);
    }
//Example
//  _________  
// | 3P      | 
// |    3 () |
// |    3 <> | 
// |    3 // | 
// |_________| 
}




