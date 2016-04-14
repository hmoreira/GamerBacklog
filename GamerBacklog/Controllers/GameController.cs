using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Model;
using BLL;

namespace GamerBacklog.Controllers
{
    public class GameController : Controller
    {
        //
        private Repositories.IRepository<Game, int> _repository;

        public GameController(Repositories.IRepository<Game, int> repo)
        {
            _repository = repo;
        }
        // GET: Game
        public ActionResult Index()
        {
            var Games = _repository.Get();
            return View(Games);
        }

        public ActionResult Create()
        {
            var game = new Game();
            return View(game);
        }

        [HttpPost]
        public ActionResult Create(Game game)
        {
            _repository.Add(game);
            return RedirectToAction("Index");
        }

        // GET: Game/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            else
            {
                var game = _repository.Get(id.Value);
                if (game == null)
                    return HttpNotFound();
                else
                    return View(game);
            }
        }        

        // GET: Game/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            else
            {
                var game = _repository.Get(id.Value);
                if (game == null)
                    return HttpNotFound();
                else 
                    return View(game);
            }            
            
        }

        // POST: Game/Edit/5
        [HttpPost]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Game/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            else
            {
                var game = _repository.Get(id.Value);
                if (game == null)
                    return HttpNotFound();
                else
                    return View(game);
            }       
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var _game = _repository.Get(id);
            if (_game == null)
                return HttpNotFound();
            else
                _repository.Remove(_game);
            
            return RedirectToAction("Index");
        }
       
    }
}
