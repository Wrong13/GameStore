﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class GameController : Controller
    {
        private Domain.Abstract.IGameRepository repository;
        public int pageSize = 4;
        public GameController(Domain.Abstract.IGameRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(int page = 1)
        {
            WebUI.Models.GameListViewModel model = new WebUI.Models.GameListViewModel
            {
                Games = repository.Games
                .OrderBy(x => x.GameId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new Models.PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Games.Count()
                }
            };
            return View(model);
        }
    }
}