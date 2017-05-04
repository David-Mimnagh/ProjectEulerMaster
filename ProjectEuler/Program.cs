using BigNumber;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Numerics;
using System.Management;
namespace ProjectEuler
{
    static class Program
    {
        /// <summary>
        /// Multiples of 3 and 5
        /// </summary>
        /// <param name="max"></param>
        /// <param name="mult1"></param>
        /// <param name="mult2"></param>
        /// <returns></returns>
        private static int CalculateProblemOne(int max, int mult1, int mult2)
        {
            int sum = 0;
            int current1 = 0; int current2 = 0;
            List<int> list = new List<int>();
            for ( int i = 1; i < max; i++ )
            {
                current1 = i * mult1;
                if ( current1 < max )
                {
                    if ( !list.Contains(current1) )
                    {
                        list.Add(current1);
                        Console.Write("\nThe value is: " + current1);
                    }
                }

                current2 = i * mult2;
                if ( current2 < max )
                {
                    if ( current1 != current2 )
                    {
                        if ( !list.Contains(current2) )
                        {
                            list.Add(current2);
                            Console.Write("\nThe value is: " + current2);
                        }
                    }
                }
            }


            foreach ( var i in list )
            {
                sum += i;
            }
            return sum;

        }


        /// <summary>
        /// Even Fibonacci numbers
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
        private static int CalculateProblemTwo(int max, int start1, int start2)
        {
            int sum = 0;
            List<int> evenNum = new List<int>();
            int numCurrent = 0;
            if ( start2 == 2 )
                evenNum.Add(start2);
            while ( numCurrent < 4000000 )
            {
                numCurrent = start1 + start2;
                start1 = start2; start2 = numCurrent;

                if ( !IsOdd(numCurrent) )
                {
                    Console.Write("\nValue: " + numCurrent);
                    evenNum.Add(numCurrent);
                }

            }
            foreach ( var i in evenNum )
            {
                sum += i;
            }
            return sum;
        }

        /// <summary>
        /// Largest Prime Factor
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static List<int> Generate(long number)
        {
            var primes = new List<int>();

            for ( int div = 2; div <= number; div++ )
            {
                while ( number % div == 0 )
                {
                    primes.Add(div);
                    number = number / div;
                }
            }
            return primes;
        }
        private static int CalculateProblemThree(long num)
        {
            int sum = 0;
            List<int> primes = Generate(num);

            primes = primes.OrderByDescending(x => x).ToList();
            return primes.First();
        }


        /// <summary>
        /// Largest Palindrome Product
        /// </summary>
        /// <returns></returns>
        private static int CalculateProblemFour()
        {
            int sum = 0;
            int newVal = 0;
            List<Tuple<int, int, int>> pal = new List<Tuple<int, int, int>>();

            for ( int i = 100; i < 1000; i++ )
            {
                for ( int j = 100; j < 1000; j++ )
                {
                    newVal = i * j;
                    var newString = newVal.ToString();
                    var checkString = "";
                    var newArr = newString.ToCharArray();
                    for ( int c = newArr.Length - 1; c >= 0; c-- )
                    {
                        checkString += newArr[c];
                    }
                    if ( checkString == newString )
                    {
                        pal.Add(new Tuple<int, int, int>(i, j, newVal));
                    }
                }
            }
            var test = pal.OrderByDescending(x => x.Item3);
            return sum;
        }


        /// <summary>
        /// Smallest Multiple
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private static int CalculateProblemFive(int min, int max)
        {
            int num = 0;
            List<int> currentlyTested = new List<int>();
            for ( int sN = 1; sN < Int32.MaxValue; sN++ )
            {
                if ( currentlyTested.Count < max )
                {
                    currentlyTested = new List<int>();
                    for ( int i = min; i <= max; i++ )
                    {
                        if ( ( sN % i == 0 ) )
                            currentlyTested.Add(i);
                    }
                }
                else
                {
                    num = sN - 1;
                    break;
                }
            }

            return num;
        }


        /// <summary>
        /// Sum Square Difference
        /// </summary>
        /// <param name="start"></param>
        /// <param name="fin"></param>
        /// <returns></returns>
        private static int CalculateProblemSix(int start, int fin)
        {
            int difference = 0;


            var currentValueSQ = 0;
            for ( int i = start; i <= fin; i++ )
            {
                currentValueSQ += ( i * i );
            }
            var currentValueSumSQ = 0;

            for ( int i = start; i <= fin; i++ )
            {
                currentValueSumSQ += i;
            }
            currentValueSumSQ = ( currentValueSumSQ * currentValueSumSQ );


            difference = currentValueSumSQ - currentValueSQ;
            return difference;
        }


