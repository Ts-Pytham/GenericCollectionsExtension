namespace GenericCollectionsExtension.Tests.List.SortedList;

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

    [Fact]
    public void SetValueInIndexerCaseOne()
    {
        var sortedListA = new SortedList<int>(Criterion.Ascending)
        {
            20, 10, 40
        };

        var sortedListD = new SortedList<int>(Criterion.Descending)
        {
            20, 10, 40
        };

        sortedListA[0] = 19; // 19, 20, 40
        sortedListD[0] = 25; // 25, 20, 10

        List<int> listA = new() { 19, 20, 40 };
        List<int> listD = new() { 25, 20, 10 };

        Assert.Equal(listA, sortedListA);
        Assert.Equal(listD, sortedListD);


        sortedListA[0] = 100; // 20, 40, 100
        sortedListD[0] = 0; // 20, 10, 0

        Assert.Equal(new List<int>() { 20, 40, 100 }, sortedListA);
        Assert.Equal(new List<int>() { 20, 10, 0 }, sortedListD);

    }


    [Fact]
    public void SetValueInIndexerCaseTwo()
    {
        var sortedListA = new SortedList<int>(Criterion.Ascending)
        {
            20, 10, 40
        };

        var sortedListD = new SortedList<int>(Criterion.Descending)
        {
            20, 10, 40
        };

        sortedListA[2] = 21; // 10, 20, 21
        sortedListD[2] = 19; // 40, 20, 19

        List<int> listA = new() { 10, 20, 21 };
        List<int> listD = new() { 40, 20, 19 };

        Assert.Equal(listA, sortedListA);
        Assert.Equal(listD, sortedListD);

        sortedListA[2] = 0; // 0, 10, 20
        sortedListD[2] = 94; // 94, 40, 20

        Assert.Equal(new List<int>() { 0, 10, 20 }, sortedListA);
        Assert.Equal(new List<int>() { 94, 40, 20 }, sortedListD);
    }

    [Fact]
    public void SetValueInIndexerCaseThree()
    {
        var sortedListA = new SortedList<int>(Criterion.Ascending)
        {
            20, 10, 40, 59, 100, 0
        };

        var sortedListD = new SortedList<int>(Criterion.Descending)
        {
            20, 10, 40, 59, 100, 0
        };

        sortedListA[3] = 105; // 0, 10, 20, 59, 100, 105
        sortedListD[3] = 19; // 100, 59, 40, 19, 10, 0

        List<int> listA = new() { 0, 10, 20, 59, 100, 105 };
        List<int> listD = new() { 100, 59, 40, 19, 10, 0 };

        Assert.Equal(listA, sortedListA);
        Assert.Equal(listD, sortedListD);
    }

    [Fact]
    public void BinarySearchAscending()
    {
        SortedList<int> list = new() { 10, 29, 0, -19, -390, 5 };

        Assert.True(list.BinarySearch(29) != -1);
        Assert.True(list.BinarySearch(500) == -1);
    }

    [Fact]
    public void BinarySearchDescending()
    {
        SortedList<int> list = new(Criterion.Descending) { 10, 29, 0, -19, -390, 5 };

        Assert.True(list.BinarySearch(29) != -1);
        Assert.True(list.BinarySearch(500) == -1);
    }

    [Fact]
    public void ReverseOdd()
    {
        SortedList<int> list = new()
        {
            30, 9, -1, 8, 2
        };

        SortedList<int> listD = new(Criterion.Descending)
        {
            30, 9, -1, 8, 2
        };

        list.Reverse();

        Assert.Equal(listD, list);
    }

    [Fact]
    public void ReverseEven()
    {
        SortedList<int> list = new()
        {
            30, 9, -1, 8
        };

        SortedList<int> listD = new(Criterion.Descending)
        {
            30, 9, -1, 8
        };

        list.Reverse();

        Assert.Equal(listD, list);
    }

    [Fact]
    public void AddRange()
    {
        SortedList<int> list = new();

        list.AddRange(new[] { 59, 10, 2, 5, -2 });

        Assert.Equal(new[] { -2, 2, 5, 10, 59 }, list);
    }

    [Fact]
    public void AddDataToListWithThreads_ShouldSucceed()
    {
        //Arrange
        SortedList<int> list = new();
        var synchronizedList = list.Synchronized();
        var expected = new SortedList<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int len = 10;
        ParallelOptions options = new()
        {
            MaxDegreeOfParallelism = len
        };

        //Act
        Parallel.For(0, len, options, synchronizedList.Add);

        //Asserts
        Assert.Equal(len, list.Count);
        Assert.Equal(expected, list);
    }

    [Fact]
    public void IncrementANumberInList_ShouldSucceed()
    {
        var list = new SortedList<int>() { 0 };
        int maxIter = 10;
        for (int i = 0; i < maxIter; i++)
            list[0]++;

        Assert.Equal(maxIter, list[0]);
    }

    [Fact]
    public void IncrementANumberInListWithThreads_ShouldSucceed()
    {
        //Arrange
        SortedList<int> list = new()
        {
            0
        };
        var synchronizedList = list.Synchronized();
        int len = 2, maxIter = 1;
        ParallelOptions options = new()
        {
            MaxDegreeOfParallelism = len
        };

        //Act
        Parallel.For(0, len, options, i =>
        {
            for (int j = 0; j != maxIter; ++j)
            {
                synchronizedList[0]++;
            }
        });

        //Asserts
        Assert.Equal(maxIter * len, list[0]);
    }
}
