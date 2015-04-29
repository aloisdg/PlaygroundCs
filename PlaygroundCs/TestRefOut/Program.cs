using System;

namespace TestRefOut
{
	internal class Program
	{
		private static void Main()
		{
			var value1 = "cat";
			SetString1(ref value1);
			Console.WriteLine(value1);

			string value2;
			SetString2(1, out value2);
			Console.WriteLine(value2);
			Console.ReadLine();
		}

		private static void SetString1(ref string value)
		{
			if (value == "cat")
				Console.WriteLine("Is cat");
			value = "dog";
		}

		private static void SetString2(int number, out string value)
		{
			value = number == 1 ? "one" : "carrot";
		}
	}
}