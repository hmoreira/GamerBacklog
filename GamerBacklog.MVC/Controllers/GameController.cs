using System.Web.Mvc;
using GamerBacklog.Application.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using GamerBacklog.Domain.Entities;
using GamerBacklog.MVC.ViewModels;

namespace GamerBacklog.MVC.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameAppService _gameApp;

        public GameController(IGameAppService gameApp)
        {
            _gameApp = gameApp;
        }
        // GET: Game
        public ActionResult Index()
        {
            var gameViewModel = Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(_gameApp.GetAll());
            return View(gameViewModel);
        }

        // GET: Game/Details/5
        public ActionResult Details(int id)
        {
            var game = _gameApp.GetById(id);
            var gameViewModel = Mapper.Map<Game, GameViewModel>(game);
            return View(gameViewModel);
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameViewModel game)
        {
            if (ModelState.IsValid)
            {
                var gameDomain = Mapper.Map<GameViewModel, Game>(game);
                _gameApp.Add(gameDomain);
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Game/Edit/5
        public ActionResult Edit(int id)
        {
            var game = _gameApp.GetById(id);
            var gameViewModel = Mapper.Map<Game, GameViewModel>(game);
            return View(gameViewModel);
        }

        // POST: Game/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GameViewModel game)
        {
            if (ModelState.IsValid)
            {
                var gameDomain = Mapper.Map<GameViewModel, Game>(game);
                _gameApp.Update(gameDomain);
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Game/Delete/5
        public ActionResult Delete(int id)
        {
            var game = _gameApp.GetById(id);
            var gameViewModel = Mapper.Map<Game, GameViewModel>(game);
            return View(gameViewModel);
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var game = _gameApp.GetById(id);
            _gameApp.Remove(game);
            return RedirectToAction("Index");
        }
    }
}
