using System;
using System.Collections.Generic;
using System.Threading;

namespace SleepingBarber
{
	public class BarberShop
	{
		private Barber barber;
		private Thread thread;

		public BarberShop(string name)
		{
			barber = new Barber(name);
			thread = new Thread(barber.Arrive);
			thread.Start();
		}

		public void GetCustomer()
		{
			List<Thread> threads = new List<Thread>();
			Random random = new Random();

			int index = 1;

			while (index != 15)
			{
				Customer customer = new Customer(barber);
				Thread thread = new Thread(customer.CustomersWait)
				{
					Name = $"Клиент {index}"
				};

				threads.Add(thread);
				thread.Start();

				Thread.Sleep(random.Next(30, 1000));
				index++;
			}
		}
	}
}
