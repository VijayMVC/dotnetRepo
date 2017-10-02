using FakeNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakeNews.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            NewsRepo repo = new NewsRepo();
            return View(repo.GetAllArticles());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            NewsRepo repo = new NewsRepo();

            NewsArticle toEdit = repo.GetAllArticles().SingleOrDefault(a => a.Id == id);
            return View(toEdit);
        }
    }
}