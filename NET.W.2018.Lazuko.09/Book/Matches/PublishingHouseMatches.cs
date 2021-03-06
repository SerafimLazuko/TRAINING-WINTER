﻿
namespace BookLogic.Matches
{
    public class PublishingHouseMatches : IMatcher
    {
        bool IMatcher.IsEqual(Book book1, Book book2)
        {
            return book1.PublishingHouse.Equals(book2.PublishingHouse);
        }

        bool IMatcher.IsMatch(Book book, string tag)
        {
            return book.PublishingHouse.Equals(tag);
        }
    }
}
