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
                var bookModel = new BookModel();
                var time = bookModel.ListOfBookObject(model.TotalNoOfBooks);

                // Calculating TimeSpan
                TimeSpan duration = DateTime.Parse(time.endTime).Subtract(DateTime.Parse(time.startTime));

                ViewBag.StartTime = time.startTime;
                ViewBag.EndTime = time.endTime;
                ViewBag.Duration = duration.ToString();
                ViewBag.RootBookList = time.rootBooks;
            }
            return View();
        }

        [HttpGet]
        public ActionResult GetBook()
        {
            return View();
        }
    }
}