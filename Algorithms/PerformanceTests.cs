using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;

namespace Algorithms
{
	/// <summary>
	/// Performance test runner for the algorithms
	/// </summary>
	public class PerformanceTests
	{
		const int NUMBER_OF_ITERATIONS = 1000000;

		const int TINY_INTEGER = 32;
		const int SMALL_INTEGER = 65536;
		const int LARGE_INTEGER = 218231238;
		
		const string SHORT_STRING = "Albert Einstein";
		const string LONG_STRING = "Learn from yesterday, live for today, hope for tomorrow. The important thing is not to stop questioning.";

		public void RunAllTests()
		{
			RunOddNumberTests();

			RunIsNumberPowerOf2Tests();

			RunReplicateAStringTests();

			RunReverseAStringTests();
		}

		private void RunReverseAStringTests()
		{
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine($"Reverse A String, input string: '{SHORT_STRING}'");

			TestMethod(() => ReverseAString.ReverseAString_Basic(SHORT_STRING));
			TestMethod(() => ReverseAString.ReverseAString_Advanced(SHORT_STRING));
			TestMethod(() => ReverseAString.ReverseAString_Book(SHORT_STRING));

			Console.WriteLine();
			Console.WriteLine($"Reverse A String, input string: '{LONG_STRING}'");

			TestMethod(() => ReverseAString.ReverseAString_Basic(LONG_STRING));
			TestMethod(() => ReverseAString.ReverseAString_Advanced(LONG_STRING));
			TestMethod(() => ReverseAString.ReverseAString_Book(LONG_STRING));
		}

		private void RunReplicateAStringTests()
		{			
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine($"Replicate A String, input string: '{SHORT_STRING}'");
			
			TestMethod(() => ReplicateAString.ReplicateAString_Basic(SHORT_STRING,TINY_INTEGER));
			TestMethod(() => ReplicateAString.ReplicateAString_Advanced(SHORT_STRING, TINY_INTEGER));
			TestMethod(() => ReplicateAString.ReplicateAString_Book(SHORT_STRING, TINY_INTEGER));

			Console.WriteLine();
			Console.WriteLine($"Replicate A String, input string: '{LONG_STRING}'");

			TestMethod(() => ReplicateAString.ReplicateAString_Basic(LONG_STRING, TINY_INTEGER));
			TestMethod(() => ReplicateAString.ReplicateAString_Advanced(LONG_STRING, TINY_INTEGER));
			TestMethod(() => ReplicateAString.ReplicateAString_Book(LONG_STRING, TINY_INTEGER));
		}

		private void RunIsNumberPowerOf2Tests()
		{
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine($"Is number power of 2, input number: {SMALL_INTEGER}");

			TestMethod(() => PowerOf2.IsNumberPowerOf2_Basic(SMALL_INTEGER));
			TestMethod(() => PowerOf2.IsNumberPowerOf2_Advanced(SMALL_INTEGER));
			TestMethod(() => PowerOf2.IsNumberPowerOf2_Book(SMALL_INTEGER));

			Console.WriteLine();
			Console.WriteLine($"Is number power of 2, input number: {LARGE_INTEGER}");

			TestMethod(() => PowerOf2.IsNumberPowerOf2_Basic(LARGE_INTEGER));
			TestMethod(() => PowerOf2.IsNumberPowerOf2_Advanced(LARGE_INTEGER));
			TestMethod(() => PowerOf2.IsNumberPowerOf2_Book(LARGE_INTEGER));
		}

		private void RunOddNumberTests()
		{
			Console.WriteLine("Odd Numbers performance tests:");
			Console.WriteLine();

			TestMethod(() => OddNumbers.OddNumbersGenerator_Basic());

			TestMethod(() => OddNumbers.OddNumbersGenerator_Advanced());

			TestMethod(() => OddNumbers.OddNumbersGenerator_Book());
		}

		private void TestMethod(Expression<Action> methodCallExp)
		{
			try
			{
				Action methodCall = methodCallExp.Compile();

				var methodName = ((MethodCallExpression)methodCallExp.Body).Method.Name;

				Stopwatch stopWatch = Stopwatch.StartNew();

				for (int i = 0; i <= NUMBER_OF_ITERATIONS; i++)
				{
					methodCall();
				}

				Console.WriteLine($"{methodName} ticks: {stopWatch.ElapsedTicks:N0}");
			}
			catch
			{

			}
		}
	}
}
