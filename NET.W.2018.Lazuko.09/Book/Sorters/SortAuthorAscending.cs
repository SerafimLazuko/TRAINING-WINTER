using System.Collections;

namespace BookLogic.Sorters
{
    public class SortAuthorAscending : IComparer
    {
        public int Compare(object a, object b)
        {
            Book b1 = (Book)a;
            Book b2 = (Book)b;

            return string.Compare(b2.Author, b1.Author);
        }
    }
}