        /// <summary>
        /// 10001st prime number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static bool IsPrime(int num)
        {
            if ( num == 1 ) return false;
            if ( num == 2 ) return true;

            if ( num % 2 == 0 ) return false;

            for ( int i = 2; i < num; ++i )
            {
                if ( num % i == 0 ) return false;
            }

            return true;
        }
        private static int CalculateProblemSeven(int primeToGet)
        {
            int prime = 0;

            List<int> primes = new List<int>();

            for ( int i = 1; i < Int32.MaxValue; i++ )
            {
                if ( primes.Count < primeToGet )
                {
                    if ( IsPrime(i) )
                    {
                        primes.Add(i);
                    }
                }
                else
                {
                    prime = primes.Last();
                    break;
                }
            }

            return prime;
        }


        /// <summary>
        /// Largest product in a series
        /// </summary>
        /// <param name="adjCount"></param>
        /// <returns></returns>
        private static long CalculateProblemEight(int adjCount)
        {

            long product = 0;
            string number = "73167176531330624919225119674426574742355349194934";
            number += "96983520312774506326239578318016984801869478851843";
            number += "85861560789112949495459501737958331952853208805511";
            number += "12540698747158523863050715693290963295227443043557";
            number += "66896648950445244523161731856403098711121722383113";
            number += "62229893423380308135336276614282806444486645238749";
            number += "30358907296290491560440772390713810515859307960866";
            number += "70172427121883998797908792274921901699720888093776";
            number += "65727333001053367881220235421809751254540594752243";
            number += "52584907711670556013604839586446706324415722155397";
            number += "53697817977846174064955149290862569321978468622482";
            number += "83972241375657056057490261407972968652414535100474";
            number += "82166370484403199890008895243450658541227588666881";
            number += "16427171479924442928230863465674813919123162824586";
            number += "17866458359124566529476545682848912883142607690042";
            number += "24219022671055626321111109370544217506941658960408";
            number += "07198403850962455444362981230987879927244284909188";
            number += "84580156166097919133875499200524063689912560717606";
            number += "05886116467109405077541002256983155200055935729725";
            number += "71636269561882670428252483600823257530420752963450";

            char[] nums = number.ToCharArray();
            List<char> numList = nums.ToList();

            long currentValue = 0;
            List<int> numbers = new List<int>();
            List<long> values = new List<long>();
            var current = 0;
            string copy = "";
            List<Tuple<int[], long>> valueList = new List<Tuple<int[], long>>();

            for ( int i = 0; i < nums.Length - 12; i++ )
            {
                copy += ( (int)Char.GetNumericValue(nums[i]) ).ToString();
                numbers = new List<int>();
                for ( int j = 0; j < adjCount; j++ )
                {
                    numbers.Add((int)Char.GetNumericValue(nums[i + j]));

                }

                if ( numbers.Count == adjCount )
                {
                    currentValue = 0;
                    currentValue = numbers[0];
                    for ( int n = 1; n < numbers.Count; n++ )
                    {
                        currentValue *= numbers[n];
                    }
                    if ( product < currentValue )
                        product = currentValue;

                    Tuple<int[], long> item = new Tuple<int[], long>(numbers.ToArray(), currentValue);
                    valueList.Add(item);
                }
            }




            return product;
        }


        /// <summary>
        /// Special Pythagorean triplet
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        private static Tuple<int, int, int> CalculateProblemNine(int max)
        {
            var val = 0; var a = 0; var b = 0; var c = 0;
            var result = 0;
            for ( a = 1; a < max; a++ )
            {
                for ( b = 1; b < max; b++ )
                {
                    for ( c = 1; c < max; c++ )
                    {
                        result = ( (int)Math.Pow(a, 2) + (int)Math.Pow(b, 2) );
                        if ( result == (int)Math.Pow(c, 2) )
                        {
                            val = a + b + c;
                        }


                        if ( val == max )
                        {
                            break;
                        }
                    }
                    if ( val == max )
                    {
                        break;
                    }
                }
                if ( val == max )
                {
                    break;
                }
            }

            Tuple<int, int, int> abc = new Tuple<int, int, int>(a, b, c);
            return abc;
        }


        /// <summary>
        /// Summation of primes
        /// </summary>
        /// <param name="primesBelow"></param>
        /// <returns></returns>
        private static long CalculateProblemTen(int primesBelow)
        {

            long val = 0;

            for ( int i = 0; i < primesBelow; i++ )
            {
                if ( IsPrime(i) )
                    val += i;
            }
            return val;
        }




