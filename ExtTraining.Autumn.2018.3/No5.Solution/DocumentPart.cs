namespace No5
{
    public abstract class DocumentPart
    {
        public string Text { get; set; }
    }
    
    public class PlainText : DocumentPart { }

    public class Hyperlink : DocumentPart
    {
        public string Url { get; set; }
    }

    public class BoldText : DocumentPart { }
}
