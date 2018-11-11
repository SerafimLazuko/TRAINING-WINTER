
namespace BubbleSortJaggedArray.Sorts
{
    /// <summary>
    /// interface defining methods for sorting.
    /// </summary>
    public interface ISorter
    {
        /// <summary>
        /// Sort method.
        /// </summary>
        /// <param name="jaggedArray">The jagged array.</param>
        void Sort(int[][] jaggedArray);
    }
}
