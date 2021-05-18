using System.Collections.Generic;
using System.Threading;

namespace SleepingBarber
{
	public static class Utils
	{
		public static int WaitingRoomSeats = 3;
		public static LinkedList<Thread> WaitingRoom = new LinkedList<Thread>();

		public static Semaphore BarberReady = new Semaphore(0, 1);
		public static Semaphore CustomerSeats = new Semaphore(1, 1);
		public static Semaphore CustomerReady = new Semaphore(0, WaitingRoomSeats);
	}
}
