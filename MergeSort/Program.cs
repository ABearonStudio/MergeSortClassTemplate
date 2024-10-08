// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

// 1st test that Merge successfully merges 2 lists
var sorted = Merge(
    new[] { "Florida", "Georgia" },
    new[] { "Alabama", "Delaware" });

// Verify if Merge worked
Debug.Assert(sorted[0] == "Alabama");
Debug.Assert(sorted[1] == "Delaware");
Debug.Assert(sorted[2] == "Florida");
Debug.Assert(sorted[3] == "Georgia");

// Now test the full MergeSort
var items = new[] { "Florida", "Georgia", "Delaware", "Alabama" };
MergeSort(items);
Debug.Assert(items[0] == "Alabama");
Debug.Assert(items[1] == "Delaware");
Debug.Assert(items[2] == "Florida");
Debug.Assert(items[3] == "Georgia");

Console.WriteLine("Finished.  All items sorted successfully.");

void MergeSort(string[] items)
{
    var sortedLists = new List<string[]>();
    for (int i = 0; i < items.Length; i++)
    {
        sortedLists.Add(new[] { items[i] });
    }

    while (sortedLists.Count > 1)
    {
        int index = 0;
        while (index < sortedLists.Count - 1)
        {
            var sortedList = Merge(sortedLists[index], sortedLists[index + 1]);
            sortedLists[index] = sortedList;
            sortedLists.RemoveAt(index + 1);
            index++;
        }
    }

    for (int i = 0; i < items.Length; i++)
    {
        items[i] = sortedLists[0][i];
    }
}

string[] Merge(string[] list1, string[] list2)
{
    var newlist = new string[list1.Length + list2.Length];
    var indexNewList = 0;
    var index1 = 0;
    var index2 = 0;

    while (index1 < list1.Length && index2 < list2.Length)
    {
        var comparison = String.Compare(list1[index1], list2[index2]);
        if (comparison > 0)
        {
            newlist[indexNewList] = list2[index2];
            indexNewList = indexNewList + 1;
            index2++;
        }
        else if (comparison < 0)
        {
            newlist[indexNewList] = list1[index1];
            indexNewList = indexNewList + 1;
            index1++;
        }
        else if (comparison == 0)
        {
            newlist[indexNewList] = list1[index1];
            newlist[indexNewList] = list2[index2];
            indexNewList = indexNewList + 2;
            index1++;
            index2++;
        }
    }

    while (index1 < list1.Length)
    {
        newlist[indexNewList++] = list1[index1++];
    }
    while (index2 < list2.Length)
    {
        newlist[indexNewList++] = list2[index2++];
    }

    return newlist;
}