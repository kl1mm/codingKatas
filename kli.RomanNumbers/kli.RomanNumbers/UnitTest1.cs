using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace kli.RomanNumbers
{
	public class UnitTest1
	{
		[Theory]
		[InlineData("I", 1)]
		[InlineData("II", 2)]
		[InlineData("IV", 4)]
		[InlineData("V", 5)]
		[InlineData("IX", 9)]
		[InlineData("X", 10)]
		[InlineData("XLII", 42)]
		[InlineData("XCIX", 99)]
		[InlineData("MMXIII", 2013)]
		public void TestRomanNumber(string romanNumber, int expected)
		{
			Assert.Equal(expected, this.RomanToDecimal(romanNumber));
		}

		private int RomanToDecimal(string romanNumber)
		{
			var valences = new Dictionary<char, int> {
				{ 'M', 1000 }, { 'D', 500 }, { 'C', 100 }, { 'L', 50 }, { 'X', 10 }, { 'V', 5 }, { 'I', 1 }
			};

			return romanNumber.Select((currentChar, idx) =>
			{
				var currentCharValue = valences[currentChar];
				var nextCharValue = idx + 1 < romanNumber.Length ? valences[romanNumber[idx + 1]] : 0;
				return  currentCharValue * (nextCharValue > currentCharValue ? -1 : 1);
			}).Sum();
		}
	}
}
