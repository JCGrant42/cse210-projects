class TakeTwoTokens : Options{

    public TakeTwoTokens(PlayingField field) : base(field){

    }

    public override void DoAction(Player player){
        TakeTokens(player, 2);    
    }
    
    protected override void ChooseTokens(Player player){
        bool doLoop = true;
        List<bool> isAvailableList = FindAvaliableTokens(4, _gemBank);
        string prompt = CreateTokenDisplay(isAvailableList, _gemBank);
        prompt += $"\n6. Go Back \nEnter Option (1-6): ";
        while(doLoop){
            (bool validChoice, doLoop, int gemIndex) = GetUserChoice(5, prompt);
            if (validChoice){
                if (isAvailableList[gemIndex]){
                    TransferPlayerTokens(gemIndex, 2, player);
                    player.endTurn();
                    break;
                }
                else{
                    Console.WriteLine($"You can not take anymore {_gemBank.GetName(gemIndex)}s. There need to be four or more.\n");
                }
            }
            
        }
    }












}
