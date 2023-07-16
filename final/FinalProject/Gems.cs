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

    public bool CheckIfEnough(int index, int amountCheck){  
        int amountHave = GetAmount(index);
        bool isEnough = amountHave >= amountCheck;
        return isEnough;
    }

    public int GetIndexByName(string type){
        int index = -1;
        switch (type.ToLower()){
            case "diamond":
            index = 0;
            break;
            case "sapphire":
            index = 1;
            break;
            case "emerald":
            index = 2;
            break;
            case "ruby":
            index = 3;
            break;
            case "onyx":
            index = 4;
            break;
            case "token":
            index = 5;
            break;
        }
        return index;
    }


    public int GetAmount(int index){
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

    public string GetName(int index){
        string name = "";
        switch (index){
            case 0:
            name = "Diamond";
            break;
            case 1:
            name = "Sapphire";
            break;
            case 2:
            name = "Emerald";
            break;
            case 3:
            name = "Ruby";
            break;
            case 4:
            name = "Onyx";
            break;
            case 5:
            name = "Gold";
            break;
        }
        return name;
    }
    
    public void ChangeAmount(int index, int amount){
        switch (index){
        case 0:
        _diamond += amount;
        break;
        case 1:
        _sapphire += amount;
        break;
        case 2:
        _emerald += amount;
        break;
        case 3:
        _ruby += amount;
        break;
        case 4:
        _onyx += amount;
        break;
        case 5:
        _token += amount;
        break;
        }
    }

    public string GetSymbol(int index){
        string symbol = "";
        switch (index){
        case 0:
        symbol = "<>";
        break;
        case 1:
        symbol = "{}";
        break;
        case 2:
        symbol = "[]";
        break;
        case 3:
        symbol = "()";
        break;
        case 4:
        symbol = "//";
        break;
        case 5:
        symbol = "";
        break;
        case 6:
        symbol = " N";
        break;
        }
        return symbol;
    }
}