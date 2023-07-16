class Options{
  
    protected PlayingField _playingField;
    protected Gems _gemBank;
    
    public Options(PlayingField field){
        _playingField = field;
        _gemBank = _playingField.GetTokens();
    }

    public virtual void DoAction(Player player){

    }



    protected void TakeTokens(Player player, int extraTokens){
        bool proceed = true;
        int amount = GetGemAmount(player, extraTokens); 
        if (amount > 10){
            proceed = GetUserComfirmation("This will put you over ten tokens, you will have to discard tokens until you are back down to ten. \nDo you wish to proceed (Y/N): ", "Going back.");
        }
        if (proceed){  
            ChooseTokens(player);
            while (GetGemAmount(player, 0) > 10){
                DiscardToken(player);
            }
        }
    }

    private int GetGemAmount(Player player, int amount){
        for (int i = 0; i < 6; i++){
            amount += player.GetTokens().GetAmount(i);   
        }
        return amount;
    }

    protected virtual void ChooseTokens(Player player){
    }

    protected void TransferPlayerTokens(int index, int amount, Player player){
        Gems playerGems = player.GetTokens();
        playerGems.ChangeAmount(index, amount);
        _gemBank.ChangeAmount(index, amount * -1);
    }


    protected void DiscardToken(Player player){
        Gems PlayerTokens = player.GetTokens();
        while(true){
            player.DisplayGems("Tokens: \n");
            string prompt = CreateTokenDisplay(FindAvaliableTokens(1, PlayerTokens), PlayerTokens, "\n\nDiscard a Token: ");
            prompt += "\nEnter Option 1-6: ";
            (bool validChoice, bool loop, int gemIndex) = GetUserChoice(5, prompt);
            if (validChoice){
                TransferPlayerTokens(gemIndex, -1, player);
                break;
            }
        }
    }

    protected List<bool> FindAvaliableTokens(int neededAmount, Gems gems){
        List<bool> isAvaliableList = new List<bool>();
        for (int i = 0; i < 5; i++){
            if (gems.CheckIfEnough(i, neededAmount)){
                isAvaliableList.Add(true);
            }
            else{
                isAvaliableList.Add(false);
            }
        } 
        return isAvaliableList;
    }

    protected string CreateTokenDisplay(List<bool> avaliableList, Gems gems, string displayPrompt = "Which gem do you want to take?"){
        for (int i = 0; i < 5; i++){
            displayPrompt += $"\n{i + 1}. ";
            if (avaliableList[i]){
                 displayPrompt += $"{gems.GetSymbol(i)} {gems.GetName(i)}"; 
            }
        } 
        return displayPrompt;
    }
   


    protected (bool, Tile, Tier, int) ChooseCard(Player player){
        bool doLoop = true;
        bool validCard = false;
        Tile ChosenCard = new Tile();
        Tier chosenTier = new Tier();
        int cardIndex = -1;

        while (doLoop){
            (bool validTier, doLoop, int userTierNum) = GetUserChoice(3, "\nWhich Teir would you like to choose from? \n1. High Tier \n2. Middle Tier \n3. Bottom Tier \n4. Go Back \nEnter Option (1-4): ");
            if (validTier) {
                chosenTier = _playingField.GetTier(userTierNum + 1);

                while (doLoop){
                    player.DisplayGems("Tokens : ");
                    Console.WriteLine();
                    DisplayCardOptions(chosenTier);
                    (validCard, doLoop, int userCardNum) = GetUserChoice(chosenTier.GetCount(), "");
                    if (validCard) {
                        cardIndex = userCardNum;
                        ChosenCard = chosenTier.GetCard(userCardNum);
                        doLoop = false;
                    }
                }
            }           
        }
        return (validCard, ChosenCard, chosenTier, cardIndex);
    }

    protected void DisplayCardOptions(Tier cardGroup){
        cardGroup.DisplayTier();
        string displayString = "";
        for (int i = 0; i < cardGroup.GetCount(); i++){
            displayString += $"     {i + 1}      ";
        } 
        displayString += $"     {cardGroup.GetCount() + 1}. Go Back \nWhich card would you like to choose? (1-{cardGroup.GetCount() + 1}): ";
        Console.Write(displayString);
    }



    protected (bool, bool, int) GetUserChoice(int numberOfChoices, string message){
        bool validChoice = false;
        bool continueLoop = true;
        Console.Write($"{message}");
        string userInput = Console.ReadLine();
        Console.WriteLine();
        int.TryParse(userInput, out int userNum);
        if (userNum >= 1 && userNum <= numberOfChoices) {
            validChoice = true;
        }
        else if (userNum == numberOfChoices + 1) {
            continueLoop = false;
        }
        else{
            Console.WriteLine("Invald Choose.");
        }
        return (validChoice, continueLoop, userNum - 1);
    }

    protected bool GetUserComfirmation(string prompt, string retreatMessage){
            bool userAnswer = false;
            Console.Write($"{prompt}");
            string userInput = Console.ReadLine();
            if (userInput == "y" || userInput == "Y" || userInput == "yes" || userInput == "Yes"){
                userAnswer = true;
            }
            else{
                Console.WriteLine($"{retreatMessage}");
            }
        return userAnswer;
    }
}
