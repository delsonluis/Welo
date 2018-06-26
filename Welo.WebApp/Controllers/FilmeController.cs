using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Welo.Application.Interfaces;
using Welo.Domain.Entities;

namespace Welo.WebApp.Controllers
{
    public class FilmeController : Controller
    {
        private IFilmeAppService _service;
        private IEnumerable<string> _listGenero;

        public FilmeController(IFilmeAppService service)
        {
            _service = service;
            _listGenero = new List<string>
            {
                "Suspense",
                "Terror",
                "Comedia"
            };

            ViewBag.ListGenero = _listGenero.Select(p => new SelectListItem()
            {
                Value = p,
                Text = p
            });
        }

        // GET: Filme
        public ActionResult Index()
        {
            var list = _service.GetAll();

            ViewBag.List = list.Count() > 0 ? list.ToList() : null;

            return View();
        }

        // GET: Filme/Details/5
        public ActionResult Details(int id)
        {
            

            return View();
        }

        // GET: Filme/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filme/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = new FilmeEntity();
                    entity.Nome = collection["Nome"].ToString();
                    entity.Ano = int.Parse(collection["Ano"].ToString());

                    var genero = collection["Genero"];

                    entity.Genero = genero.Split(new char[] { ',' }).ToList();

                    _service.Add(entity);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Filme/Edit/5
        public ActionResult Edit(int id)
        {
            var entity = _service.Get(id);

            if (entity == null)
            {
                return HttpNotFound();
            }

            return View(entity);
        }

        // POST: Filme/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _service.Get(id);
                    entity.Nome = collection["Nome"].ToString();
                    entity.Ano = int.Parse(collection["Ano"].ToString());

                    var genero = collection["Genero"];

                    entity.Genero = genero.Split(new char[] { ',' }).ToList();

                    _service.Update(entity);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Filme/Delete/5
        public ActionResult Delete(int id)
        {
            var entity = _service.Get(id);

            if (entity == null)
            {
                return HttpNotFound();
            }

            return View(entity);
        }

        // POST: Filme/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _service.Get(id);
                    _service.Remove(entity);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
