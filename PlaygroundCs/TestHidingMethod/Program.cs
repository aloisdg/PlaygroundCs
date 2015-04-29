using System;
using System.Collections.Generic;

namespace TestHidingMethod
{
	public class Program
	{
		internal class CustomDictionary<TKey, TValue> : Dictionary<TKey, TValue>
		{
			public new void Add(TKey key, TValue value)
			{
				Console.WriteLine("Hello I am {0}", value);
				base.Add(key, value);
			}
		}

		private static readonly CustomDictionary<int, string> Cars = new CustomDictionary<int, string>
		{
			{ 8, "Flying Ford Anglia" },
			{ 16, "313" },
			{ 32, "K2000" },
			{ 64, "DeLorean" }
		};

		public static void Main()
		{
			Cars.Add(42, "Millenium Falcon");
			Console.ReadLine();
		}
	}
}