using Microsoft.AspNetCore.Mvc;

namespace NonProfit.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}