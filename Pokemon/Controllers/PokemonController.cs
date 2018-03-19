using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pokemon.Models;

namespace Pokemon.Controllers
{
    public class PokemonController : Controller
    {
        private PokemonContext db = new PokemonContext();
        private TrainerContext db2 = new TrainerContext();

        // GET: /Pokemon/
        public ActionResult Index()
        {
            return View(db.Pokemons.ToList());
        }

        // GET: /Pokemon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PokemonModel pokemonmodel = db.Pokemons.Find(id);
            if (pokemonmodel == null)
            {
                return HttpNotFound();
            }
            return View(pokemonmodel);
        }


        // GET: /Pokemon/Details/5
        public ActionResult Trainers_Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerModel trainermodel = db2.Trainers.Find(id);
            if (trainermodel == null)
            {
                return HttpNotFound();
            }
            return View(trainermodel);
        }

        // GET: /Pokemon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Pokemon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="pokemon_id,pokemon_name,pokemon_type,pokemon_level,trainer_id")] PokemonModel pokemonmodel)
        {
            if (ModelState.IsValid)
            {
                db.Pokemons.Add(pokemonmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pokemonmodel);
        }

        // GET: /Pokemon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PokemonModel pokemonmodel = db.Pokemons.Find(id);
            if (pokemonmodel == null)
            {
                return HttpNotFound();
            }
            return View(pokemonmodel);
        }

        // POST: /Pokemon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="pokemon_id,pokemon_name,pokemon_type,pokemon_level,trainer_id")] PokemonModel pokemonmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pokemonmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pokemonmodel);
        }

        // GET: /Pokemon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PokemonModel pokemonmodel = db.Pokemons.Find(id);
            if (pokemonmodel == null)
            {
                return HttpNotFound();
            }
            return View(pokemonmodel);
        }

        // POST: /Pokemon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PokemonModel pokemonmodel = db.Pokemons.Find(id);
            db.Pokemons.Remove(pokemonmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
