﻿using System;

class Program
{
	static void Main()
	{
		Spy spy = new Spy();
		string result = spy.CollectGettersAndSetters("Hacker");
		Console.WriteLine(result);
	}
}

