using Aula4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Aula4.Controllers
{
    public class PersonController : Controller
    {

        // GET: PersonController
        public ActionResult Index()
        {
            
            var lista = Ler();
            
            

            //var lista = Person.Lista;

            return View(lista);
        }

        private List<Person> Iniciar()
        {
            var lista = Person.Lista;
            if (Ler().Count == 0) Gravar(lista);
            return lista;
            
        }
        private List<Person> Ler()

        {
            var lista = Person.Lista;
            string people = HttpContext.Session.GetString("people");
            
            if (String.IsNullOrEmpty(people))
            {
                lista = Iniciar();
            }
            else
            {
                lista = JsonConvert.DeserializeObject<List<Person>>(people);
            }
                return lista;
        }

        private void Gravar(List<Person> lista)
        {
            string people;
            people = JsonConvert.SerializeObject(lista);
            HttpContext.Session.SetString("people", people);
        }

        private void GerarListaNaSessao()
        {
            string people = JsonConvert.SerializeObject(Person.Lista);
            HttpContext.Session.SetString("people", people);
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View(Person.Lista[id]);
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
