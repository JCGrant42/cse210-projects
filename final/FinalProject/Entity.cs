class Entity{
    private Gems _tokens;
    
    public Entity(string type){
        if (type == "PlayingField"){
            _tokens = new Gems(6, 6, 6, 6, 6, 4);
        }
        if (type == "Player"){
            _tokens = new Gems(0, 0, 0, 0, 0, 0);
        }
    }
    public Gems GetGems(){
        return _tokens;
    }

    // public virtual void Display(){

    // }
    // public virtual string GetPlayerName(){
    //     return "";
    // }
}
