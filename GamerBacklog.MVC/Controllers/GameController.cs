using System.Web.Mvc;
using System;
using GamerBacklog.Application.Interfaces;
using System.Collections.Generic;
using GamerBacklog.Domain.Entities;
using Newtonsoft.Json;

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
            return View();
        }

        public JsonResult ObtemGames()
        {
            IEnumerable<Game> games = _gameApp.GetAll();
            return Json(games, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string Adicionar(string nome, List<int> platformIds)
        {
            try
            {
                Game game = new Game();
                List<Platform> platforms = new List<Platform>();

                foreach (var platformId in platformIds)
                {
                    platforms.Add(new Platform
                    {
                        PlatformId = platformId
                    });
                }

                game.Nome = nome;
                game.Platforms = platforms;

                _gameApp.Add(game);

                return JsonConvert.SerializeObject("OK", Formatting.Indented);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message, Formatting.Indented);
            }
        }

    }
}
