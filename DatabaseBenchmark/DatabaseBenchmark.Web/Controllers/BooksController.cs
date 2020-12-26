using DatabaseBenchmark.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseBenchmark.Web.Controllers
{
    public class BooksController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GenerateBook()
        {
            var model = new GenerateBookVM();
            return View(model);
        }

        [HttpPost]
        public ActionResult GenerateBook(GenerateBookVM model)
        {
            if(ModelState.IsValid)
            {
                var bookVM = new BookVM();
                var listOfBooks = bookVM.ListOfBookObject(model.TotalNoOfBooks);
                ViewBag.BookList = listOfBooks;
            }
            return View();
        }
    }
}