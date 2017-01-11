using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fantastyka2.Models;
using Fantastyka2.Repositories;

namespace Fantastyka2.Controllers
{
    [Authorize]
    public class AddBookController : Controller
    {
        public ActionResult AddBook(Book book)
        {
            if (book == null)
            {
                book = new Book();
            }
            return View("AddBook",book);
        }

        [HttpPost]
        public ActionResult Post(Book book)
        {
            if(!ModelState.IsValid)
                return View("AddBook", book);

            var repo = new FantasyRepository();

            repo.SaveBook(book);

            return AddBook(null);
        }
    }
}