class Reference{
    private string _reference;
    private Library _library;
    private string _book;
    private int _bookIndex;
    private int _chapter;
    private int _firstVerse;
    private int _lastVerse;
    private bool _hasLastVerse;
    private bool _isValidReference;


    public Reference(string reference, Library library){
        //set the variables for the reference
        _library = library;
        _reference = reference;
        try{
            //trys to parse the reference
            ParseReference(reference);

            //after parsing, tries to check if the scripture actually exist and it not out of bounds
            if (_lastVerse == 0){
                _lastVerse = _firstVerse;
            }
            //if there are multiple verses then it iterates through each one
            for (int verse = _firstVerse - 1; verse <= _lastVerse - 1; verse++){
                string test = library.books[_bookIndex].chapters[_chapter - 1].verses[verse].text;
            }
            //If the reference is valid the will will be listed as valid
            _isValidReference = true;
        }
        catch{
            //if the reference is not valid then it will display the following and will be listen as not valid
            Console.WriteLine($"'{reference}' is not a vaild reference");
            _isValidReference = false;      
        }
    }

    private void ParseReference(string reference){
        char[] delimiterChars = { ' ', ',', '.', ':', '-' };
        //splits the string, if the array has empty elements ("") then they are removed
        string[] refParts = reference.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

        //checks if the book is numbered
        bool isNumberedbook = int.TryParse(refParts[0], out _);
        int refLen = refParts.Length;

        //if the book is number the reference is parsed slightly differently
        int addIndex = 0;
        if (isNumberedbook) {   
            _book = refParts[0] + " " + UpperCaseFirstChar(refParts[1]);
            //If the reference does include a book number then all other refParts will be push back one, addIndex makes up for this
            addIndex = 1;
        }
        else {   
            _book = UpperCaseFirstChar(refParts[0]);        
        }
        
        //If there is a book number then 1 will be added to all indexes to accommodate for the extra part
        //If there is no book number then Addindex will be zero and do nothing 
        _bookIndex = FindBookIndex();
        _chapter = int.Parse(refParts[1 + addIndex]); 
        _firstVerse = int.Parse(refParts[2 + addIndex]); 
        //If there is a last verse in the reference, adds it to the class.
        if (refParts.Length == 4 + addIndex){
            _hasLastVerse = true;
            _lastVerse = int.Parse(refParts[3 + addIndex]); 
        } 
        else {
            _hasLastVerse = false;
        }
    }

    private int FindBookIndex(){
        //searches through the libary for the first instance of a book, the book is "1 Nephi" then it will be 0, if "Alma" then 8
        int index = 0;
        foreach (Book testbook in _library.books){
            if (testbook.book == _book)
            {
                break;
            }
            index++;
        }
        return index;
    }

    public bool GetIsValid(){
        return _isValidReference;
    }
    public int GetChapter(){
        return _chapter;
    }
    public int GetFirstVerse(){
        return _firstVerse;
    }
    public int GetLastVerse(){
        return _lastVerse;
    }

    public bool GetHasLastVerse(){
        return _hasLastVerse;
    }
    public int GetBookIndex(){
        return _bookIndex;
    }


    public void DisplayReference(){
        if (_hasLastVerse) {
            Console.WriteLine($"{_book} {_chapter}:{_firstVerse}-{_lastVerse}");
        }
        else{
            Console.WriteLine($"{_book} {_chapter}:{_firstVerse}");
        }
    }

    public string UpperCaseFirstChar(string s)
    //For making the book name capatialized in case the user doesn't do so. 
    {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        char[] a = s.ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
    }

}