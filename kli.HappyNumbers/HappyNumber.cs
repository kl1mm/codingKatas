using System.Collections.Generic;
using System.Linq;

namespace kli.HappyNumbers
{
	public static class HappyNumber
	{
		public static IEnumerable<int> ToDigits(this int number)
			=> number == 0 ? new int[0] : (number / 10).ToDigits().Append(number % 10);

		public static int SqrSum(this int number)
			=> number.ToDigits().Sum(digit => digit * digit);

		public static bool IsHappy(this int number)
			=> number switch { 1 => true, 4 => false, _ => IsHappy(number.SqrSum()) };
	}
}
