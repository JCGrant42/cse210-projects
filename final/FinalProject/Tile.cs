class Tile {
    private int _points;
    private Gems _gems;
    private string _cardType;
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
        _cardType = cardType;

        CreateGemCost(diamond, "diamond");
        CreateGemCost(sapphire, "sapphire");
        CreateGemCost(emerald, "emerald");
        CreateGemCost(ruby, "ruby");
        CreateGemCost(onyx, "onyx");

        (_line1, _line2, _line3, _line4, _line5, _line6, _line7) = BuildTileLines();
    }
    public int GetPoints(){
        return _points;
    }
    public string GetCardType(){
        return _cardType;
    }
    public virtual (string, string, string, string, string, string, string) BuildTileLines(){
        return ("", "", "", "", "", "", "");
    }

    public void CreateGemCost(int cost, string gem){
        if (cost != 0){
            _gemCosts.Add($"{cost} {_gems.GetSymbol(gem)}");
        } 
    }
 
    public string GetGemCost(int index){
        string gemCost = "    ";
        if (_gemCosts.Count > index){
            gemCost = _gemCosts[index];
        }
        return gemCost;
    }

    public string Getline(int lineNum){
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