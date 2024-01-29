using Blog_App_ASP.NET_MVC_Entity_Framework.Models.ViewModels;
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
		[HttpPost]
		[ActionName("Add")]
		public IActionResult Add(AddTagRequest addTagRequest)
		{
			var name = addTagRequest.Name;
			var displayName = addTagRequest.DisplayName;
            return View("Add");
		}
	}
}
