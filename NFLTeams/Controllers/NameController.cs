using Microsoft.AspNetCore.Mvc;
using NFLTeams.Models;

namespace NFLTeams.Controllers {
    public class NameController : Controller {

        [HttpGet]
        public IActionResult Index() 
        {
            var session = new NFLSession(HttpContext.Session);

            var model = new TeamListViewModel
            {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv(),
                Teams = session.GetMyTeams(),
                UserName = session.GetUserName()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Change(TeamViewModel model) 
        {
            var session = new NFLSession(HttpContext.Session);
            session.SetUserName("");
            session.SetUserName(model.UserName);

            return RedirectToAction("Index", "Home", new {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv()
            });
        }
    }
}
