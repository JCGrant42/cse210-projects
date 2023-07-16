class PurchaseCard : Options{

    public PurchaseCard(PlayingField field) : base(field){
    }
    
    public override void DoAction(Player player){
        int choice = 0;
        bool loop = true;
        bool valid = true;
        while (loop){
            if (player.GetReservedCards().GetCount() > 0){
                (valid, loop, choice) = GetUserChoice(2, "Would you like to purchase From the Field or your reserved cards? \n1. Playing Field \n2. Reserved \n3. Go Back \nOption 1-3: ");
            }
            if (valid && choice == 0){
                PurchaseFieldCard(player);
                break;
            }
            if (valid && choice == 1){
                PurchaseReservedCard(player);
                break;
            }
        }
    }

    private void PurchaseFieldCard(Player player){
        (bool didChoose, Tile choosenCard, Tier choosenTier, int CardIndex) = ChooseCard(player);
        if (didChoose){
            PurchaseChosenCard(choosenCard, choosenTier, CardIndex, player);
        }
    }
     
    private void PurchaseReservedCard(Player player){
        Tier reservedCards = player.GetReservedCards();
        Console.WriteLine("Which Card do you want to purchase?");
        bool loop = true;
        while (loop){
            player.DisplayGems("\nTokens: ");
            Console.WriteLine();

            DisplayCardOptions(reservedCards);
            (bool valid, loop, int choice) = GetUserChoice(reservedCards.GetCount(), "");
            if (valid){
                PurchaseChosenCard(reservedCards.GetCard(choice), reservedCards, choice, player);
                break;
            }
        }
    }

    private void PurchaseChosenCard(Tile card, Tier cardGroup, int chosenCardIndex, Player player){
        Gems playerTokens = player.GetTokens();
        bool usingGold = false;
        List<int> GoldIndexes = new List<int>();
        for (int i = 0; i < playerTokens.GetAmount(5); i++){
            (usingGold, int GoldIndex) = UseGold(card, player);
            GoldIndexes.Add(GoldIndex);
        }
        Gems newPrice = CalculateDiscount(card, player);
        if (usingGold){
            foreach (int index in GoldIndexes){
                newPrice.ChangeAmount(index, -1);
            }
        }
        if (player.CheckPlayerResources(player.GetTokens(), newPrice)){
            if (usingGold){
                TransferPlayerTokens(5, -1 * GoldIndexes.Count(), player);
            }
            card = cardGroup.TakeCard(chosenCardIndex);
            player.AddCard(card);
            PayTokens(player, newPrice);
            card.DisplayCard("You have purchased: ");
            player.endTurn();
        }
        else{
            Console.WriteLine($"You do not have enough resources to purchase this card.\n");
            Thread.Sleep(2000);
        }
    }


    private (bool, int) UseGold(Tile card, Player player){
        Gems cardCost = card.GetGems();
        int GemIndex = -1;
        bool usingGold = false;
        if(GetUserComfirmation("Would you like to use a Gold Token? (Y/N): ", "Continuing")){
            List<bool> isAvailable = FindAvaliableTokens(1, cardCost);
            string prompt = CreateTokenDisplay(isAvailable, cardCost, "\n\nChoose a Gem:");
            player.DisplayGems("Tokens: ");
            prompt += $"\n6. Skip (Continue to Purchasing) \nEnter Option (1-6): ";
            bool loop = true;
            while(loop){
                (bool valid, loop, GemIndex) = GetUserChoice(5, prompt);
                if (valid){
                    if(isAvailable[GemIndex]){
                        usingGold = true;
                        loop = false;
                    }
                    else{
                        Console.WriteLine($"That is not a valid choice");
                    }
                }
            }
        }
        return (usingGold, GemIndex);
    }

    private Gems CalculateDiscount(Tile card, Player player){
        Gems newcost = new Gems();
        Gems cardCost = card.GetGems();
        Gems discount = player.GetCardDiscounts();
        for(int i = 0; i < 5; i++){ 
            int cost = cardCost.GetAmount(i) - discount.GetAmount(i);
            if (cost < 0){
                cost = 0;
            }
            newcost.ChangeAmount(i, cost);
        } 
        return newcost;
    }

    private void PayTokens(Player player, Gems newPrice){
        for (int i = 0; i < 5; i++){
            TransferPlayerTokens(i, (-1 * newPrice.GetAmount(i)), player);
        } 
    }

}