        /// <summary>
        /// Largest product in a grid
        /// </summary>
        /// <param name="startI"></param>
        /// <param name="currentJ"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        private static long CheckUp(int startI, int currentJ, int[,] board)
        {
            long product = 0;


            int count = 0;
            product = board[startI, currentJ];
            for ( int i = startI - 1; count < 3; i-- )
            {
                count += 1;
                product *= board[i, currentJ];
            }

            return product;
        }
        private static long CheckDown(int startI, int currentJ, int[,] board)
        {
            long product = 0;


            int count = 0;
            product = board[startI, currentJ];
            for ( int i = startI + 1; count < 3; i++ )
            {
                count += 1;
                product *= board[i, currentJ];
            }

            return product;
        }
        private static long CheckLeft(int currentI, int startJ, int[,] board)
        {
            long product = 0;


            int count = 0;
            product = board[currentI, startJ];
            for ( int j = startJ - 1; count < 3; j-- )
            {
                count += 1;
                product *= board[currentI, j];
            }

            return product;
        }
        private static long CheckRight(int currentI, int startJ, int[,] board)
        {
            long product = 0;


            int count = 0;
            product = board[currentI, startJ];
            for ( int j = startJ + 1; count < 3; j++ )
            {
                count += 1;
                product *= board[currentI, j];
            }

            return product;
        }
        private static long CheckDiagLeft(int startI, int startJ, int[,] board)
        {
            long product = 0;


            int count = 0;
            product = board[startI, startJ];
            for ( int i = startI + 1; count < 3; i++ )
            {
                startJ -= 1;
                count += 1;
                product *= board[i, startJ];
            }

            return product;
        }
        private static long CheckDiagRight(int startI, int startJ, int[,] board)
        {
            long product = 0;


            int count = 0;
            product = board[startI, startJ];
            for ( int i = startI + 1; count < 3; i++ )
            {
                startJ += 1;
                count += 1;
                product *= board[i, startJ];
            }

            return product;
        }
        private static long CalculateProblemEleven()
        {
            long product = 0;

            string boardString = "8 2 22 97 38 15 0 40 0 75 4 5 7 78 52 12 50 77 91 8 ";
            boardString += "49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 4 56 62 0 ";
            boardString += "81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 3 49 13 36 65 ";
            boardString += "52 70 95 23 4 60 11 42 69 24 68 56 1 32 56 71 37 2 36 91 ";
            boardString += "22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80 ";
            boardString += "24 47 32 60 99 3 45 2 44 75 33 53 78 36 84 20 35 17 12 50 ";
            boardString += "32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70 ";
            boardString += "67 26 20 68 2 62 12 20 95 63 94 39 63 8 40 91 66 49 94 21 ";
            boardString += "24 55 58 5 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72 ";
            boardString += "21 36 23 9 75 0 76 44 20 45 35 14 0 61 33 97 34 31 33 95 ";
            boardString += "78 17 53 28 22 75 31 67 15 94 3 80 4 62 16 14 9 53 56 92 ";
            boardString += "16 39 5 42 96 35 31 47 55 58 88 24 0 17 54 24 36 29 85 57 ";
            boardString += "86 56 0 48 35 71 89 7 5 44 44 37 44 60 21 58 51 54 17 58 ";
            boardString += "19 80 81 68 5 94 47 69 28 73 92 13 86 52 17 77 4 89 55 40 ";
            boardString += "4 52 8 83 97 35 99 16 7 97 57 32 16 26 26 79 33 27 98 66 ";
            boardString += "88 36 68 87 57 62 20 72 3 46 33 67 46 55 12 32 63 93 53 69 ";
            boardString += "4 42 16 73 38 25 39 11 24 94 72 18 8 46 29 32 40 62 76 36 ";
            boardString += "20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 4 36 16 ";
            boardString += "20 73 35 29 78 31 90 1 74 31 49 71 48 86 81 16 23 57 5 54 ";
            boardString += "1 70 54 71 83 51 54 69 16 92 33 48 61 43 52 1 89 19 67 48";


            string[] strings = boardString.Split(' ');
            int[] numbers = new int[400];
            for ( int i = 0; i < strings.Length; i++ )
            {
                numbers[i] = Convert.ToInt32(strings[i]);
            }

            var numAdd = 0;
            int[,] board = new int[20, 20];


            for ( int i = 0; i < 20; i++ )
            {
                numAdd = i * 20;
                for ( int j = 0; j < 20; j++ )
                {
                    board[i, j] = numbers[numAdd + j];
                }
            }
            List<long> products = new List<long>();
            for ( int i = 0; i < 20; i++ )
            {
                for ( int j = 0; j < 20; j++ )
                {
                    if ( i >= 3 )
                        products.Add(CheckUp(i, j, board));
                    if ( i <= 16 )
                        products.Add(CheckDown(i, j, board));//> product) ? product = CheckDown(i, j, board) : product = product;
                    if ( j >= 3 )
                        products.Add(CheckLeft(i, j, board));//> product) ? product = CheckLeft(i, j, board) : product = product;
                    if ( j <= 16 )
                        products.Add(CheckRight(i, j, board));//> product) ? product = CheckRight(i, j, board) : product = product;
                    if ( i <= 16 && j >= 3 )
                        products.Add(CheckDiagLeft(i, j, board));//> product) ? product = CheckDiagLeft(i, j, board) : product = product;
                    if ( i <= 16 && j <= 16 )
                        products.Add(CheckDiagRight(i, j, board));//> product) ? product = CheckDiagRight(i, j, board) : product = product;
                }
            }


            product = products.OrderByDescending(x => x).First();
            return product;
        }

