﻿namespace ChushkaWebApp.Controllers
{
	using ChushkaData;
	using ChushkaModels;
	using Common;
	using SIS.HTTP.Cookies;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;

	public abstract class BaseController:Controller
	{
		protected ChushkaDb Db;

		protected BaseController(ChushkaDb db)
		{
			this.Db = db;
		}

		public void SignIn(User user)
		{
			var mvcUser = new MvcUserInfo { Username = user.Username, Role = user.Role.ToString() };
			var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);

			var cookie = new HttpCookie(Constants.CookieAuthKey, cookieContent, Constants.CookieExpirationDays) { HttpOnly = true };
			this.Response.Cookies.Add(cookie);
		}

		public void SignOff()
		{
			if (this.Request.Cookies.ContainsCookie(Constants.CookieAuthKey))
			{
				var cookie = this.Request.Cookies.GetCookie(Constants.CookieAuthKey);
				cookie.Delete();
				this.Response.Cookies.Add(cookie);
			}
		}

		public IHttpResponse RedirectToHome()
		{
			return this.Redirect("/Home/Index");
		}
	}
}
