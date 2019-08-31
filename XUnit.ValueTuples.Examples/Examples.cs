using System.Collections.Generic;
using Xunit;
using XUnit.ValueTuples;

namespace XUnit.ValueTuples.Examples
{
	static class Numbers
	{
		public static int Add(int a, int b) => a + b;
		public static bool IsOdd(int a) => a % 2 == 1;
	}
	public class Examples
	{
		// We can use a tuple to define data instead of object[], which provides a cleaner syntax.
		public static IEnumerable<(int a, int b, int expected)> AddData => new (int, int, int)[] {
			(1, 2, 3),
			(1, 5, 6),
			(0, -1, -1),
			(-1, 0, -1),
			(-1, -1, -2)
		};

		// For functions that take a single parameter, we can simply define their test data using any IEnumerable of the correct
		// single data type, which prevents having to wrap the single values in object[] or ValueTuple
		public static IEnumerable<int> OddData = new int[] { 1, 2, 3, 4, 5 };

		[Theory]
		[MemberDataTuple(nameof(AddData))]
		public void Tuple(int a, int b, int expected)
		{
			Assert.Equal(expected, Numbers.Add(a, b));
		}

		[Theory]
		[MemberDataEnumerable(nameof(OddData))]
		public void Enum(int a)
		{
			Assert.Equal(a % 2 == 1, Numbers.IsOdd(a));
		}
	}
}

