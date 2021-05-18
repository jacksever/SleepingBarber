using System.Threading;

namespace SleepingBarber
{
	public class Customer
	{
		private Barber barber;

		public Customer(Barber barber)
		{
			this.barber = barber;
		}

		public void CustomersWait()
		{
			Utils.CustomerSeats.WaitOne();
			ConsoleHelper.WriteCustomerArrive();

			if (Utils.WaitingRoomSeats > 0)
			{
				ConsoleHelper.WriteCustomerWait();
				Utils.WaitingRoomSeats -= 1;
				Utils.WaitingRoom.AddLast(Thread.CurrentThread);
				Utils.CustomerSeats.Release();
				Utils.CustomerReady.Release();

				if (barber.isSleeping)
					barber.WakeUp();

				Utils.BarberReady.WaitOne();
				ConsoleHelper.WriteCustomerComplete();

			}
			else
			{
				Utils.CustomerSeats.Release();
				ConsoleHelper.WriteCustomerGone();
			}
		}
	}
}
