class Word{
    private string _text; 
    private string _activeWord;
    private string _blankspace;


    public Word(string word){
        //Sets the active word and creates a black space for when it needs to be hidden
        _text = word;
        _activeWord = word;
        createBlank();
    }

    private void createBlank(){
        //Create a blackspace for the word based on how many letters are in the word (punctuation ",.;-" is include in words but will not be included in the blank space)
        foreach (char c in _text){
            if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')){
                _blankspace += "_";
            }
        }
    }
    public string GetWord(){
        return _text;
    }

    public void HideWord(){
        //Hides the word
        _activeWord = _blankspace;
    }
    public void RevealWord(){
        //Reveals the word
        _activeWord = _text;
    }

    public void DisplayWord(){
            Console.Write($"{_activeWord} ");
    }
}
