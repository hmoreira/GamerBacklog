using System.Collections.Generic;
using System.Web.Mvc;
using GamerBacklog.Application.Interfaces;
using GamerBacklog.Domain.Entities;
using Newtonsoft.Json;

namespace GamerBacklog.MVC.Controllers
{
    public class PlatformController : Controller
    {
        private readonly IPlatformAppService _platformApp;

        public PlatformController(IPlatformAppService platformApp)
        {
            _platformApp = platformApp;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public string ObtemPlataformas()
        {
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            IEnumerable<Platform> platforms = _platformApp.GetAll();
            return JsonConvert.SerializeObject(platforms, jsonSettings);
        }
    }
}
