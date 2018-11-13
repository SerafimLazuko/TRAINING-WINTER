
namespace BookLogic.Matches
{
    public class NameMatches : IMatcher
    {
        bool IMatcher.IsEqual(Book book1, Book book2)
        {
            return book1.Name.Equals(book2.Name);
        }

        bool IMatcher.IsMatch(Book book, string tag)
        {
            return book.Name.Equals(tag);
        }
    }
}
