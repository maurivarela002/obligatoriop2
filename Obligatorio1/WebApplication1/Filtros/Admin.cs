using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Filtros
{
	public class Admin : Attribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			if (context.HttpContext.Session.GetString("rol") == null)
			{
				context.Result = new RedirectResult("/Login/Ingresar");
			}

			if (context.HttpContext.Session.GetString("rol") != "Admin")
			{
				context.Result = new RedirectResult("/Subasta/index");
			}


		}
	}
}
