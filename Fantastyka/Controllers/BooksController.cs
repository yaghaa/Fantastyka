using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fantastyka.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Books()
        {
            return View();
        }
    }
}