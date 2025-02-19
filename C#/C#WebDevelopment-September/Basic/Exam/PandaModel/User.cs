﻿namespace PandaModel
{
	using System.Collections.Generic;

	public class User
	{
		public User()
		{
			this.Packages = new HashSet<Package>();
			this.Receipts = new HashSet<Receipt>();
		}
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public Role Role { get; set; }
		public ICollection<Package> Packages { get; set; }
		public ICollection<Receipt> Receipts { get; set; }
	}
}
