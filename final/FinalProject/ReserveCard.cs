class ReserveCard : Options{    
    
    public ReserveCard(PlayingField field) : base(field){

    }

    public override void DoAction(Player player){
        Tier reservedCards = player.GetReservedCards();
        if (reservedCards.GetCount() < 3){
            (bool didChoose, Tile choosenCard, Tier choosenTier, int cardIndex) = ChooseCard(player);
            if (didChoose){
                choosenCard = choosenTier.TakeCard(cardIndex);
                reservedCards.AddCard(choosenCard);
                if (_gemBank.CheckIfEnough(5, 1)){
                    Console.WriteLine("You can now take a Gold (Wild) Token");
                    TakeTokens(player, 1);  
                }
                choosenCard.DisplayCard("You have reserved: ");
                player.endTurn();
            }
        }
        else{
            Console.WriteLine("You already have the max of three cards reserved. Please purchase one to reserve another.");
            Thread.Sleep(2000);
        }
    }

    protected override void ChooseTokens(Player player){
        TransferPlayerTokens(5, 1, player);
        Console.WriteLine("1 Gold (Wild) Token add to your hand");
        Thread.Sleep(1000);
    }
}
