namespace BookLogic.Matches
{
    public interface IMatcher 
    {
        bool IsEqual(Book book1, Book book2);
        bool IsMatch(Book book, string tag);
    }
}
