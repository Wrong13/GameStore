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
       

        private IGameRepository repository;
        private IOrderProcessor orderProcessor;

        public CartController(IGameRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new Models.CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.LineCollection.Count() == 0)
                ModelState.AddModelError("", "Корзина пуста");
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else return View(shippingDetails);
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