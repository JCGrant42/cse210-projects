class Scripture{
    private Reference _reference;
    private List<Word> _scripture = new List<Word>();
    private string _text;
    private Library _library;
    private List<int> _hiddenWordIndex = new List<int>();
    private List<int> _revealedWordIndex = new List<int>();
    private Random _randomGenerator = new Random();
    private bool _isHidden;


    public Scripture(Reference reference, Library library){
        //sets the scriptures information
        _library = library;
        _reference = reference;
        _isHidden = false;
        //gets the texts using the reference information and then splits the words in the text
        _text = GetScriptureText(reference, library);
        SplitWords();
    }

    private string GetScriptureText(Reference reference, Library library){
        string text = "";
        //uses referenece methods to get indexes for the scripture text
        int bookIndex = reference.GetBookIndex();
        int chapIndex = reference.GetChapter() - 1;
        int firstIndex = reference.GetFirstVerse() - 1;
        int lastIndex = reference.GetLastVerse() - 1;

        //the scripture text is built slightly differently based on if there is one or multiple verses
        if (reference.GetHasLastVerse()){
            //If multiple, it iterates through each verse until it gets to the last verse
            for (int verse = firstIndex; verse <= lastIndex; verse++){
                text += $" {library.books[bookIndex].chapters[chapIndex].verses[verse].text} \n";
            }
        } 
        else{
            //If single, is simply saves the text 
            text = $" {library.books[bookIndex].chapters[chapIndex].verses[firstIndex].text}";
        }
        return text;
    }

    private void SplitWords(){
        //splits the words based on spaces, this leaves any punctuation (,.;-) in the word, this is on purpose.    
        string[] words = _text.Split(" ");
        int IndexCounter = 0;
        //for each word a new word class is created and added to the scripture list 
        foreach (string word in words){
            Word w = new Word(word);
            _scripture.Add(w);
            //creates a list of indexs for each word that is in the scripture (1, 2 ,3 .. 51, 52.. ect)
            _revealedWordIndex.Add(IndexCounter);
            IndexCounter++;
        }
    } 

    public void DisplayScripture(){
        //display reference
        _reference.DisplayReference();

        //Starts by outputing the current verse once
        int currentverse = _reference.GetFirstVerse();
        Console.Write($"{currentverse}");

        foreach (Word word in _scripture){
            //If the program read a new line and it is not on the last verse, 
            if (word.GetWord() == "\n" && (currentverse != _reference.GetLastVerse())){
                //then it will plus one to the verse, move to the next line and display the verse number.
                currentverse++;
                Console.Write($"\n{currentverse} ");
            }
            //If the word is not a new line then it will simply display the current word. 
            else{
                word.DisplayWord();
            }
        }
    } 

    public bool IsHidden(){
        //Checks if all words are hidden
        //_revealedWordIndex will be empty if all revealed words have been hidden
        if (_revealedWordIndex.Count == 0){
            _isHidden = true;
        }
        return _isHidden;
    } 

    public void HideRandomWords(){
        //choose random amount of words to hide and then calls HideWord()
        int amount = _randomGenerator.Next(2, 4);
        for ( int i = 0; i < amount; i++){
            HideWord();
        }
    } 

    public void HideWord(){
        //Will only run if there are still words that can be hidden
        if (_revealedWordIndex.Count != 0){
            int randomIndex = _randomGenerator.Next(_revealedWordIndex.Count); //1.
            int wordIndex = _revealedWordIndex[randomIndex]; //2.
            _revealedWordIndex.RemoveAt(randomIndex); //3.
            _hiddenWordIndex.Add(wordIndex);
            Word word = _scripture[wordIndex]; //4.
            word.HideWord(); 

            //1. Chooses a random number based on how many words are still showing (if there are only 5 words showing it will choose between 0-4)
            //2. Based on that random index number(1-5), it then finds the index number for the word that is still revealed in _revealedWordIndex (8, 32, 56, 60, 71)
            //For examplt if the random number was 1 then it would take the number of 8 (if 3 then 56, if 5 then 71) 
            //3. It then removes that word's index number (8, 56, or 71) from _revealedWordIndex and adds it to _hiddenWordIndex
            //_revealedWordIndex and _hiddenWordIndex keep track of what is being show and what is being hidden
            //4. It then creates a tempary class for that word (8, 56, or 71) based on the index choosen that was chosen and then hides that wor               
        }
    }

    public void RevealWord(){
        //SAME CODE AS ABOVE FOR HideWord() BUT REVERESED 
        if (_hiddenWordIndex.Count != 0){
            int randomIndex = _randomGenerator.Next(_hiddenWordIndex.Count);
            int wordIndex = _hiddenWordIndex[randomIndex];
            _hiddenWordIndex.RemoveAt(randomIndex);
            _revealedWordIndex.Add(wordIndex);
            Word word = _scripture[wordIndex];
            word.RevealWord();
        }
    }

    public void HideAll(){
        //reset the lists tracking both revealed and hiden words
        _hiddenWordIndex.Clear();
        _revealedWordIndex.Clear();
        int IndexCounter = 0;
        //Goes through each word in the scripture and sets it to hidden 
        foreach (Word word in _scripture){
            word.HideWord();
            //Creates a new _hiddenWordIndex based on how many words are in teh scripture.
            _hiddenWordIndex.Add(IndexCounter);
            IndexCounter++;
        }
        _isHidden = true;
    }

    public void RevealAll(){
        //SAME AS HideAll() but for revealing instead
        _hiddenWordIndex.Clear();
        _revealedWordIndex.Clear();
        int IndexCounter = 0;
        foreach (Word word in _scripture){
            word.RevealWord();
            _revealedWordIndex.Add(IndexCounter);
            IndexCounter++;
        }
        _isHidden = false;
    }

}