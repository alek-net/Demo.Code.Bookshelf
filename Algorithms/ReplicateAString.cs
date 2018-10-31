using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
	/// <summary>
	/// One method that replicates a string a given number of times (e.g. ("Hi", 3) gives "HiHiHi")
	/// </summary>
	public class ReplicateAString
	{
		/// <summary>
		/// Simple method
		/// </summary>
		/// <param name="input"></param>
		/// <param name="numberOfReplicas"></param>
		/// <returns></returns>
		public static string ReplicateAString_Basic(string input, int numberOfReplicas)
		{
			string output = String.Empty;

			for (int i = 0; i < numberOfReplicas; i++)
			{
				output += input;
			}

			return output;
		}

		/// <summary>
		/// More advanced approach, using array copy
		/// </summary>
		/// <param name="input"></param>
		/// <param name="numberOfReplicas"></param>
		/// <returns></returns>
		public static string ReplicateAString_Advanced(string input, int numberOfReplicas)
		{
			char[] charArray = input.ToCharArray();
			var outputArray = new char[charArray.Length * numberOfReplicas];
			for (int i = 0; i < numberOfReplicas; i++)
			{
				charArray.CopyTo(outputArray, charArray.Length * i);
			}			
			
			return new string(outputArray);
		}

		/// <summary>
		/// Based on https://gunnarpeipman.com/csharp/string-repeat/
		/// </summary>
		/// <param name="input"></param>
		/// <param name="numberOfReplicas"></param>
		/// <returns></returns>
		public static string ReplicateAString_Book(string input, int numberOfReplicas)
		{
			return new StringBuilder(input.Length * numberOfReplicas)
						.AppendJoin(input, new string[numberOfReplicas + 1])
						.ToString();
		}
	}
}
