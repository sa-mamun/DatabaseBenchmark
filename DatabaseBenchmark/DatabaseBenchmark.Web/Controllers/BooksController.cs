﻿using DatabaseBenchmark.Core;
using DatabaseBenchmark.Core.Exceptions;
using DatabaseBenchmark.Web.Models;
using log4net;
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
        #region Logger
        private static readonly ILog _logger = LogManager.GetLogger(typeof(BooksController));
        #endregion

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
                var result = bookModel.ListOfBookObject(model.TotalNoOfBooks);
                ViewBag.StartTime = result.startTime;
                ViewBag.EndTime = result.endTime;
                ViewBag.Duration = result.finalCount.ToString();
                ViewBag.RootBookList = result.rootBooks;
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

                    string startTime = DateTime.Now.ToString("h:mm:ss tt");

                    var result = getValueVM.GetBookValue(model.BookKey);

                    string endTime = DateTime.Now.ToString("h:mm:ss tt");
                    // Calculating TimeSpan
                    TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));

                    if(result != null)
                    {
                        var json = JsonConvert.DeserializeObject<BookJso>(result.BookValue);
                        _logger.Info("Get Value duration: " + duration.ToString());
                        return Json(json);
                    }

                    _logger.Info("Invalid Key Found duration: " + duration.ToString());
                }
                catch (CustomInvalidException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed!!Please try again");
                }
            }
            return View();
        }
    }
}