using System;
using System.Linq;
using Xunit;

namespace kli.HappyNumbers
{
	public class HappyNumberTest
	{
		[Fact]
		public void TestToDigits()
		{
			Assert.Equal(new int[] { 1, 9 }, 19.ToDigits());
		}

		[Fact]
		public void TestSqrSum()
		{
			Assert.Equal(1 * 1 + 9 * 9, 19.SqrSum()); // 82
		}

		[Theory]
		[InlineData(false, 18)]
		[InlineData(true, 19)]
		public void TestIsHappy(bool expected, int number)
		{
			Assert.Equal(expected, number.IsHappy());
		}

		[Fact]
		public void TestInRange()
		{
			Assert.Equal(new [] { 10, 13, 19 }, Enumerable.Range(10, 10).Where(HappyNumber.IsHappy));
		}
	}
}
