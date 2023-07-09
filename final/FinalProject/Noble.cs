class Noble : Tile{

    public Noble(int points, int diamond, int sapphire, int emerald, int ruby, int onyx, string cardType) : base (points, diamond, sapphire, emerald, ruby, onyx, cardType){

    }

    public override (string, string, string, string, string, string, string) BuildTileLines(){
        string line1 = "";
        string line2 =  " ________  ";
        string line3 = $"| 3P     | ";
        string line4 = $"|   {GetGemCost(2)} | ";
        string line5 = $"|   {GetGemCost(1)} | ";
        string line6 = $"|   {GetGemCost(0)} | ";
        string line7 =  "|________| ";
        //string line7 =  "             ";
        return (line1, line2, line3, line4, line5, line6, line7);
    }

}




