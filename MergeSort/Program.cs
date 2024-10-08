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


// Test that Merge successfully merges 2 lists where 1 item is the same
sorted = Merge(
    new[] { "Alabama", "Florida" },
    new[] { "Alabama", "Delaware" });

// Verify if Merge worked
Debug.Assert(sorted[0] == "Alabama");
Debug.Assert(sorted[1] == "Alabama");
Debug.Assert(sorted[2] == "Delaware");
Debug.Assert(sorted[3] == "Florida");



// Now test the full MergeSort
var items = new[] { "Florida", "Georgia", "Delaware", "Alabama", "Washington", "Delaware" };
MergeSort(items);
Debug.Assert(items[0] == "Alabama");
Debug.Assert(items[1] == "Delaware");
Debug.Assert(items[2] == "Delaware");
Debug.Assert(items[3] == "Florida");
Debug.Assert(items[4] == "Georgia");
Debug.Assert(items[5] == "Washington");

Console.WriteLine("Finished.");

void MergeSort(string[] items)
{
    // TODO - add comment to explain this code
    var sortedLists = new List<string[]>();
    for (int i = 0; i < items.Length; i++)
    {
        sortedLists.Add(new[] { items[i] });
    }

    // TODO - add comment to explain this code
    while (sortedLists.Count > 1)
    {
        int index = 0;
        while (index < sortedLists.Count - 1)
        {
            // TODO - add comment to explain this code
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
        // TODO - Look at the docs for String.Compare and add a comment here.
        var comparison = String.Compare(list1[index1], list2[index2]);
        if (comparison > 0)
        {
            // TODO - update this comment to explain this code
            newlist[indexNewList] = list2[index2];
            indexNewList = indexNewList + 1;
            index2++;
        }
        else if (comparison < 0)
        {
            // TODO - fix this code
            // It will be similar to "comparison > 0" but use list1 instead of list2
            newlist[indexNewList] = list2[index2];
            indexNewList = indexNewList + 1;
            index2++;
        }
        else if (comparison == 0)
        {
            // TODO - fix this block
            // It needs to copy items from both list1 and list2.
            // Think carefully about what indexes need incrementing
            index1++;
        }
    }

    while (index1 < list1.Length)
    {
        newlist[indexNewList++] = list1[index1++];
    }
    while (index2 < list2.Length)
    {
        // TODO - complete this block for list2
        index2++;
    }

    return newlist;
}