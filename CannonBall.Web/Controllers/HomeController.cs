using CannonBall.Web.Models;
using CannonBall.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var target = _gameFlow.Start();

            var view = new GameFlowView()
            {
                TargetX = target.X,
                TargetY = target.Y
            };

            return View(view);
        }

        [HttpPost]
        public ActionResult Index(GameFlowView model)
        {
            bool wasHit = _gameFlow.TakeShot(model.Angle, model.Velocity);

            if (wasHit)
            {
                model.WasTargetHit = true;
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