using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
	/// <summary>
	/// A method that reverses a string (e.g. "Hello" gives "olleH").
	/// 
	/// Surprisingly tricky if you want proper international support. 
	/// Example: Croatian/Serbian have two-character letters lj, nj etc. 
	/// Proper reverse of "ljudi" is "idulj", NOT "idujl". 
	/// I'm sure you'd fare far worse when it comes to Arabic, Thai etc
	/// </summary>
	public class ReverseAString
	{
		/// <summary>
		/// Simple way to achieve this
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string ReverseAString_Basic(string input)
		{
			var output = String.Empty;

			foreach (var character in input)
			{
				output = character + output;
			}

			return output;
		}

		/// <summary>
		/// A bit optimized, using string builder
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string ReverseAString_Advanced(string input)
		{
			var sb = new StringBuilder(input.Length);

			for(var i = input.Length - 1; i >= 0; i--)
			{
				sb.Append(input[i]);
			}

			return sb.ToString();
		}

		/// <summary>
		/// Based on https://stackoverflow.com/a/3754630/431859
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string ReverseAString_Book(string input)
		{
			char[] charArray = input.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}

	}
}
