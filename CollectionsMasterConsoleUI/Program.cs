using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            //TODO: Create an integer Array of size 50
            int[] toFifty = new int[50];

            //TODO: Create a method to populate the number array with 50 random numbers that are between 0 and 50
            for (int i = 0; i < 50; i++)
            {
                toFifty[i] = Populater(toFifty);
            }

            //TODO: Print the first number of the array
            Console.WriteLine(toFifty[0]);

            //TODO: Print the last number of the array
            Console.WriteLine(toFifty[toFifty.Length - 1]);            

            Console.WriteLine("All Numbers Original");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(toFifty);
            Console.WriteLine("-------------------");

            //TODO: Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____(); 
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
            */

            Console.WriteLine("All Numbers Reversed:");
            NumberPrinter(toFifty.Reverse());

            Console.WriteLine("---------REVERSE CUSTOM------------");
            ReverseArray(toFifty);
            NumberPrinter(toFifty);

            Console.WriteLine("-------------------");

            //TODO: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(toFifty);

            Console.WriteLine("-------------------");

            //TODO: Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            Array.Sort(toFifty);
            foreach (int number in toFifty)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //TODO: Create an integer List
            List<int> manyIntegers = new List<int>();

            //TODO: Print the capacity of the list to the console
            Console.WriteLine(manyIntegers.Capacity);

            //TODO: Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            for (int i = 0; i < 50; i++)
            {
                manyIntegers.Add(Populater(manyIntegers));
            }

            //TODO: Print the new capacity
            Console.WriteLine(manyIntegers.Capacity);

            Console.WriteLine("---------------------");

            //TODO: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            Console.WriteLine("What number will you search for in the number list?");
            NumberChecker(manyIntegers);
            
            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(manyIntegers);
            Console.WriteLine("-------------------");


            //TODO: Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            OddKiller(manyIntegers);
            NumberPrinter(manyIntegers);
            Console.WriteLine("------------------");

            //TODO: Sort the list then print results
            Console.WriteLine("Sorted Evens!!");
            manyIntegers.Sort();
            NumberPrinter(manyIntegers);
            Console.WriteLine("------------------");

            //TODO: Convert the list to an array and store that into a variable
            int[] integerArray = manyIntegers.ToArray();

            //TODO: Clear the list
            manyIntegers.Clear();
            

            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (i % 3 == 0)
                {
                    numbers[i] = 0; 
                }
            }
            NumberPrinter(numbers);
        }

        private static void OddKiller(List<int> numberList)
        {
            for (int i = numberList.Count - 1; i >= 0; i--)
            {
                if (numberList[i] % 2 != 0)
                {
                    numberList.Remove(numberList[i]);
                }
                else
                {
                    continue;
                }
            }
        }

        private static void NumberChecker(List<int> numberList)
        {

            var input = Console.ReadLine();
            var isNumber = int.TryParse(input, out int searchNumber);
            var isNumberHere = numberList.Contains(searchNumber);
            if (searchNumber < 0 || searchNumber > 50 || isNumber == false)
            {
                Console.WriteLine("My list only contains numbers 0 - 50");
                NumberChecker(numberList);
            }
            else if (isNumberHere == true)
            {
                Console.WriteLine($"{searchNumber} is on the list");
            }
            else if (isNumberHere == false)
            {
                Console.WriteLine($"{searchNumber} is not on the list. Would you like to add it?");
                var willAdd = Console.ReadLine();
                if (willAdd == "yes" || willAdd == "Yes")
                {
                    numberList.Add(searchNumber);
                }
                else
                {
                    Console.WriteLine("Ok, I won't add it.");
                }
            }
        }

        private static int Populater(List<int> numberList)
        {
            Random rng = new Random();
            return rng.Next(50);
        }

        private static int Populater(int[] numbers)
        {
            Random rng = new Random();
            return rng.Next(50);
        }        

        private static void ReverseArray(int[] array)
        {
            int temp = 0;
            for (int i = 0; i < array.Length / 2; i++)
            {
                temp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = temp;
            }
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
