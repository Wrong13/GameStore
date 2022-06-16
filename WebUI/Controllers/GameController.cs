using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class GameController : Controller
    {
        private Domain.Abstract.IGameRepository repository;
        public GameController(Domain.Abstract.IGameRepository repo)
        {
            repository = repo;
        }
        public ViewResult List()
        {
            return View(repository.Games);
        }
    }
}