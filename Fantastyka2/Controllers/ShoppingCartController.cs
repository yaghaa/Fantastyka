using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fantastyka2.Repositories;
using Microsoft.AspNet.Identity;

namespace Fantastyka2.Controllers
{
    [Authorize(Roles = "User")]
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var repository = new FantasyRepository();
            var result = repository.GetShoppingCartItems(User.Identity.GetUserId());
            return View(result);
        }
        [HttpPost]
        public ActionResult Post()
        {
            var repository = new FantasyRepository();
            repository.ClearCart(User.Identity.GetUserId());
            return Index();
        }
    }
}