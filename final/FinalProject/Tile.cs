class Tile {
    protected int _points;
    private Gems _gems;
    protected int _cardTypeIndex;
    private List<string> _gemCosts = new List<string>();
    private string _line1;
    private string _line2;
    private string _line3;
    private string _line4;
    private string _line5;
    private string _line6;
    private string _line7;
    
    public Tile(){}
    public Tile(int points, int diamond, int sapphire, int emerald, int ruby, int onyx, string cardType){
        _points = points;
        _gems = new Gems(diamond, sapphire, emerald, ruby, onyx, 0);
        _cardTypeIndex = _gems.GetIndexByName(cardType);
        CreateLine(onyx, 4);
        CreateLine(ruby, 3);
        CreateLine(emerald, 2);
        CreateLine(sapphire, 1);
        CreateLine(diamond, 0);

        (_line1, _line2, _line3, _line4, _line5, _line6, _line7) = BuildTileLines();
    }
    
    protected string GetGemCost(int index){
        string gemCost = "    ";
        if (_gemCosts.Count > index){
            gemCost = _gemCosts[index];
        }
        return gemCost;
    }

    protected void CreateLine(int cost, int index){
        if (cost != 0){
            _gemCosts.Add($"{cost} {_gems.GetSymbol(index)}");
        } 
    }

    protected virtual (string, string, string, string, string, string, string) BuildTileLines(){
        return ("", "", "", "", "", "", "");
    }
    

    public void DisplayCard(string message){
        Console.WriteLine(message);
        for (int i = 1; i <= 7; i++){
            Console.WriteLine(GetLine(i));
        }
        Thread.Sleep(1000);
    }


    public Gems GetGems(){
        return _gems;
    }

    public int GetCardTypeIndex(){
        return _cardTypeIndex;
    }

    public int GetPoints(){
        return _points;
    }

    public string GetLine(int lineNum){
        string line = "";
        switch (lineNum){
        case 1:
        line = _line1;
        break;
        case 2:
        line = _line2;
        break;
        case 3:
        line = _line3;
        break;
        case 4:
        line = _line4;
        break;
        case 5:
        line = _line5;
        break;
        case 6:
        line = _line6;
        break;
        case 7:
        line = _line7;
        break;
        }
        return line;
    }

}