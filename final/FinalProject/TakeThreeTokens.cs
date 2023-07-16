class TakeThreeTokens : Options{

    public TakeThreeTokens(PlayingField field) : base(field){

    }

    public override void DoAction(Player player){
        TakeTokens(player, 3);    
    }
    
    protected override void ChooseTokens(Player player){
        List<bool> isAvailableList = FindAvaliableTokens(1, _gemBank);
        List<int> chosenGems = new List<int>();
        bool LoopGemChoosing = true;
        while(LoopGemChoosing){
            string prompt = CreateTokenDisplay(isAvailableList, _gemBank);
            (bool validChoice, LoopGemChoosing, int gemIndex) = GetUserChoice(5, prompt += $"\n6. Go Back \nEnter Option (1-6): ");
            if (validChoice){
                if (isAvailableList[gemIndex]){
                    chosenGems.Add(gemIndex);
                    isAvailableList[gemIndex] = false;
                }
                else{
                    Console.WriteLine($"No more {_gemBank.GetName(gemIndex)}s to take.\n");
                }
            }
            if (chosenGems.Count == 3){
                TransferTokens(player, chosenGems, isAvailableList);
                isAvailableList = FindAvaliableTokens(1, _gemBank);
                break;
            }
        }
    }

    private void TransferTokens(Player player, List<int> chosenGems, List<bool> isAvailableList){
            if (GetUserComfirmation($"Are you sure you want to take 1 {_gemBank.GetName(chosenGems[0])}, 1 {_gemBank.GetName(chosenGems[1])}, and 1 {_gemBank.GetName(chosenGems[2])}? (Y/N): ", "Going back.")){
                foreach(int index in chosenGems){
                    TransferPlayerTokens(index, 1, player);
                }
                player.endTurn();
            }
            else{
                foreach(int i in chosenGems){
                    isAvailableList[i] = true;
                }
                chosenGems.Clear();         
            }
        }
    }

    

