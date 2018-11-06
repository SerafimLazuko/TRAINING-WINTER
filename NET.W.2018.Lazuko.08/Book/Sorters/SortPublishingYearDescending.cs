using System.Collections;

namespace BookLogic.Sorters
{
    public class SortPublishingYearDescending : IComparer
    {
        public int Compare(object a, object b)
        {
            Book b1 = (Book)a;
            Book b2 = (Book)b;

            if (b1.PublishingYear < b2.PublishingYear)
                return 1;

            if (b1.PublishingYear > b2.PublishingYear)
                return -1;

            else return 0;
        }
    }
}
