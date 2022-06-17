using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new Models.CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        private IGameRepository repository;

        public CartController(IGameRepository repo)
        {
            repository = repo;
        }

        public RedirectToRouteResult AddToCart(Cart cart, int gameId,string returnUrl)
        {
            Game game = repository.Games
                .FirstOrDefault(x => x.GameId == gameId);

            if (game != null)
                cart.AddItem(game, 1);
            return RedirectToAction("Index",new {returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart,int gameId, string returnUrl)
        {
            Game game = repository.Games
                .FirstOrDefault(x => x.GameId == gameId);
            if (game != null)
                cart.RemoveLine(game);
            return RedirectToAction("Index",new {returnUrl});
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

    }
}