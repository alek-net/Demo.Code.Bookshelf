using Algorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace AlgorithmsTests
{
	public class ReverseAStringTests
	{
		#region Test Data

		public static IEnumerable<object[]> GetData()
		{
			return new List<object[]>
			{
				new object[] { "Hello", "olleH" },
				new object[] { "", "" },
				new object[] { "ABBC", "CBBA" },
				new object[] { "Aleksandar", "radnaskelA" },
				new object[] { "Hello World", "dlroW olleH" },
				new object[] { "«драво дете!", "!етед овард«" },
				//new object[] { "Les Mise\u0301rables", "selbare\u0301siM seL" },
			};
		}

		#endregion

		[Theory]
		[MemberData(nameof(GetData))]
		public void ReverseAString_Basic(string input, string output)
		{
			//Arrange

			//Act
			var result = ReverseAString.ReverseAString_Basic(input);
			//Assert
			Assert.True(result == output, $"ReverseAString_Basic should return: {output} instead of {result}");

		}

		
		[Theory]
		[MemberData(nameof(GetData))]
		public void ReverseAString_Advanced(string input, string output)
		{
			//Arrange

			//Act
			var result = ReverseAString.ReverseAString_Advanced(input);
			//Assert
			Assert.True(result == output, $"ReverseAString_Advanced should return: {output} instead of {result}");

		}

		

		[Theory]
		[MemberData(nameof(GetData))]
		public void ReverseAString_Book(string input, string output)
		{
			//Arrange

			//Act
			var result = ReverseAString.ReverseAString_Book(input);
			//Assert
			Assert.True(result == output, $"ReverseAString_Book should return: {output} instead of {result}");

		}

		
	}
}
