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
            var pieces = Piece.GetAllPieces();
            return View("Index",pieces);
        }
    }
}
