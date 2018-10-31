using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
	/// <summary>
	/// One method that prints the odd numbers between 0 and 100.	
	/// </summary>
	public class OddNumbers
	{
		public static void PrintOddNumbersBetween0And100()
		{
			foreach(var oddNumber in OddNumbersGenerator_Basic())
			{
				Console.WriteLine(oddNumber);
			}
		}

		/// <summary>
		/// Simple way to achieve this
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static List<int> OddNumbersGenerator_Basic()
		{
			var result = new List<int>();

			for (var i = 1; i <= 99; i= i+2)
			{
				result.Add(i);
			}

			return result;
		}

		public static bool OddNumbers_Basic(int number)
		{
			return OddNumbersGenerator_Basic().Contains(number);
		}

		/// <summary>
		/// More optimized
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static int[] OddNumbersGenerator_Advanced()
		{
			var result = new int[50];

			for (var i = 0; i <= 49; i = i + 1)
			{
				result[i] = (i * 2) + 1;
			}

			return result;
		}

		public static bool OddNumbers_Advanced(int number)
		{
			return OddNumbersGenerator_Advanced().Contains(number);
		}

		/// <summary>
		/// Based on https://stackoverflow.com/a/2366654/431859
		/// 
		/// i & 1 == 0 is faster than i % 2 == 0
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static IEnumerable<int> OddNumbersGenerator_Book()
		{
			return Enumerable.Range(0, 100).Where(n => n % 2 != 0);

			//return Enumerable.Range(0, 100).Where(n => (n & 1) != 0);
		}

		public static bool OddNumbers_Book(int number)
		{
			return OddNumbersGenerator_Book().Contains(number);
		}

	}
}
