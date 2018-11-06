
namespace BookLogic.Matches
{
    public class PriceMatches : IMatcher
    {
        bool IMatcher.IsEqual(Book book1, Book book2)
        {
            return book1.Price.Equals(book2.Price);
        }

        bool IMatcher.IsMatch(Book book, string tag)
        {
            return book.Price.ToString().Equals(tag);
        }
    }
}
