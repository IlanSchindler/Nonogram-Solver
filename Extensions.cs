namespace Nonogram_Solver;

public static class Extensions
{

    public static T[] getRow<T>(T[,] values, int rowIndex)
    {
        T[] row = Enumerable.Range(0, values.GetUpperBound(1) + 1)
                      .Select(i => values[rowIndex, i])
                      .ToArray();
        return row;
    }


    public static T[] getCol<T>(T[,] values, int colIndex)
    {
        T[] col = Enumerable.Range(0, values.GetUpperBound(0) + 1)
                      .Select(i => values[i, colIndex])
                      .ToArray();
        return col;
    }

    public static int[,] listTo2D(List<List<int>> inList)
    {
        int[,] returnArr = new int[inList.Count, inList[0].Count];
        for (int i = 0; i < inList.Count; i++)
        {
            for (int j = 0; j < inList[i].Count; j++)
            {
                returnArr[i, j] = inList[i][j];
            }
        }
        return returnArr;
    }

    public static List<string> generateRestrictionStrings(List<int> ints, int size)
    {
        List<string> returnStrings = new List<string>();
        string baseString = "";
        foreach (int i in ints)
        {
            if (!string.IsNullOrEmpty(baseString))
                baseString = baseString + "0";
            for (int j = 0; j < i; j++)
            {
                baseString = baseString + "1";
            }

        }
        int zeros = size - baseString.Length;
        for (int i = baseString.Length; i < size; i++)
        {
            baseString = baseString + "0";
        }

        returnStrings.Add(baseString);

        List<string> testStrings = new List<string>();
        testStrings.Add(baseString);
        List<string> nextStrings = new List<string>();
        string baseTest = "";
        for (int i = 0; i < zeros; i++)
        {
            nextStrings.RemoveAll(x => true);
            foreach (string testString in testStrings)
            {
                if (testString.Last() != '0') continue;
                baseTest = testString.Substring(0, testString.Length - 1);
                for (int j = 0; j >= 0; j = baseTest.IndexOf('0', baseTest.IndexOf('1', j)))
                {
                    if (baseTest.IndexOf("1", j) == -1)
                        break;
                    nextStrings.Add(baseTest.Insert(j, "0"));
                }
            }
            returnStrings.AddRange(nextStrings.Distinct());
            testStrings.RemoveAll(x => true);
            testStrings.AddRange(nextStrings.Distinct());
        }

        return returnStrings;
    }

    public static List<List<int>> stringsToIntLists(List<string> inList){
        List<List<int>> returnList = new List<List<int>>();
        foreach(string s in inList){
            List<int> stringList = new List<int>();
            foreach(char c in s){
                stringList.Add((int)char.GetNumericValue(c));
            }
            returnList.Add(stringList);
        }
        return returnList;
    }
}