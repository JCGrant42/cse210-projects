public class Library
{
    public List<Book> _books { get; set; }
    //public string last_modified { get; set; }
    //public string lds_slug { get; set; }
    //public string subtitle { get; set; }
    //public List<Testimony> testimonies { get; set; }
    //public string title { get; set; }
    //public TitlePage title_page { get; set; }
    //public int version { get; set; }
}

public class Book
{
    public string _book { get; set; }
    public List<Chapter> _chapters { get; set; }
    public string _full_title { get; set; }
    public string _heading { get; set; }
    public string _lds_slug { get; set; }
    public string _full_subtitle { get; set; }
}

public class Chapter
{
    public int _chapter { get; set; }
    public string _reference { get; set; }
    public List<Verse> _verses { get; set; }
    public string _heading { get; set; }
}

public class Verse
{
    public string _reference { get; set; }
    public string _text { get; set; }
    public int _verse { get; set; }
}

// public class Testimony
// {
//     public string text { get; set; }
//     public string title { get; set; }
//     public List<string> witnesses { get; set; }
// }

// public class TitlePage
// {
//     public string subtitle { get; set; }
//     public List<string> text { get; set; }
//     public string title { get; set; }
//     public string translated_by { get; set; }
// }



