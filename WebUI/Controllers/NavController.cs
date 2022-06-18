using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
       private IGameRepository repository;

        public NavController(IGameRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(string category = null,bool horizontalNav = false)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = repository.Games
                 .Select(x => x.Category)
                 .Distinct()
                 .OrderBy(x => x);

            return PartialView("FlexMenu", categories);
        }
    }
}