        /// <summary>
        /// Triangle numbers
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static List<int> Factor(int number)
        {
            List<int> factors = new List<int>();
            int max = (int)Math.Sqrt(number);  //round down
            for ( int factor = 1; factor <= max; ++factor )
            { //test from 1 to the square root, or the int below it, inclusive.
                if ( number % factor == 0 )
                {
                    factors.Add(factor);
                    if ( factor != number / factor )
                    { // Don't add the square root twice!  Thanks Jon
                        factors.Add(number / factor);
                    }
                }
            }
            return factors;
        }
        private static long CalculateProblemTwelve()
        {
            long value = 0;
            long currentTriangleNumber = 0;

            List<int> divCount = new List<int>();

            while ( value == 0 )
            {
                for ( int i = 1; i < Int32.MaxValue; i++ )
                {
                    currentTriangleNumber = ( i * ( i + 1 ) ) / 2;
                    divCount = Factor((int)currentTriangleNumber);
                    if ( divCount.Count > 500 )
                    {
                        value = currentTriangleNumber;
                        break;
                    }
                }

            }



            return value;
        }

        /// <summary>
        /// Large sum
        /// </summary>
        /// <returns></returns>
        private static BigInteger CalculateProblemThirteen()
        {
            BigInteger value = 0;
            BigInteger total = 0;
            string[] lines = System.IO.File.ReadAllLines(@"../../Files/problem13.txt");
            List<BigInteger> nums = new List<BigInteger>();
            for ( int i = 0; i < lines.Length; i++ )
            {
                value = BigInteger.Parse(lines[i]);
                nums.Add(value);
            }

            foreach ( var n in nums )
            {
                total += n;
            }


            return total;
        }

        /// <summary>
        /// Longest Collatz Sequence
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<long> CollatzConjecture(long value)
        {
            while ( value > 1 )
            {
                value =
                    ( value % 2 ) == 0
                    ? value / 2
                    : value * 3 + 1;

                yield return value;
            }
        }
        private static int CalculateProblemFourteen(int max)
        {
            List<Tuple<int, int>> chainCounts = new List<Tuple<int, int>>();

            for ( int i = 13; i < max; i++ )
            {
                Tuple<int, int> curr = new Tuple<int, int>(i, CollatzConjecture(i).Count());
                chainCounts.Add(curr);
            }

            chainCounts = chainCounts.OrderByDescending(x => x.Item2).ToList();
            return chainCounts.First().Item1;
        }

        /// <summary>
        /// Lattice grid
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private static long CalculateProblemFifteen(int length)
        {
            long count = 0;

            int gridSize = length;
            long paths = 1;

            for ( int i = 0; i < gridSize; i++ )
            {
                paths *= ( 2 * gridSize ) - i;
                paths /= i + 1;
            }
            count = paths;
            return count;
        }

        /// <summary>
        /// Power sum
        /// </summary>
        /// <param name="pow"></param>
        /// <returns></returns>
        private static long CalculateProblemSixteen(int pow)
        {
            long sum = 0;
            string power = BigInteger.Pow(2, pow).ToString();
            foreach ( var p in power )
            {
                sum += (long)Char.GetNumericValue(p);
            }
            return sum;
        }

