﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogic.Matches
{
    public class AuthorMatches : IMatcher
    {
        bool IMatcher.IsEqual(Book book1, Book book2)
        {
            return book1.Author.Equals(book2.Author);
        }

        bool IMatcher.IsMatch(Book book, string tag)
        {
            return book.Author.Equals(tag);
        }
    }
}
