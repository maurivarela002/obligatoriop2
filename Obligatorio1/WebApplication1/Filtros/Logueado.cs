using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Filtros
{
	public class Logueado : Attribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{

			if (context.HttpContext.Session.GetString("rol") == null)
			{
				context.Result = new RedirectResult("/Login/Ingresar");
			}

		}
	}
}
