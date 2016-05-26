using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenericPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            //Old arrays implement IEnumerable 
            //So, IEnumerable serves as a bridge between pre-generic collections
            //and generic collections

            //Checking sequence of characters (array of characters) is a palindrome            
            Console.WriteLine("civic is a Palindrome? {0}", IsPalindrome<char>("civic").ToYesNoString());
            Console.WriteLine("level is a Palindrome? {0}", IsPalindrome<char>("level").ToYesNoString());
            Console.WriteLine("madam is a Palindrome? {0}", IsPalindrome<char>("madam").ToYesNoString());

            //Checking sequence of words (array of string) is a palindrome            
            Console.WriteLine("Sequence of words (orange, apple, orange) is a Palindrome? {0}", IsPalindrome<string>(new string[] { "orange", "apple", "orange" }).ToYesNoString());

            //checking if array of integers is a palindrome
            Console.WriteLine("Sequence of Integers (1, 2, 3, 2, 1) is a Palindrome? {0}", IsPalindrome<int>(new int[] { 1, 2, 3, 2, 1 }).ToYesNoString());

            //Checking if array of floats is a palindrome
            Console.WriteLine("Sequence of floats (1.55F, 2.50F, 1.55F) is a Palindrome? {0}", IsPalindrome<float>(new float[] { 1.55F, 2.50F, 1.55F }).ToYesNoString());

            Console.ReadKey();
        }

        private static bool IsPalindrome<T>(IEnumerable<T> inputItems) where T : IComparable
        {
            var stack = new Stack<T>(); //LIFO 

            //push input items into the stack
            var items = inputItems as IList<T> ?? inputItems.ToList();
            foreach (T item in items)
            {
                stack.Push(item);
            }

            for (int i = 0; i < items.Count(); i++)
            {
                if (stack.Pop().CompareTo(items.ElementAt(i)) == 0) //both elements are same
                {
                    continue;
                }
                return false;//elements did not match so its not a palindrome
            }

            return true;
        }


    }
}
