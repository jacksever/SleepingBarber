using System.Threading;

namespace SleepingBarber
{
	public class Barber
	{
		public string Name { get; set; }

		public bool isSleeping { get; set; }

		public Barber(string name)
		{
			this.Name = name;
			this.isSleeping = true;
		}

		public void Arrive()
		{
			while (true)
			{
				while (!isSleeping)
				{
					if (Utils.WaitingRoom.Count != 0)
					{
						Utils.CustomerReady.WaitOne();
						Utils.CustomerSeats.WaitOne();
						Utils.WaitingRoomSeats += 1;
						Utils.WaitingRoom.RemoveFirst();
						ConsoleHelper.WriteBarberCut(this.Name);

						Thread.Sleep(500);

						Utils.BarberReady.Release();
						Utils.CustomerSeats.Release();
					}
					else
						Sleep();
				}
			}
		}

		public void Sleep()
		{
			this.isSleeping = true;
			ConsoleHelper.WriteBarberSleeping(this.Name);
		}

		public void WakeUp()
		{
			this.isSleeping = false;
			ConsoleHelper.WriteBarberWakeUp(this.Name);
		}
	}
}
