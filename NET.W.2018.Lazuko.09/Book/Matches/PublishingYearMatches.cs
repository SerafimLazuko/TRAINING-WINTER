
namespace BookLogic.Matches
{
    public class PublishingYearMatches : IMatcher
    {
        bool IMatcher.IsEqual(Book book1, Book book2)
        {
            return book1.PublishingYear.Equals(book2.PublishingYear);
        }

        bool IMatcher.IsMatch(Book book, string tag)
        {
            return book.PublishingYear.Equals(tag);
        }
    }
}
