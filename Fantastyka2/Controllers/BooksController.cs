using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fantastyka2.Models;
using Fantastyka2.Repositories;
using Microsoft.AspNet.Identity;

namespace Fantastyka2.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Books()
        {
            var booksViewMoel = new BooksViewModel();
            var repo = new FantasyRepository();
            booksViewMoel.Books = repo.GetAllBooks();
            return View(booksViewMoel);
        }

        [HttpPost]
        public ActionResult Books(BooksViewModel model)
        {

            var request = Request.Form["SelectedSources"];
            if (request != null)
            {
                var checkedIds = request.Split(',').ToList();
                var repo = new FantasyRepository();
                repo.AddToCart(checkedIds, User.Identity.GetUserId());
            }
            
            return Books();
        }

        [HttpPost]
        public JsonResult GetBooksForCategory(string category)
        {
            try
            {
                //in real application made a better load / retrieving
                var emp = new List<Book>();
                var repo = new FantasyRepository();
                emp = repo.GetAllBooks();

                if(category != "Nie wybrano")
                    emp.RemoveAll(item => item.Category != category);

                return Json(new { ok = true, data = emp, message = "ok" });
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, message = ex.Message });
            }
        }
    }
}