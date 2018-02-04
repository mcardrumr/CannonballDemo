using CannonBall.Web.Models;
using CannonBall.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace CannonBall.Web.Controllers
{
    public class HomeController : Controller
    {
        private IGameFlow _gameFlow;

        public HomeController(IGameFlow gameFlow)
        {
            _gameFlow = gameFlow;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var target = _gameFlow.GetNewTarget();

            var view = new GameFlowView()
            {
                TargetX = target.X,
                TargetY = target.Y
            };

            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(
            [Bind(Include = "Angle,Velocity,TargetX,TargetY,ShotsTaken")] GameFlowView model)
        {
            if (ModelState.IsValid)
            {
                model.WasTargetHit = _gameFlow.TakeShot(Request["ShotCount"].AsInt(),
                    model.Angle, model.Velocity,
                    new Coordinate(model.TargetX, model.TargetY));

                model.ShotsTaken = _gameFlow.GetShotCount();
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}