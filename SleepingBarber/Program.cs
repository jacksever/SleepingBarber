using System;

namespace SleepingBarber
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BarberShop barberShop = new BarberShop("Alex");
			barberShop.GetCustomer();

			Console.ReadKey();
		}
	}
}
