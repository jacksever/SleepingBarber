using System;
using System.Threading;

namespace SleepingBarber
{
	public static class ConsoleHelper
	{
		public static object LockObject = new object();

		public static void WriteBarberCut(string name)
		{
			lock (LockObject)
			{
				Console.WriteLine($"Парикмахер {name} стрижет волосы.");
			}
		}

		public static void WriteBarberSleeping(string name)
		{
			lock (LockObject)
			{
				Console.WriteLine($"Клиентов нет... Парикмахер {name} ушел спать!");
			}
		}

		public static void WriteBarberWakeUp(string name)
		{
			lock (LockObject)
			{
				Console.WriteLine($"Парикмахер {name} проснулся!");
			}
		}

		public static void WriteCustomerArrive()
		{
			lock (LockObject)
			{
				Console.WriteLine($"{Thread.CurrentThread.Name} зашёл в парикмахерскую.");
			}
		}

		public static void WriteCustomerGone()
		{
			lock (LockObject)
			{
				Console.WriteLine($"{Thread.CurrentThread.Name} вышел из парикмахерской");
			}
		}

		public static void WriteCustomerComplete()
		{
			lock (LockObject)
			{
				Console.WriteLine($"{Thread.CurrentThread.Name} подстригся и пошёл по своим делам");
			}
		}

		public static void WriteCustomerWait()
		{
			lock (LockObject)
			{
				Console.WriteLine($"{Thread.CurrentThread.Name} ожидает парикмахера");
			}
		}
	}
}