        /// <summary>
        /// Numbers to word sum
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string NumberToWords(int number)
        {
            if ( number == 0 )
                return "zero";

            if ( number < 0 )
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ( ( number / 1000000 ) > 0 )
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ( ( number / 1000 ) > 0 )
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ( ( number / 100 ) > 0 )
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if ( number > 0 )
            {
                if ( words != "" )
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if ( number < 20 )
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ( ( number % 10 ) > 0 )
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
        private static long CalculateProblemSeventeen(int max)
        {
            long sum = 0;
            string currWord = "";
            for ( int i = 1; i <= max; i++ )
            {
                currWord = NumberToWords(i);

                currWord = currWord.Replace("-", String.Empty);
                currWord = currWord.Replace(" ", String.Empty);
                sum += currWord.Length;
            }
            return sum;
        }


        private static long CalculateProblemEighteen()
        {
            long sum = 0;
            int[,] list = new int[18, 19];
            string input = @"       75
                                95 64
                                17 47 82
                            18 35 87 10
                            20 04 82 47 65
                                19 01 23 75 03 34
                                88 02 77 73 07 63 67
                                99 65 04 28 06 16 70 92
                                41 41 26 56 83 40 80 70 33
                                41 48 72 33 47 32 37 16 94 29
                                53 71 44 65 25 43 91 52 97 51 14
                                70 11 33 28 77 73 17 78 39 68 17 57
                                91 71 52 38 17 14 91 43 58 50 27 29 48
                                63 66 04 68 89 53 67 30 73 16 69 87 40 31
                                04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";
            var charArray = input.Split('\n');

            for ( int i = 0; i < charArray.Length; i++ )
            {
                var numArr = charArray[i].Trim().Split(' ');

                for ( int j = 0; j < numArr.Length; j++ )
                {
                    int number = Convert.ToInt32(numArr[j]);
                    list[i, j] = number;
                }
            }

            for ( int i = 16; i >= 0; i-- )
            {
                for ( int j = 0; j < 18; j++ )
                {
                    list[i, j] = Math.Max(list[i, j] + list[i + 1, j], list[i, j] + list[i + 1, j + 1]);
                }
            }
            sum = list[0, 0];

            return sum;
        }

        private static long CalculateProblemNineteen()
        {
            long sum = 0;

            DateTime date = new DateTime(1901, 1, 1);
            DateTime end = new DateTime(2000, 12, 31);

            while ( date <= end )
            {
                date = date.AddDays(1);
                if ( date.DayOfWeek.ToString() == "Sunday" )
                {
                    if ( date.Day == 1 )
                        sum += 1;
                }
            }

            return sum;
        }

        /// <summary>
        /// Factorial digits
        /// </summary>
        /// <returns></returns>
        private static BigInteger Twenty(int factorialOf)
        {
            BigInteger sum = factorialOf;
            int valueSum = 0;
            for ( int i = 1; i < factorialOf; i++ )
            {
                sum *= ( factorialOf - i );
            }
            string value = sum.ToString();
            foreach ( var c in value )
            {
                valueSum += (int)Char.GetNumericValue(c);
            }
            return valueSum;
        }



        private static BigInteger TwentyOne(int numbersUnder)
        {
            BigInteger sum = 0;


            List<int> divisors = new List<int>();
            List<int> amicableNumbers = new List<int>();


            var divSum = 0;
            for ( int i = 1; i < 550000; i++ )
            {
                divSum = 0;
                divisors = Factor(i); //d(220)
                foreach ( var d in divisors )
                {
                    if ( d != i )
                        divSum += d; // = 284
                }
                if ( divSum < 10000 )
                {
                    divisors = Factor(divSum);
                    var prevDivSum = divSum;
                    divSum = 0;
                    foreach ( var d in divisors )
                    {
                        if ( d != prevDivSum )
                            divSum += d; // = 284
                    }
                    if ( divSum == i )
                    {
                        if ( divSum != prevDivSum )
                            amicableNumbers.Add(i);
                    }
                }
            }


            foreach ( var a in amicableNumbers )
            {
                sum += a;
            }




            return sum;
        }



        private static int AlphabetValue(char c)
        {
            string alphabetString = "abcdefghijklmnopqrstuvwxyz";
            char[] alphaChars = alphabetString.ToCharArray();

            for ( int i = 0; i < alphaChars.Count(); i++ )
            {
                c = Char.ToLower(c);
                if ( alphaChars[i] == c )
                    return i + 1;
            }
            return 0;
        }
        private static BigInteger TwentyTwo()
        {
            BigInteger sum = 0;

            string[] nameString = System.IO.File.ReadAllLines(@"../../Files/problem22.txt");
            string[] names = nameString[0].Split(',');
            for ( int i = 0; i < names.Length; i++ )
            {
                names[i] = names[i].Replace("\"", String.Empty);
            }
            names = names.ToList().OrderBy(n => n).ToList().ToArray();

            List<Tuple<string, int, int, int>> values = new List<Tuple<string, int, int, int>>();
            var charScore = 0;
            var nameScore = 0;

            for ( int i = 0; i < names.Length; i++ )
            {
                charScore = 0; nameScore = 0;
                char[] nameChars = names[i].ToCharArray();

                for ( int j = 0; j < nameChars.Count(); j++ )
                {
                    charScore += AlphabetValue(nameChars[j]);
                }
                nameScore = ( i + 1 ) * charScore;
                values.Add(new Tuple<string, int, int, int>(names[i], i + 1, charScore, nameScore));
            }

            foreach ( var v in values )
            {
                sum += v.Item4;
            }
            return sum;
        }


        private static BigInteger TwentyThree()
        {
            BigInteger sum = 0;
            List<int> numbers = new List<int>();
            List<int> factors = new List<int>();
            List<int> perfects = new List<int>();
            List<int> deficients = new List<int>();
            List<int> abundants = new List<int>();
            for ( int i = 12; i < 28123; i++ )
            {
                numbers.Add(i);
                factors = Factor(i);
                var currentSum = 0;
                foreach ( var f in factors )
                {
                    if ( f != i )
                        currentSum += f;
                }

                if ( currentSum == i )
                    perfects.Add(i);
                else if ( currentSum <= i )
                    deficients.Add(i);
                else
                    abundants.Add(i);
            }




            for ( int i = 0; i < abundants.Count; i++ )
            {
                if ( i == 0 )
                {
                    if ( numbers.Contains(abundants[i] + abundants[i]) )
                        numbers.Remove(abundants[i] + abundants[i]);
                }
                for ( int j = ( i <= abundants.Count - 1 ) ? i + 1 : j = 0; j < abundants.Count; j++ )
                {
                    if ( numbers.Contains(abundants[i] + abundants[j]) )
                        numbers.Remove(abundants[i] + abundants[j]);
                }
            }



            foreach ( var n in numbers )
            {
                sum += n;
            }
            return sum;
        }


        /// <summary>
        /// Lexicographic permutations
        /// </summary>
        /// <returns></returns>
        private class Recursion
        {
            private int elementLevel = -1;
            private int numberOfElements;
            private int[] permutationValue = new int[0];

            private char[] inputSet;
            public char[] InputSet
            {
                get { return inputSet; }
                set { inputSet = value; }
            }
            public List<string> perms = new List<string>();
            private int permutationCount = 0;
            public int PermutationCount
            {
                get { return permutationCount; }
                set { permutationCount = value; }
            }

            public char[] MakeCharArray(string InputString)
            {
                char[] charString = InputString.ToCharArray();
                Array.Resize(ref permutationValue, charString.Length);
                numberOfElements = charString.Length;
                return charString;
            }

            public void CalcPermutation(int k)
            {
                elementLevel++;
                permutationValue.SetValue(elementLevel, k);

                if ( elementLevel == numberOfElements )
                {
                    OutputPermutation(permutationValue);
                }
                else
                {
                    for ( int i = 0; i < numberOfElements; i++ )
                    {
                        if ( permutationValue[i] == 0 )
                        {
                            CalcPermutation(i);
                        }
                    }
                }
                elementLevel--;
                permutationValue.SetValue(0, k);
            }

            private void OutputPermutation(int[] value)
            {
                string local = "";

                foreach ( int i in value )
                {
                    local += inputSet.GetValue(i - 1);
                }
                perms.Add(local);
                PermutationCount++;
            }
        }
        private static BigInteger TwentyFour()
        {
            string num = "0123456789";

            char[] numArrChar = num.ToCharArray();
            int[] numArr = new int[num.Length];
            int length = 1;
            for ( int i = 1; i <= num.Length; i++ )
            {
                length *= i;
            }

            for ( int i = 0; i < num.Length; i++ )
            {
                numArr[i] = (int)Char.GetNumericValue(numArrChar[i]);
            }
            Recursion rec = new Recursion();
            rec.InputSet = rec.MakeCharArray(num);
            rec.CalcPermutation(0);
            List<string> perms = rec.perms;
            perms = perms.OrderBy(x => x).ToList();
            string permAt1Mil2 = perms[999999];
            BigInteger sum = 0;




            return sum;
        }


        /// <summary>
        /// 1000-digit Fibonacci number
        /// </summary>
        /// <param name="args"></param>
        static List<BigInteger> fibNums = new List<BigInteger>();
        static BigInteger FibonacciNum(int num)
        {
            if ( num == 1 || num == 2 )
                return fibNums[num - 1];
            else
            {
                int index = num - 1;
                BigInteger newNum = ( fibNums[index - 1] + fibNums[index - 2] );
                fibNums.Add(newNum);
                return newNum;
            }
        }
        private static BigInteger TwentyFive()
        {
            BigInteger fibNum = 0;
            fibNums.Add(1);
            fibNums.Add(1);

            for ( int i = 1; i < Int32.MaxValue; i++ )
            {
                fibNum = FibonacciNum(i);
                if ( fibNum.ToString().Length == 1000 )
                {
                    fibNum = i;
                    break;
                }
            }

            return fibNum;
        }


        static BigInteger TwentySix()
        {
            int sequenceLength = 0;
            BigInteger recipNum = 0;
            for ( int i = 1000; i > 1; i-- )
            {
                if ( sequenceLength >= i )
                {
                    break;
                }

                int[] foundRemainders = new int[i];
                int value = 1;
                int position = 0;

                while ( foundRemainders[value] == 0 && value != 0 )
                {
                    foundRemainders[value] = position;
                    value *= 10;
                    value %= i;
                    position++;
                }

                if ( position - foundRemainders[value] > sequenceLength )
                {
                    sequenceLength = position - foundRemainders[value];
                    recipNum = position;
                }
            }

            return recipNum;
        }

        static BigInteger TwentySeven()
        {
            BigInteger sum = 0;
            int aMax = 0, bMax = 0, nMax = 0;
            //int[] primes = ESieve(87400);

            for ( int a = -79; a <= 1000; a++ )
            {
                for ( int b = -79; b <= 1000; b++ )
                {
                    int n = 0;
                    while ( IsPrime(Math.Abs(n * n + a * n + b)) )
                    {
                        n++;
                    }

                    if ( n > nMax )
                    {
                        aMax = a;
                        bMax = b;
                        nMax = n;
                    }
                }
            }
            sum = aMax * bMax;

            return sum;
        }

        static BigInteger TwentyEight()
        {
            BigInteger sum = 0;

            int[,] board = new int[1001, 1001];

            List<int> nums = new List<int>();
            // ( (j<=5) ? count == 2 : (j<=10)?count ==4 :count == 6)
            var count = 2; var maxCount = 2; var counter = 0;
            int max = 1001;
            for ( int j = 1; j <= ( max * max ); j++ )
            {
                if ( counter == 4 )
                {
                    maxCount += 2;
                    count = 1;
                    counter = 0;
                }
                if ( count == maxCount )
                {
                    count = 0;
                    sum += j;
                    nums.Add(j);

                    if ( j != 1 )
                        counter++;
                }
                count++;
            }

            return sum;
        }


        static int TwentyNine()
        {
            int length = 100;
            List<BigInteger> numbers = new List<BigInteger>();
            for ( int i = 2; i <= length; i++ )
            {
                for ( int j = 2; j <= length; j++ )
                {
                    BigInteger newNum = (BigInteger)Math.Floor(Math.Pow(i, j));
                    if ( !numbers.Contains(newNum) )
                        numbers.Add(newNum);
                }
            }
            numbers = numbers.OrderBy(x => x).ToList();
            BigInteger last = numbers.Last();
            int size = numbers.Distinct().Count();
            return size;
        }



        static bool IsMatchingTotal(BigInteger num)
        {
            BigInteger total = 0;
            string numString = num.ToString();
            int power = 5;
            char[] charNums = numString.ToCharArray();

            for ( int i = 0; i < charNums.Length; i++ )
            {
                total += (BigInteger)Math.Pow(Char.GetNumericValue(charNums[i]), power);
            }
            if ( total == num )
                return true;
            else
                return false;
        }
        static BigInteger Thirty()
        {
            BigInteger sum = 0;

            List<BigInteger> matches = new List<BigInteger>();

            for ( int i = 2; i < 2000000; i++ )
            {
                if ( IsMatchingTotal(i) )
                    matches.Add(i);
            }
            foreach ( var m in matches )
                sum += m;



            return sum;
        }


        static BigInteger ThirtyOne()
        {
            BigInteger total = 0;

            var TwoPound = 200;

            for ( int TwoPun = TwoPound; TwoPun >= 0; TwoPun -= 200 )
            {
                for ( int OnePun = TwoPun; OnePun >= 0; OnePun -= 100 )
                {
                    for ( int FiftyP = OnePun; FiftyP >= 0; FiftyP -= 50 )
                    {
                        for ( int TwentyP = FiftyP; TwentyP >= 0; TwentyP -= 20 )
                        {
                            for ( int TenP = TwentyP; TenP >= 0; TenP -= 10 )
                            {
                                for ( int FiveP = TenP; FiveP >= 0; FiveP -= 5 )
                                {
                                    for ( int TwoP = FiveP; TwoP >= 0; TwoP -= 2 )
                                    {
                                        total++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return total;
        }



        static bool IsPandigital(BigInteger num)
        {

            List<char> charList = num.ToString().ToCharArray().ToList();
            bool returning = false;
            List<char> charListLookFor = new List<char>();
            if ( charList.Count == 9 )
            {
                for ( int i = 0; i < charList.Count; i++ )
                {
                    charListLookFor.Add(( i + 1 ).ToString().First());
                }
                for ( int i = 0; i < charList.Count; i++ )
                {
                    if ( charList.Contains(charListLookFor[i]) )
                    {

                        returning = true;
                    }
                    else
                    {
                        returning = false;
                        break;
                    }
                }
            }
            // get the divisors of number
            //check all digits, if pal then check if not in, then add to list

            return returning;
        }
        static BigInteger ThirtyTwo()
        {
            BigInteger sum = 0;
            List<int> factors = new List<int>();
            List<BigInteger> pands = new List<BigInteger>();
            List<BigInteger> pandsLastFour = new List<BigInteger>();
            for ( int i = 1000; i < 500000; i++ )
            {
                factors = Factor((int)i);
                for ( int j = 0; j < factors.Count - 1; j += 2 )
                {

                    string numString = factors[j].ToString() + factors[j + 1].ToString() + i.ToString();
                    BigInteger currNum = BigInteger.Parse(numString);
                    if ( IsPandigital(currNum) )
                    {
                        if ( !pands.Contains(currNum) )
                        {
                            BigInteger lastFour = BigInteger.Parse(currNum.ToString().Substring(currNum.ToString().Length - 4));
                            if ( !pandsLastFour.Contains(lastFour) )
                            {
                                pands.Add(currNum);
                                pandsLastFour.Add(lastFour);
                            }

                        }
                    }

                }

            }

            foreach ( var p in pandsLastFour )
            {
                sum += p;
            }
            return sum;
        }

        static BigInteger Normalize(BigInteger a, BigInteger b)
        {
            BigInteger y, x;

            if ( a > b )
            {
                x = a;
                y = b;
            }
            else
            {
                x = b;
                y = a;
            }

            while ( x % y != 0 )
            {
                BigInteger temp = x;
                x = y;
                y = temp % x;
            }

            return y;
        }
        static BigInteger ThirtyThree()
        {
            BigInteger sum = 0;
            BigInteger denominator = 1;
            BigInteger nominator = 1;

            for ( int i = 1; i < 10; i++ )
            {
                for ( int d = 1; d < i; d++ )
                {
                    for ( int n = 1; n < d; n++ )
                    {
                        if ( ( n * 10 + i ) * d == n * ( i * 10 + d ) )
                        {
                            denominator *= d;
                            nominator *= n;
                        }
                    }
                }
            }


            sum = denominator;
            sum /= Normalize(nominator, denominator);
            return sum;
        }

        static BigInteger Factorial(int num)
        {
            BigInteger sum = num;

                switch(num)
                {
                    case 0:
                    case 1:
                         sum = 1;
                         break;
                    case 2:
                         sum = 2;
                         break;
                    default:
                         for ( int i = num - 1; i >= 1; i-- )
                            {
                                sum *= i;
                            }
                         break;
                }
                return sum;
        }
        static BigInteger ThirtyFour()
        {
            BigInteger sum = 0;
            BigInteger factorial = 0;
            List<int> factNums = new List<int>();

            for ( int i = 3; i < Factorial(9); i++ )
            {
                sum = 0;
                char[] charArr = i.ToString().ToCharArray();

                foreach ( var c in charArr )
                {
                    factorial = Factorial((int)Char.GetNumericValue(c));
                    sum += factorial;
                }

                if ( sum == i )
                    factNums.Add(i);
            }
            sum = 0;

            foreach ( var fN in factNums )
                         sum += fN;
            return sum;
        }

        public static string ShiftString(string t)
        {
            return t.Substring(1, t.Length - 1) + t.Substring(0, 1);
        } 
        static List<string> Permutations(string start)
        {
            char[] charArr = start.ToCharArray();
            string test = " ";
            List<string> permutations = new List<string>();
            test += start;
            while (test != start)
            {
                if ( test.Contains(" ") ) test = test.Replace(" ", String.Empty);


                test = ShiftString(test);
                permutations.Add(test);
            }

            //Recursion rec = new Recursion();
            //rec.InputSet = rec.MakeCharArray(start);
            //rec.CalcPermutation(0);

            //    foreach ( var p in rec.perms )
            //    {
            //        permutations.Add(p);
            //    }
            
          
            //BigInteger sum = 0;
            return permutations;
        }



        static BigInteger ThirtyFive()
        {
            BigInteger sum = 0;
            List<string> perms = new List<string>();
            List<string> tempPerms = new List<string>();
            int count = 0; int countToGet =0;
            for ( int i = 1; i <1000000; i++ )
            {
                count = 0;
                countToGet =0;
                tempPerms = new List<string>();
                foreach ( var p in Permutations(i.ToString()))
                {
                    countToGet = Permutations(i.ToString()).Count;
                    string copy = p;
                    if ( copy.First() == '0')
                            copy = copy.Replace("0", String.Empty);

                    if ( !perms.Contains(copy) )
                    {
                        if ( IsPrime(Convert.ToInt32(p)) )
                        {
                            tempPerms.Add(p);
                            count++;
                        }
                    }
                } 
                if(count == countToGet)
                {
                    foreach ( var p in tempPerms )
                    {
                        perms.Add(p);
                    }
                }
            }


            sum = perms.Count();
            return sum;
        }

        static BigInteger ThirtySix()
        {
            BigInteger sum =0;
            
            return sum;
        }


        static void Main(string[] args)
        {
            //int sum = CalculateProblemOne(1000, 3, 5);
            //int sum = CalculateProblemTwo(4000000, 1, 2);
            //CalculateProblemFour();
            //CalculateProblemFive(1,20);
            //CalculateProblemSix(1, 100);
            //CalculateProblemSeven(10001);
            //var x = CalculateProblemEight(13);
            //CalculateProblemNine(1000);
            //CalculateProblemTen(2000000);
            //CalculateProblemEleven();
            //CalculateProblemTwelve();
            //CalculateProblemThirteen();
            //CalculateProblemFourteen();
            //CalculateProblemFifteen(20);
            //CalculateProblemSixteen(1000);
            //CalculateProblemSeventeen(1000);
            //CalculateProblemEighteen();
            //CalculateProblemNineteen();
            //Twenty(100);
            //TwentyOne(10000);
            //TwentyTwo();
            //TwentyThree();
            //TwentyFour();
            //TwentyFive();
            //TwentySix();
            //TwentySeven();
            // TwentyEight();
            //TwentyNine();
            //Thirty();
            //ThirtyOne();
            //ThirtyTwo();
            // ThirtyThree();
            //ThirtyFour();
            //ThirtyFive();
            ThirtySix();




            Console.Read();
        }



    }
}
