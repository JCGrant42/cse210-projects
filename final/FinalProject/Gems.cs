class Gems {
    private int _diamond;
    private int _sapphire;
    private int _emerald;
    private int _ruby;
    private int _onyx;
    private int _token;

    public Gems(int diamond, int sapphire, int emerald, int ruby, int onyx, int token){
        _diamond = diamond;
        _sapphire = sapphire;
        _emerald = emerald;
        _ruby = ruby;
        _onyx = onyx;
        _token = token;
    }
    
    public Gems(){}

    public int GetGemAmount(string type){
        int amount = 0;
        switch (type){
            case "diamond":
            amount = _diamond;
            break;
            case "sapphire":
            amount = _sapphire;
            break;
            case "emerald":
            amount = _emerald;
            break;
            case "ruby":
            amount = _ruby;
            break;
            case "onyx":
            amount = _onyx;
            break;
            case "token":
            amount = _token;
            break;
        }
        return amount;
    }

    public int GetGemAmountByIndex(int index){
        int amount = 0;
        switch (index){
            case 0:
            amount = _diamond;
            break;
            case 1:
            amount = _sapphire;
            break;
            case 2:
            amount = _emerald;
            break;
            case 3:
            amount = _ruby;
            break;
            case 4:
            amount = _onyx;
            break;
            case 5:
            amount = _token;
            break;
        }
        return amount;
    }
    
        public void ChangeGemAmount(string type, int amount){
        switch (type){
        case "diamond":
        _diamond += amount;
        break;
        case "sapphire":
        _sapphire += amount;
        break;
        case "emerald":
        _emerald += amount;
        break;
        case "ruby":
        _ruby += amount;
        break;
        case "onyx":
        _onyx += amount;
        break;
        case "token":
        _token += amount;
        break;
        }
    }

    public string GetSymbol(string type){
        string symbol = "";
        switch (type){
        case "diamond":
        symbol = "<>";
        break;
        case "sapphire":
        symbol = "{}";
        break;
        case "emerald":
        symbol = "[]";
        break;
        case "ruby":
        symbol = "()";
        break;
        case "onyx":
        symbol = "//";
        break;
        case "token":
        symbol = "T";
        break;
        case "noble":
        symbol = " N";
        break;
        }
        return symbol;
        //<>  {}  [] () ## ◄► ■■ ♦♦
    }
}