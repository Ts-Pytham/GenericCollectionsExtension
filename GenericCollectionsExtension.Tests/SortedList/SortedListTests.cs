namespace GenericCollectionsExtension.Tests.SortedList;

public class SortedListTests
{
    [Fact]
    public void GetFirstItemSortedAscending()
    {
        var sortedList = new SortedList<int>
        {
            20, 10, 40
        };

        bool firstNumberSorted = 10 == sortedList[0];

        Assert.True(firstNumberSorted);
    }

    [Fact]
    public void GetFirstItemSortedDescending()
    {
        var sortedList = new SortedList<int>(Criterion.Descending)
        {
            20, 10, 40
        };

        bool firstNumberSorted = 40 == sortedList[0];

        Assert.True(firstNumberSorted);
    }

    [Fact]
    public void CheckSortedListAscending()
    {
        var checkSortedList = new SortedList<int>
        {
            20, 10, 40
        };

        var sortedList = new List<int>
        {
            20, 10, 40
        };

        bool equalsList = checkSortedList.SequenceEqual(sortedList.Order());

        Assert.True(equalsList);
    }

    [Fact]
    public void CheckSortedListDescending()
    {
        var checkSortedList = new SortedList<int>(Criterion.Descending)
        {
            20, 10, 40
        };

        var sortedList = new List<int>
        {
            20, 10, 40
        };

        bool equalsList = checkSortedList.SequenceEqual(sortedList.OrderByDescending(x => x));

        Assert.True(equalsList);
    }
}
