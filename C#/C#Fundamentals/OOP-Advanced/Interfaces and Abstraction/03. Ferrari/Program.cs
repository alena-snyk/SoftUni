﻿using System;

class Program
{
	static void Main()
	{
		var driver = Console.ReadLine();
		ICar car = new Ferrari(driver);
		Console.WriteLine(car);

		string ferrariName = typeof(Ferrari).Name;
		string iCarInterfaceName = typeof(ICar).Name;

		bool isCreated = typeof(ICar).IsInterface;
		if (!isCreated)
		{
			throw new Exception("No interface ICar was created");
		}

	}
}

