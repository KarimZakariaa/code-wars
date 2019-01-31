using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_wars
{
    class Program
    {
        static void Main(string[] args)
        {
            //var value = Find(new int[] { 2, 4, 0, 100, 4, 11, 2602, 36 });
            //var val = MaxMultiply(37, 200);
            //var count = GetVowelCount("abracadabra");
            //var balanced = BalancedNumber(32596145);
            //var logic = LogicalCalc(new bool[] { true, true, true, false }, "AND");
            //logic = LogicalCalc(new bool[] { true, true, true, false }, "OR");
            //logic = LogicalCalc(new bool[] { true, true, true, false }, "XOR");
            //var sttat = stat("01|15|59");
            //sttat = stat("");
            var r = Narcissistic(153);
        }


        public static int Find(int[] integers)
        {
            var numOfEven = 0;
            var NoOfOdd = 0;

            for (int i = 0; i < integers.Length; i++)
            {
                if (integers[i] % 2 == 0)
                    numOfEven++;
                else
                    NoOfOdd++;
                if (numOfEven == 2)
                    return integers.Where(a => a % 2 > 0).FirstOrDefault();
                else if (NoOfOdd == 2)
                    return integers.Where(a => a % 2 == 0).FirstOrDefault();

            }
            return -1;
        }


        public static int MaxMultiply(int divisor, int bound)
        {
            return (bound / divisor) * divisor;
        }

        public static int GetVowelCount(string str)
        {
            return str.Count(a => new char[] { 'a', 'e', 'o', 'u', 'i' }.Contains(a));
        }

        public static string BalancedNumber(int number)
        {
            if (number < 10) return "Balanced";
            var numString = number.ToString().ToCharArray();
            var leftNumsCount = 0;
            var rightNumsCount = 0;
            var SumLeft = 0;
            var SumRight = 0;

            if (numString.Length % 2 == 0)
            {
                leftNumsCount = (numString.Length / 2) - 1;
                rightNumsCount = leftNumsCount + 2;
            }
            else
            {
                leftNumsCount = (numString.Length % 2);
                rightNumsCount = leftNumsCount + 1;
            }

            for (int i = 0; i < leftNumsCount; i++)
                SumLeft += (int)numString[i];

            for (int i = rightNumsCount; i < numString.Length; i++)
                SumRight += (int)numString[i];

            if (SumLeft == SumRight) return "Balanced";
            else return "Not Balanced";


        }

        public static int CountRedBeads(int blueBeadsCount)
        {
            return (2 * blueBeadsCount) - 2;
        }

        public static bool LogicalCalc(bool[] array, string op)
        {
            if (op == "AND") return !array.Contains(false) && array.Count(a => a == true) > 0;
            if (op == "OR") return array.Contains(true);
            return array.Count(a => a == true) % 2 > 0;
        }

        public static int ExpressionsMatter(int a, int b, int c)
        {
            if (a == 1 && c == 1) return a + b + c;
            if (a > 1 && b > 1 && c > 1)
                return a * b * c;
            if (a == 1)
                return (a + b) * c;
            if (b == 1)
                return a > c ? a * (b + c) : (a + b) * c;

            return a * (b + c);
        }


        public static string stat(string strg)
        {
            if (string.IsNullOrEmpty(strg)) return string.Empty;
            // your code
            var timess = new List<TimeSpan>();
            foreach (var time in strg.Split(','))
            {
                var h = time.Split('|');
                timess.Add(new TimeSpan(ConvertToInt(h[0]), ConvertToInt(h[1]), ConvertToInt(h[2])));
            }
            timess.Sort();

            var rangeSpan = timess.Count == 1 ? timess[0] : (timess.Max() - timess.Min());
            var range = (rangeSpan.Hours < 10 ? "0" + rangeSpan.Hours : rangeSpan.Hours.ToString()) + "|" +
                (rangeSpan.Minutes < 10 ? "0" + rangeSpan.Minutes : rangeSpan.Minutes.ToString()) + "|" +
                (rangeSpan.Seconds < 10 ? "0" + rangeSpan.Seconds : rangeSpan.Seconds.ToString());

            long sum = 0;
            timess.ForEach(a => sum += a.Ticks);

            var averageSpan = new TimeSpan(sum / timess.Count);
            var average = (averageSpan.Hours < 10 ? "0" + averageSpan.Hours : averageSpan.Hours.ToString()) + "|" +
                (averageSpan.Minutes < 10 ? "0" + averageSpan.Minutes : averageSpan.Minutes.ToString()) + "|" +
                (averageSpan.Seconds < 10 ? "0" + averageSpan.Seconds : averageSpan.Seconds.ToString());

            var medianSpan = new TimeSpan();
            if (timess.Count % 2 == 0)
            {
                medianSpan = new TimeSpan(((timess[(timess.Count / 2) - 1].Add(timess[timess.Count / 2])).Ticks) / 2);
            }
            else
            {
                medianSpan = timess[(timess.Count - 1) / 2];
            }
            var median = (medianSpan.Hours < 10 ? "0" + medianSpan.Hours : medianSpan.Hours.ToString()) + "|" +
                (medianSpan.Minutes < 10 ? "0" + medianSpan.Minutes : medianSpan.Minutes.ToString()) + "|" +
                (medianSpan.Seconds < 10 ? "0" + medianSpan.Seconds : medianSpan.Seconds.ToString());

            return "Range: " + range + " Average: " + average + " Median: " + median;



        }

        static int ConvertToInt(string num)
        {
            var numm = 0;
            int.TryParse(num, out numm);
            return numm;
        }

        public static bool Narcissistic(int value)
        {
            var sum = 0.0;
            var intArray = value.ToString().Select(x => Convert.ToInt32(x.ToString())).ToList();
            intArray.ForEach(a => sum += Math.Pow(a, intArray.Count));
            return sum == value;
        }

    }
}
