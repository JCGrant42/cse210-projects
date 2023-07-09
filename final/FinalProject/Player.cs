class Player : Entity {

    private List<Card> _cards = new List<Card>();
    private List<Card> _nobles = new List<Card>();
    private Tile _reservedCard = new Tile();
    private bool _hasReserved = false;
    private Gems _tokens = new Gems(0,0,0,0,0,0);
    private Gems _cardsGemDiscount = new Gems(0,0,0,0,0,0);
    private PlayingField _field;
    private string _playerName; 


    public Player(PlayingField field, string playerName) : base("Player"){
        _playerName = playerName;
        _field = field;
    }

    public string GetPlayerName(){
        return _playerName;
    }

    public void Display(){
    }
   

    public void DoPlayerTurn(){
        //_field.Display();
        bool doTurn = true;
        while (doTurn){
            Console.WriteLine("\n1. Take two of one Gem \n2. Take three unique Gems \n3. Purchase Card \n4. Reserve Card");
            Console.Write("Enter Option (1-6): ");
            string userinput = Console.ReadLine();
            Console.WriteLine();
            switch (userinput)
            {   
            case "1":
                TakeTokens(2);
                //check players current amoutn of gems, if it will make it higher than 10 warn the player
                //let player choose which gem type to take
                //checks bank's amount of gems
                //remove from bank
                //add to player
                //check if player has more than ten and then gives choose on which to remove.
                break;
            case "2":
                //same as aabove but lets the player choose three times 
                //after wards lets them comfirm their choice before setting it
                break;
            case "3":
                //lets player select the tier and go back, give option to purchase reserved card
                //lets the player select the card and go back
                    //returns the card after selection
                // checks the cost to the players resources 
                    //inputs the card, the players tokens, and the land card info to function 
                    //adds the cards and tokens together
                    //compare the info
                    //if true the takes the card cost and subtract the discounts from the price
                    //take the remained and returns the cost amounts
                    //use the amount and subtract it from player tokens
                    //adds card to player
                    //add token to discount gems
                //check if the player has earn any of the nobles
                    //input playing field and uses land cards
                    // iterates through list of nobles on playing field
                    //if palyer has equal or greater than on all requirements, 
                    //return the noble and display message.
                break;
            case "4":
                //use same process as purchasing but does not require the checks
                // adds the card to the reserved card
                // program acknowlegdes there is a reserved card
                //checks if there is a gold token
                // if there is
                    //remove from bank
                    //add to player 
                break;
            default: 
                Console.WriteLine("Invalid input.");
                break;
            }
        }
    }
    private void TakeTokens(int tokenAmount){
        bool proceed = true;
        bool isOverTen = false;
        if (CheckTotalTokenAmount(tokenAmount)){
            isOverTen = true;
            proceed = GetUserComfirmation("This will put you over ten tokens, you will have to discard tokens until you are back down to ten. \nDo you wish to proceed (Y/N): ");
        }
        if (proceed){
            if (tokenAmount == 2){
                TakeTwoTokens();
            }
            if (tokenAmount == 3){
                TakeThreeTokens();
            }
            if (isOverTen){
               // DiscardTokens();
            }
        }
    }

    private void TakeTwoTokens(){
        string choose = TokenSelection();
        if (GetUserComfirmation($"Are you sure you want to take 2 {choose}?")){
            TransferTokens();
        }
    }

    private void TakeThreeTokens(){
        string choose1 = TokenSelection();
        string choose2 = TokenSelection();
        string choose3 = TokenSelection();
        if (GetUserComfirmation($"Are you sure you want to take 1 {choose1}, 1 {choose2}, and 1 {choose3}?")){
            TransferTokens();
        }
    }

    private string TokenSelection(){
        bool active = true;
       // string chosenToken ;
        while (active){
            Console.WriteLine("Which gem do you want to take?");
            Console.WriteLine("\n1. Diamond \n2. Sapphire \n3. Emerald \n4. Ruby \n5. Onyx");
            Console.Write("Enter Option (1-5): ");
            string userChoose = Console.ReadLine();
            switch (userChoose) {
                case "1":
                    break;
                case "2":
                    break;
                case "3": 
                    break;
                case "4":
                    break;
                case "5":
                    break;
                default: 
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }
        return "";
    }

    public void TransferTokens(){

    }

    private bool CheckTotalTokenAmount(int extraAmount = 0){
        bool isOverTen = false;
        int amount = 0;
        for (int i = 0; i < 6; i++){
            amount += _tokens.GetGemAmountByIndex(i);   
        }
        if (amount > 10) {
            isOverTen = true;
        }
        return isOverTen;
    }

    public (bool, Tile, Tier) ChooseCard(){
        bool doChoose = true;
        bool didChoose = false;
        Tile ChosenCard = new Tile();
        Tier chosenTier = new Tier();

        while (doChoose){
            Console.WriteLine("Which Teir would you like to choose from?");
            Console.WriteLine("\n1. Bottom Tier \n2. Middle Tier \n3. High Tier \n4. Go Back ");
            Console.Write("Enter Option (1-4): ");
            string userInputTier = Console.ReadLine();
            int.TryParse(userInputTier, out int userTierNum);
            if (userTierNum >= 1 || userTierNum <= 3) {
                chosenTier = _field.GetTier(userTierNum);

                while (doChoose){
                    chosenTier.DisplayTier();
                    Console.WriteLine("     1          2          3          4       5. Go Back");
                    Console.WriteLine("Which card would you like to choose? ");
                    Console.Write("Enter (1-5): ");
                    string userInputCard = Console.ReadLine();
                    int.TryParse(userInputCard, out int userCardNum);
                    if (userCardNum >= 1 || userCardNum <= 4) {
                        ChosenCard = chosenTier.GetCard(userCardNum - 1);
                        didChoose = true;
                    }
                    else if (userCardNum == 5) {
                        doChoose = false;
                    }
                    else{
                        Console.WriteLine("Invald Choose.");
                    }
                }
            }
            else if (userTierNum == 4) {
                doChoose = false;
            }
            else{
                Console.WriteLine("Invald Choose.");
            }
        }
        return (didChoose, ChosenCard, chosenTier);

    }


    public void PurchaseCard(){
        (bool didChoose, Tile choosenCard, Tier choosenTier) = ChooseCard();
        if (didChoose){
            Gems newPrice = CalculateDiscount(choosenCard);
            if (CheckPlayerResources()){
                //choosenTier.TakeCard();
                TransferTokens();
            }
        }
    }
    public void ReservedCard(){
        (bool didChoose, Tile choosenCard, Tier choosenTier) = ChooseCard();
        if (didChoose){
            _reservedCard = choosenCard;
            _hasReserved = true;
            TransferTokens();
        }
    }

    public Gems CalculateDiscount(Tile card){
        Gems discountPrice = new Gems();
        return discountPrice;
    }

    public bool CheckPlayerResources(){
        return false;
    }

    private bool GetUserComfirmation(string message){
            bool userAnswer = false;
            Console.Write($"{message}");
            string userInput = Console.ReadLine();
            if (userInput == "y" || userInput == "Y" || userInput == "yes" || userInput == "Yes"){
                userAnswer = true;
            }
            else{
                Console.WriteLine("Going back.");
            }
        return userAnswer;
    }

    public bool CheckScore(){
        int totalPoints = 0;
        bool hasWon = false;
        foreach (Card n in _nobles){
            totalPoints += n.GetPoints();
        }
        foreach (Card c in _cards){
            totalPoints += c.GetPoints();
        }
        if (totalPoints >= 15){
            hasWon = true;
        }
        return hasWon;
    }

}