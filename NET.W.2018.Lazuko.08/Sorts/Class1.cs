using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLogic
{
    internal class SortPublishingYearAscendingHelper : IComparer
    {
        int IComparer.Compare(object a, object b)
        {
            Book b1 = (Book)a;
            Book b2 = (Book)b;

            if (b1.PublishingYear > b2.PublishingYear)
                return 1;

            if (b1.PublishingYear < b2.PublishingYear)
                return -1;

            else return 0;
        }

        public static IComparer SortPublishingYearAscending()
        {
            return (IComparer)new SortPublishingYearAscendingHelper();
        }
    }
}
