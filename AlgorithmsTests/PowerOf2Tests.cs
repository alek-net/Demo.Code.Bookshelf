using Algorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace AlgorithmsTests
{
	public class PowerOf2Tests
	{
		#region Test Data

		public static IEnumerable<object[]> GetData(int numberOfTests)
		{
			return new List<object[]>
			{
				new object[] { -1, false },
				new object[] { 0, false },
				new object[] { 1, true },
				new object[] { 2, true },				
				new object[] { 3, false },
				new object[] { 4, true },
				new object[] { 5, false },
				new object[] { 6, false },
				new object[] { 7, false },
				new object[] { 8, true },
				new object[] { 13, false },
				new object[] { 16, true },
				new object[] { 256, true },
				new object[] { 1024, true },
				new object[] { 65536, true },
				new object[] { 65536, true },
				new object[] { 218231238, false },
				new object[] { Int32.MaxValue, false },				
			};		
		}

		#endregion

		[Theory]
		[MemberData(nameof(GetData), parameters:2)]
		public void IsNumberPowerOf2_Basic(int number, bool expected)
		{
			//Arrange

			//Act
			var isPowerOf2 = PowerOf2.IsNumberPowerOf2_Basic(number);
			//Assert
			Assert.True(expected == isPowerOf2, $"IsNumberPowerOf2_Basic should return true for {number}");

		}

		[Theory]
		[MemberData(nameof(GetData), parameters: 2)]
		public void IsNumberPowerOf2_Advanced(int number, bool expected)
		{
			//Arrange

			//Act
			var isPowerOf2 = PowerOf2.IsNumberPowerOf2_Advanced(number);
			//Assert
			Assert.True(expected == isPowerOf2, $"IsNumberPowerOf2_Advanced should return true for {number}");

		}

		[Theory]
		[MemberData(nameof(GetData), parameters: 2)]
		public void IsNumberPowerOf2_Book(int number, bool expected)
		{
			//Arrange

			//Act
			var isPowerOf2 = PowerOf2.IsNumberPowerOf2_Book(number);
			//Assert
			Assert.True(expected == isPowerOf2, $"IsNumberPowerOf2_Book should return true for {number}");

		}

		

	}
}
