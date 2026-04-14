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
            return new List<Person>
            {
                new Person { Nome = "Lisa", Idade = 17 },
                new Person { Nome = "LiKaDuo", Idade = 17 },
                new Person { Nome = "Juan", Idade = 16 }
            };

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
                if (lista.Count() == 0)
                {
                    lista = Iniciar();
                }
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
            var lista = Ler();
            return View(lista[id]);
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View(new Person());
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            try
            {
                var lista = Ler();
                lista.Add(person);
                Gravar(lista);
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
            var lista = Ler();
            return View(lista[id]);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Person person)
        {
            try
            {
                var lista = Ler();
                lista[id] = person;
                Gravar(lista);
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
            var lista = Ler();
            return View(lista[id]);
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Person person)
        {
            try
            {
                var lista = Ler();
                lista.RemoveAt(id);
                Gravar(lista);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
