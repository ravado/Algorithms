﻿using IC.Algorithms.Sorting;

int[] unsortedArray = RandomArrayGenerator.GetArray(10); //[1, 9, 2, 93, 4, 5, 2, 5, 100];
int[] sortedArray = [0];

var mergeSorter = new MergeSorter();
Console.WriteLine("Using MergeSorter to sort: \t" + unsortedArray.Format());

sortedArray = mergeSorter.Sort(unsortedArray);
Console.WriteLine($"Sorted: \n{unsortedArray.Format()} \n--> \n{sortedArray.Format()}");

Console.ReadKey();