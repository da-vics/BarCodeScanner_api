using Microsoft.AspNetCore.Mvc;

namespace SmartNG.Controllers
{
    [Route("/")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]

        public ActionResult SmartAdminTest()
        {
            return Content("StartPage");
        }
    }
}