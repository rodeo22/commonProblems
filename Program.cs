using System;
using System.Collections.Generic;

namespace PracticeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 2, 1 };
            //RemoveDuplicate(arr);
            //MaxProfit(arr);
            //RotateArray(arr, 2);
            //Console.WriteLine(ContainsDuplicate(arr));
            //SingleNonDuplicate(arr);
            //ReverseString(new char[] { 'H','a','n','n','a','h'});
            //ReverseInt(2147483640);
            //FirstUniqueChar("aabbc");
            //Console.WriteLine(CheckAnagram("anagram", "nagaram"));
            Console.WriteLine(IsPalindrome("race a car"));
            Console.ReadLine();
        }

        private static void RemoveDuplicate(int[] arr)
        {
            if (arr.Length == 0 || arr.Length == 1) Console.WriteLine("Array length is too short to find duplicates");
            int[] newArr = new int[arr.Length];
            int k = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] != arr[i + 1])
                    newArr[k++] = arr[i];
            }
            newArr[k++] = arr[arr.Length - 1];
            for (int i = 0; i < k; i++)
            {
                Console.WriteLine(newArr[i]);
            }
        }

        public static void MaxProfit(int[] arr)
        {
            int maxDiff = MaxDiff(arr);
            int totalProfit = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] < arr[i + 1])
                    totalProfit += (arr[i + 1] - arr[i]);
            }
            Console.WriteLine("Total Profit is Rs." + (maxDiff > totalProfit ? maxDiff : totalProfit) );
        }

        private static int MaxDiff(int[] arr)
        {
            int max = arr[0], min = arr[0], maxPos = 0, minPos = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max) { max = arr[i]; maxPos = i; }
                if (arr[i] < min) { min = arr[i]; minPos = i; }
            }
            if (maxPos > minPos)
                return max - min;
            return 0;
        }

        public static void RotateArray(int[] arr, int number)
        {
            int start = arr.Length - number;
            int[] newArr = new int[arr.Length];
            int k = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (start < arr.Length)
                    newArr[i] = arr[start++];
                else
                    newArr[i] = arr[k++];
                Console.WriteLine(newArr[i]);
            }
        }

        public static bool ContainsDuplicate(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                        return true;
                }
            }
            return false;
        }

        public static void SingleNonDuplicate(int[] arr)
        {
            int j = 0, flag = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                        flag = 1;
                }
                if (flag == 0)
                    Console.WriteLine(arr[i]);
                flag = 0;
            }
        }

        /// <summary>
        /// This reverse string has space complexity of o(1) becasue space requirement is constant irrespective of input length 
        /// </summary>
        /// <param name="str"></param>
        public static void ReverseString(char[] str)
        {
            int start = 0;
            int end = str.Length - 1;
            while(start<end)
            {
                str = Swap(str, start, end);
                start++;
                end--;
            }
            Console.WriteLine(new string(str));
        }

        private static char[] Swap(char[] str, int start, int end)
        {
            char temp = str[start];
            str[start] = str[end];
            str[end] = temp;
            return str;
        }

        public static void ReverseInt(int number)
        {
            int revNumber = 0, prevRevNumber = 0;
            bool isNegative = false;
            if (number < 0) { isNegative = true; number = -number; }
            while (number != 0)
            {
                revNumber = revNumber * 10 + number % 10;
                if (revNumber / 10 != prevRevNumber)
                {
                    Console.WriteLine("Overflow");
                    return;
                }
                prevRevNumber = revNumber;
                number = number / 10;
            }
            revNumber = isNegative ? -revNumber : revNumber;
            Console.WriteLine(revNumber);
        }

        /// <summary>
        /// Space complexity can be O(log n) as tempString size can be <= input word
        /// Time complexity would be O(n) as we have one loop traversing through all the string characters 
        /// </summary>
        /// <param name="word"></param>
        public static void FirstUniqueChar(string word)
        {
                char[] wordArr = word.ToCharArray();
                string tempString = "";
                int i = 0;
                for (; i < wordArr.Length; i++)
                {
                    if (word.Substring(i + 1).Contains(wordArr[i]) || tempString.Contains(wordArr[i]))
                    {
                        if (!tempString.Contains(wordArr[i])) tempString += wordArr[i];
                        continue;
                    }
                    Console.WriteLine($"char is {wordArr[i]} and index is {i}");
                    break;
                }
                if (i == wordArr.Length) Console.WriteLine("-1");
        }

        public static bool CheckAnagram(string first, string second)
        {
            if (first.Length != second.Length) return false;
            char[] firstArr = first.ToCharArray();
            for (int i = 0; i < firstArr.Length; i++)
            {
                if(second.Contains(firstArr[i]))
                {
                    second = second.Remove(second.IndexOf(firstArr[i]), 1);
                }
            }
            if (second.Length == 0) return true;
            return false;
        }

        public static bool IsPalindrome(string s)
        {
            s = s.ToLower().Replace(" ", "");
            char[] arr = s.ToCharArray();
            int k = arr.Length - 1, i = 0;
            for (; i<=k; i++)
            {
                if((arr[i] >= 48 && arr[i] <= 57) || (arr[i] >= 65 && arr[i] <= 90) || (arr[i] >= 97 && arr[i] <= 122) )
                {
                    if (!((arr[k] >= 48 && arr[k] <= 57) || (arr[k] >= 65 && arr[k] <= 90) || (arr[k] >= 97 && arr[k] <= 122))) k--;
                    if (arr[i] == arr[k])
                    {
                        k--;
                        continue;
                    }
                    else return false;
                }
            }
            return true;
        }
    }
}
