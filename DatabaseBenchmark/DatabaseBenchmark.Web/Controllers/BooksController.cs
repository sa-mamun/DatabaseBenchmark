using DatabaseBenchmark.Core;
using DatabaseBenchmark.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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

        [HttpPost]
        public ActionResult GetBook(GetValueVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var getValueVM = new GetValueVM();

                    var result = getValueVM.GetBookValue(model.BookKey);
                    var json = JsonConvert.DeserializeObject<BookJso>(result.BookValue);
                    return Json(json);
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "Failed!!Please try again");
                }
            }
            return View();
        }
    }
}