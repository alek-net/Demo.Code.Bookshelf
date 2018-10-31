using Algorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace AlgorithmsTests
{
	public class ReplicateAStringTests
	{
		#region Test Data

		public static IEnumerable<object[]> GetData()
		{
			return new List<object[]>
			{
				new object[] { "Hi", 3, "HiHiHi" },
				new object[] { "Hello", 0, "" },
				new object[] { "Hello", 1, "Hello" },
				new object[] { "", 5, "" },
				new object[] { "ABBC", 2, "ABBCABBC" },
				new object[] { "Aleksandar", 3, "AleksandarAleksandarAleksandar" },
				new object[] { "Hello World", 4 , "Hello WorldHello WorldHello WorldHello World" },
				new object[] { "Здраво дете!", 2 ,"Здраво дете!Здраво дете!" },				
			};
		}

		#endregion

		[Theory]
		[MemberData(nameof(GetData))]
		public void ReplicateAString_Basic(string input, int numberOfReplicas, string output)
		{
			//Arrange

			//Act
			var result = ReplicateAString.ReplicateAString_Basic(input, numberOfReplicas);
			//Assert
			Assert.True(result == output, $"ReplicateAString_Basic should return: {output} instead of {result}");

		}

		


		[Theory]
		[MemberData(nameof(GetData))]
		public void ReplicateAString_Advanced(string input, int numberOfReplicas, string output)
		{
			//Arrange

			//Act
			var result = ReplicateAString.ReplicateAString_Advanced(input, numberOfReplicas);
			//Assert
			Assert.True(result == output, $"ReplicateAString_Advanced should return: {output} instead of {result}");

		}

		

		[Theory]
		[MemberData(nameof(GetData))]
		public void ReplicateAString_Book(string input, int numberOfReplicas, string output)
		{
			//Arrange

			//Act
			var result = ReplicateAString.ReplicateAString_Book(input, numberOfReplicas);
			//Assert
			Assert.True(result == output, $"ReplicateAString_Book should return: {output} instead of {result}");

		}

		
	}
}
