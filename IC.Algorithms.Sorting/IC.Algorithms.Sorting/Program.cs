using IC.Algorithms.Sorting;

int[] unsortedArray = [1, 9, 2, 93, 4, 5, 2, 5];
int[] sortedArray = [0];

var mergeSorter = new MergeSorter();
Console.WriteLine("Using MergeSorter to sort: \t" + string.Join(", ", unsortedArray));

sortedArray = mergeSorter.Sort(unsortedArray);
Console.WriteLine("Sorted: \t\t\t" + string.Join(", ", sortedArray));

Console.ReadKey();