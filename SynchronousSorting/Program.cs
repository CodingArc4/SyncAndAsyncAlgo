using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace SynchronousSorting
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int[] randomValue = GenerateRandomValues(1, 1000, 500);

            //calls sync methods
            CallBubbleSort(randomValue);
            Console.WriteLine();
            CallingSelectionSort(randomValue);

            Console.WriteLine();

            //calls async methods
            await CallBubbleSortAsync(randomValue);
            Console.WriteLine();
            await CallingSelectionSortAsync(randomValue);

        }

        //public static int[] unsortedList = { 100, 30, 2, 1, 5, 60, 12, 44, 56, 23, 94 };

        //method to generate list of random values
        static int[] GenerateRandomValues(int minValue, int maxValue, int numberOfValues )
        {
            Random random = new Random();
            int[] randomValues = new int[numberOfValues];

            for (int i = 0; i < numberOfValues; i++)
            {
                randomValues[i] = random.Next(minValue, maxValue + 1);
            }

            return randomValues;
        }

        //Bubble Sort implementation
        public static void BubbleSort(int[] unsortedList)
        {
       
            //creating a stopwatch to count the execution time for bubble sort
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int temp;
            for (int i = 0; i < unsortedList.Length - 1; i++)
            {
                 for(int j = 0;j < unsortedList.Length - (1+i);j++)
                 {
                    if (unsortedList[j] > unsortedList[j + 1])
                    {
                        temp = unsortedList[j+1];
                        unsortedList[j+1] = unsortedList[j];
                        unsortedList[j]=temp;
                    }
                  }
            }
            stopwatch.Stop();
            Console.WriteLine("");
            Console.WriteLine("Time took to sync execute bubble sort: " + stopwatch.Elapsed.TotalSeconds);
        }

        //method for printing bubble sort
        public static void CallBubbleSort(int[] list) {
            //int[] unsortedlsit = { 36, 2, 29, 1, 8, 14 };
            //Console.WriteLine("Printing Sync Bubble Sorted List");
            for (int i = 0; i < list.Length; i++)
            {
               // Console.Write($"{list[i]} ");
            }
            BubbleSort(list);
        }

        //method for the selection sort
        public static void SelectionSort(int[] NotSortedList)
        {

            //creating a stopwatch to count the execution time for selection sort
            var stopwatch2 = new Stopwatch();
            stopwatch2.Start();

            int minIndex = 0;
            int MinimumValueFound = 0;

            for(int mainIndex =0; mainIndex < NotSortedList.Length; mainIndex++)
            {
                minIndex = mainIndex;

                for(int RemainingIndex = mainIndex + 1; RemainingIndex < NotSortedList.Length; RemainingIndex++)
                {
                    if (NotSortedList[RemainingIndex] < NotSortedList[minIndex])
                    {
                        minIndex = RemainingIndex;
                    }
                }

                MinimumValueFound = NotSortedList[minIndex];
                NotSortedList[minIndex] = NotSortedList[mainIndex];
                NotSortedList[mainIndex] = MinimumValueFound;
            }

            stopwatch2.Stop();
            Console.WriteLine("");
            Console.WriteLine("Time took to execute sync selection sort: " + stopwatch2.Elapsed.TotalSeconds);
        }

        //method for printing selection sort
        public static void CallingSelectionSort(int[] list)
        {
            //Console.WriteLine("Prinitng Sync Selection Sorted list");
            for(int i = 0; i < list.Length; i++)
            {
                //Console.Write($"{list[i]} ");
            }
            SelectionSort(list);
        }

        //async bubble sort method
        public static async Task BubbleSortAsync(int[] unsortedList)
        {
            var stopwatch3 = new Stopwatch();
            stopwatch3.Start();

            await Task.Run(()=>
            {
                int temp;
                for (int i = 0; i < unsortedList.Length - 1; i++)
                {
                    for (int j = 0; j < unsortedList.Length - (1 + i); j++)
                    {
                        if (unsortedList[j] > unsortedList[j + 1])
                        {
                            temp = unsortedList[j + 1];
                            unsortedList[j + 1] = unsortedList[j];
                            unsortedList[j] = temp;
                        }
                    }
                }
                stopwatch3.Stop();
                Console.WriteLine("");
                Console.WriteLine("Time took to execute Async bubble sort: " + stopwatch3.Elapsed.TotalSeconds);
            });
        }

        //async Selection Sort Method
        public static async Task SelectionSortAsync(int[] NotSortedList)
        {

            //creating a stopwatch to count the execution time for selection sort
            var stopwatch4 = new Stopwatch();
            stopwatch4.Start();

            await Task.Run(() =>
            {

                int minIndex = 0;
                int MinimumValueFound = 0;

                for (int mainIndex = 0; mainIndex < NotSortedList.Length; mainIndex++)
                {
                    minIndex = mainIndex;

                    for (int RemainingIndex = mainIndex + 1; RemainingIndex < NotSortedList.Length; RemainingIndex++)
                    {
                        if (NotSortedList[RemainingIndex] < NotSortedList[minIndex])
                        {
                            minIndex = RemainingIndex;
                        }
                    }

                    MinimumValueFound = NotSortedList[minIndex];
                    NotSortedList[minIndex] = NotSortedList[mainIndex];
                    NotSortedList[mainIndex] = MinimumValueFound;
                }
                stopwatch4.Stop();
                Console.WriteLine("");
                Console.WriteLine("Time took to execute Async selection sort: " + stopwatch4.Elapsed.TotalSeconds);
            });

           
        }

        //Async bubble method print
        public static async Task CallBubbleSortAsync(int[] list)
        {
            //Console.WriteLine("Printing Async Bubble Sorted List");
            await Task.Run(async () =>
             {
                //int[] unsortedlsit = { 36, 2, 29, 1, 8, 14 };
                for (int i = 0; i < list.Length; i++)
                {
                   // Console.Write($"{list[i]} ");
                }
                await BubbleSortAsync(list);
            });
        }

        //async selection sort print
        public static async Task CallingSelectionSortAsync(int[] list)
        {
            //Console.WriteLine("Prinitng Async Selection Sorted list");
            await Task.Run(async () =>
            {
                for (int i = 0; i < list.Length; i++)
                {
                  //  Console.Write($"{list[i]} ");
                }
                await SelectionSortAsync(list);
           });
        }
    }
}