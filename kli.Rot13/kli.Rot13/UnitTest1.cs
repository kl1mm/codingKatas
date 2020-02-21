using System;
using Xunit;

namespace kli.Rot13
{
	public class UnitTest1
	{
		[Theory]
		[InlineData("a", "n")]
		[InlineData("A", "N")]
		[InlineData("Das ist mein Geheimnis", "Qnf vfg zrva Trurvzavf")]
		public void Test1(string actual, string expected)
		{
			var rot13 = new Rot13();
			Assert.Equal(expected, rot13.Encode(actual));
		}
	}

	public class Rot13
	{
		public string Encode(string input)
		{
			string result = string.Empty;
			foreach (char currentChar in input)
			{
				var upperLowerAdjustment = char.IsLower(currentChar) ? 'a'-'A' : 0;
				var rot13 = 0;
				if (char.IsLetter(currentChar))
				{
					rot13 = currentChar >= 'A' + upperLowerAdjustment && currentChar <= 'M' + upperLowerAdjustment 
						?  13
						: -13;
				}

				result += (char)(currentChar + rot13);
			}

			return result;
		}
	}
}
