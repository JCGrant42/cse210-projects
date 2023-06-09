
    public class Book
    {
        public string book { get; set; }
        public List<Chapter> chapters { get; set; }
        public string full_title { get; set; }
        public string heading { get; set; }
        public string lds_slug { get; set; }
        public string full_subtitle { get; set; }
    }

    public class Chapter
    {
        public int chapter { get; set; }
        public string reference { get; set; }
        public List<Verse> verses { get; set; }
        public string heading { get; set; }
    }

    public class Library
    {
        public List<Book> books { get; set; }
        public string last_modified { get; set; }
        public string lds_slug { get; set; }
        public string subtitle { get; set; }
        public List<Testimony> testimonies { get; set; }
        public string title { get; set; }
        public TitlePage title_page { get; set; }
        public int version { get; set; }
    }

    public class Testimony
    {
        public string text { get; set; }
        public string title { get; set; }
        public List<string> witnesses { get; set; }
    }

    public class TitlePage
    {
        public string subtitle { get; set; }
        public List<string> text { get; set; }
        public string title { get; set; }
        public string translated_by { get; set; }
    }

    public class Verse
    {
        public string reference { get; set; }
        public string text { get; set; }
        public int verse { get; set; }
    }

