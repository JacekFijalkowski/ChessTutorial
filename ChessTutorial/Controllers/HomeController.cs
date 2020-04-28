using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChessTutorial.Dtos;
using ChessTutorial.Models;

namespace ChessTutorial.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            IEnumerable<Piece> pieces = new List<Piece>()
            {
                new King(),
                new Rook(),
                new Queen()
            };
            return View("Index",pieces);
        }
    }
}
