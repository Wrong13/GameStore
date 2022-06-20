using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        IGameRepository repository;
        
        public AdminController(IGameRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Games);
        }
        
       public ViewResult Edit(int gameId)
        {
            Domain.Entities.Game game = repository.Games
                .FirstOrDefault(x=>x.GameId == gameId);
            return View(game);
        }

        public ViewResult Create()
        {
            return View("Edit", new Domain.Entities.Game());
        }

        // Перегруженная версия
        [HttpPost]
        public ActionResult Edit(Domain.Entities.Game game)
        {
            if (ModelState.IsValid)
            {
                repository.SaveGame(game);
                TempData["message"] = string.Format("Изменение в игре \"{0}\" были сохранены",
                    game.Name);
                return RedirectToAction("Index");
            }
            else
                return View(game);
        }
        [HttpPost]
        public ActionResult Delete (int gameId)
        {
            Domain.Entities.Game delGame = repository.DeleteGame(gameId);
            if (delGame != null)
            {
                TempData["message"] = string.Format("Игра \"{0}\" была удалена",
                    delGame.Name);
            }
            return RedirectToAction("Index");
        }
    }
}