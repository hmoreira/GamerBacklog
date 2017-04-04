using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using GamerBacklog.Application.Interfaces;
using GamerBacklog.Domain.Entities;
using GamerBacklog.MVC.ViewModels;

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
            var platformViewModel = Mapper.Map<IEnumerable<Platform>, IEnumerable<PlatformViewModel>>(_platformApp.GetAll());
            return View(platformViewModel);
        }
        
        public ActionResult Details(int id)
        {
            var platform = _platformApp.GetById(id);
            var platformViewModel = Mapper.Map<Platform, PlatformViewModel>(platform);
            return View(platformViewModel);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlatformViewModel platform)
        {
            if (ModelState.IsValid)
            {
                var platformDomain = Mapper.Map<PlatformViewModel, Platform>(platform);
                _platformApp.Add(platformDomain);
                return RedirectToAction("Index");
            }

            return View(platform);
        }
        
        public ActionResult Edit(int id)
        {
            var platform = _platformApp.GetById(id);
            var platformViewModel = Mapper.Map<Platform, PlatformViewModel>(platform);
            return View(platformViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlatformViewModel platform)
        {
            if (ModelState.IsValid)
            {
                var platformDomain = Mapper.Map<PlatformViewModel, Platform>(platform);
                _platformApp.Update(platformDomain);
                return RedirectToAction("Index");
            }

            return View(platform);
        }
        
        public ActionResult Delete(int id)
        {
            var platform = _platformApp.GetById(id);
            var platformViewModel = Mapper.Map<Platform, PlatformViewModel>(platform);
            return View(platformViewModel);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var platform = _platformApp.GetById(id);
            _platformApp.Remove(platform);
            return RedirectToAction("Index");
        }
    }
}
