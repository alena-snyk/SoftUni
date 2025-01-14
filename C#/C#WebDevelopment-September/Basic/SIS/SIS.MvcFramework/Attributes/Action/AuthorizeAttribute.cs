﻿namespace SIS.MvcFramework.Attributes.Action
{
	using System;
	using System.Linq;
	using Security.Contracts;

	public class AuthorizeAttribute : Attribute
	{
		private readonly string[] roles;

		public AuthorizeAttribute()
		{
            
		}

		public AuthorizeAttribute(params string[] roles)
		{
			this.roles = roles;
		}

		private bool IsIdentityPresent(IIdentity identity) =>
			identity != null;

		private bool IsIdentityInRole(IIdentity identity)
		{
			if (!this.IsIdentityPresent(identity))
			{
				return false;
			}

			var identityRoles = identity.Roles;
			foreach (var identityRole in identityRoles)
			{
				if (this.roles.Contains(identityRole))
				{
					return true;
				}
			}

			return false;
		}

		public bool IsAuthenticated(IIdentity identity)
		{
			if (this.roles == null || !this.roles.Any())
			{
				return this.IsIdentityPresent(identity);
			}

			return this.IsIdentityInRole(identity);
		}
	}
}