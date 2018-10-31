using Algorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace AlgorithmsTests
{
	public class OddNumberTests
	{
		#region Test Data

		public static IEnumerable<object[]> GetData()
		{
			return new List<object[]>
			{
				new object[] { -3, false },
				new object[] { -1, false },
				new object[] { 0, false },
				new object[] { 1, true },
				new object[] { 2, false },				
				new object[] { 3, true },
				new object[] { 4, false },
				new object[] { 5, true },
				new object[] { 6, false },
				new object[] { 7, true },
				new object[] { 8, false },
				new object[] { 13, true },
				new object[] { 16, false },
				new object[] { 56, false },
				new object[] { 57, true },
				new object[] { 58, false },
				new object[] { 59, true },
				new object[] { 99, true },
				new object[] { 100, false },
				new object[] { 101, false },
				new object[] { 102, false },
				new object[] { 103, false },
			};		
		}

		#endregion

		[Theory]
		[MemberData(nameof(GetData))]
		public void OddNumbers_Basic(int number, bool expected)
		{
			//Arrange

			//Act
			var isOddNumbers = OddNumbers.OddNumbers_Basic(number);
			//Assert
			Assert.True(expected == isOddNumbers, $"OddNumbers_Basic should return true for {number}");

		}

		[Theory]
		[MemberData(nameof(GetData))]
		public void OddNumbers_Advanced(int number, bool expected)
		{
			//Arrange

			//Act
			var isOddNumbers = OddNumbers.OddNumbers_Advanced(number);
			//Assert
			Assert.True(expected == isOddNumbers, $"OddNumbers_Advanced should return true for {number}");

		}

		[Theory]
		[MemberData(nameof(GetData))]
		public void OddNumbers_Book(int number, bool expected)
		{
			//Arrange

			//Act
			var isOddNumbers = OddNumbers.OddNumbers_Book(number);
			//Assert
			Assert.True(expected == isOddNumbers, $"OddNumbers_Book should return true for {number}");

		}

		



	}
}
