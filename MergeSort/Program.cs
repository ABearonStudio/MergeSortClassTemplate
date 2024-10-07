// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");

var items = new[] { "Florida", "Georgia", "Delaware", "Alabama" };


var sorted = Merge(
    new[] { "Florida", "Georgia" },
    new[] { "Alabama", "Delaware" });


Debugger.Break();

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
        newlist[indexNewList++] = list1[index2++];
    }

    return newlist;
}