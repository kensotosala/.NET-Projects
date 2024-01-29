using Microsoft.AspNetCore.Mvc;

namespace Blog_App_ASP.NET_MVC_Entity_Framework.Controllers
{
	public class AdminTagsController : Controller
	{
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
	}
}
