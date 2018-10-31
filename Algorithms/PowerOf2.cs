using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
	/// <summary>
	/// A method that determines whether a number is a 2-power
	/// </summary>
	public class PowerOf2
	{
		/// <summary>
		/// Simple way to calculate this
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public static bool IsNumberPowerOf2_Basic(int number)
		{
			int i = 0;

			while(Math.Pow(2,i) < number)
			{
				i++;
			}

			return Math.Pow(2, i) == number;
		}

		/// <summary>
		/// Additional way that works with binary representation of the number
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public static bool IsNumberPowerOf2_Advanced(int number)
		{
			var binaryRepresentation = Convert.ToString(number, 2);

			//if the binary representation has more than exactly one bit raised (1), it is a power of 2, otherwise false
			return binaryRepresentation.LastIndexOf('1') == 0;			
		}

		/// <summary>
		/// Based on https://stackoverflow.com/a/600306/431859
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public static bool IsNumberPowerOf2_Book(int number)
		{
			return (number > 0) && ((number & (number - 1)) == 0);
		}
	}
}
