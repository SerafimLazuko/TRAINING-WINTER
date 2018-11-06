using System.Collections;

namespace BookLogic.Sorters
{
    public class SortAuthorDescending : IComparer
    {
        public int Compare(object a, object b)
        {
            Book b1 = (Book)a;
            Book b2 = (Book)b;

            return string.Compare(b1.Author, b2.Author);
        }
    }
}
