using System.Collections;

namespace ADV01
{
    #region 1.Create a generic Range<T> class that represents a range of values from a minimum value to a maximum value. 
    public class Range<T> where T : IComparable<T>
    {
        private T min;
        private T max;

        public Range(T min, T max)
        {
            if (min.CompareTo(max) > 0)
            {
                throw new ArgumentException("Minimum value cannot be greater than maximum value.");
            }
            this.min = min;
            this.max = max;
        }

        public bool IsInRange(T value)
        {
            return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
        }

        public T Length()
        {
            dynamic minValue = min;
            dynamic maxValue = max;
            return maxValue - minValue;
        }
    }
    #endregion
    #region 2.You are given an ArrayList containing a sequence of elements. try to reverse the order of elements in the ArrayList in-place(in the same arrayList) without using the built-in Reverse. Implement a function that takes the ArrayList as input and modifies it to have the reversed order of elements.
    public class ArrayListReverser
    {
        public static void Reverse(ArrayList arrayList)
        {
            int start = 0;
            int end = arrayList.Count - 1;

            while (start < end)
            {
                var temp = arrayList[start];
                arrayList[start] = arrayList[end];
                arrayList[end] = temp;
                start++;
                end--;
            }
        }
    }
    #endregion
    #region 3.You are given a list of integers. Your task is to find and return a new list containing only the even numbers from the given list.
    public class EvenNumbersExtractor
    {
        public static List<int> GetEvenNumbers(List<int> numbers)
        {
            List<int> evenNumbers = new List<int>();
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }
            return evenNumbers;
        }
    }
    #endregion
    #region 4.implement a custom list called FixedSizeList<T> with a predetermined capacity. This list should not allow more elements than its capacity and should provide clear messages if one tries to exceed it or access invalid indices.
    public class FixedSizeList<T>
    {
        private List<T> list;
        private int capacity;

        public FixedSizeList(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be greater than zero.");
            }
            this.capacity = capacity;
            this.list = new List<T>();
        }

        public void Add(T item)
        {
            if (list.Count >= capacity)
            {
                throw new InvalidOperationException("Cannot add more elements. The list is full.");
            }
            list.Add(item);
        }

        public T Get(int index)
        {
            if (index < 0 || index >= list.Count)
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }
            return list[index];
        }
    }
    #endregion
    #region 5.Given a string, find the first non-repeated character in it and return its index. If there is no such character, return 
    public class NonRepeatedCharacterFinder
    {
        public static int FindFirstNonRepeatedChar(string input)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in input)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount[c] = 1;
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (charCount[input[i]] == 1)
                {
                    return i;
                }
            }

            return -1;
        }
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            var range = new Range<int>(5, 15);
            Console.WriteLine($"Is 10 in range: {range.IsInRange(10)}"); // True
            Console.WriteLine($"Length of range: {range.Length()}"); // 10

            //2
            var arrayList = new ArrayList { 1, 2, 3, 4, 5 };
            ArrayListReverser.Reverse(arrayList);
            Console.WriteLine("Reversed ArrayList: " + string.Join(", ", arrayList.ToArray()));

            //3
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            var evenNumbers = EvenNumbersExtractor.GetEvenNumbers(numbers);
            Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers));

            //4
            var fixedList = new FixedSizeList<string>(3);
            fixedList.Add("A");
            fixedList.Add("B");
            fixedList.Add("C");
            Console.WriteLine($"Item at index 1: {fixedList.Get(1)}");
            try
            {
                fixedList.Add("D");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //5
            string testString = "swiss";
            int index = NonRepeatedCharacterFinder.FindFirstNonRepeatedChar(testString);
            Console.WriteLine($"First non-repeated character index: {index}");
        }
    }
}
