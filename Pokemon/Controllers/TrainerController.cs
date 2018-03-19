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
    public class TrainerController : Controller
    {
        private TrainerContext db = new TrainerContext();
        public PokemonContext db2 = new PokemonContext();

        // GET: /Trainer/
        public ActionResult Index()
        {
            return View(db.Trainers.ToList());
        }

        public ActionResult TrainersPokemon(int Id)
        {
           // StudentContext cs = new StudentContext(); Students.Where(s => s.Course_ID == Id).ToList();
            List<PokemonModel> Pokemons = db2.Pokemons.Where(p => p.trainer_id == Id).ToList();
            return View(Pokemons);

        }

        

        // GET: /Trainer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerModel trainermodel = db.Trainers.Find(id);
            if (trainermodel == null)
            {
                return HttpNotFound();
            }
            return View(trainermodel);
        }

        // GET: /Trainer/Details/5
        public ActionResult Details_for_pokemon(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PokemonModel pokemonmodel = db2.Pokemons.Find(id);
            if (pokemonmodel == null)
            {
                return HttpNotFound();
            }
            return View(pokemonmodel);
        }

        // GET: /Trainer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Trainer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="trainer_id,trainer_name,trainer_age,address")] TrainerModel trainermodel)
        {
            if (ModelState.IsValid)
            {
                db.Trainers.Add(trainermodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainermodel);
        }

        // GET: /Trainer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerModel trainermodel = db.Trainers.Find(id);
            if (trainermodel == null)
            {
                return HttpNotFound();
            }
            return View(trainermodel);
        }


        // GET: /Trainer/Edit/5
        public ActionResult Edit_for_pokemon(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PokemonModel pokemonmodel = db2.Pokemons.Find(id);
            if (pokemonmodel == null)
            {
                return HttpNotFound();
            }
            return View(pokemonmodel);
        }


        // POST: /Trainer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_for_pokemon([Bind(Include = "pokemon_id,pokemon_name,pokemon_type,pokemon_level,trainer_id")] PokemonModel pokemonmodel)
        {
            if (ModelState.IsValid)
            {
                db2.Entry(pokemonmodel).State = EntityState.Modified;
                db2.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pokemonmodel);
        }

        // POST: /Trainer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="trainer_id,trainer_name,trainer_age,address")] TrainerModel trainermodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainermodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainermodel);
        }

        // GET: /Trainer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainerModel trainermodel = db.Trainers.Find(id);
            if (trainermodel == null)
            {
                return HttpNotFound();
            }
            return View(trainermodel);
        }

        //Delete_for_pokemon

        public ActionResult Delete_for_pokemon(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PokemonModel pokemonmodel = db2.Pokemons.Find(id);
            if (pokemonmodel == null)
            {
                return HttpNotFound();
            }
            return View(pokemonmodel);
        }


        // POST: /Trainer/Delete/5
        [HttpPost, ActionName("Delete_for_pokemon")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed2(int id)
        {
            PokemonModel pokemonmodel = db2.Pokemons.Find(id);
            db2.Pokemons.Remove(pokemonmodel);
            db2.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: /Trainer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainerModel trainermodel = db.Trainers.Find(id);
            db.Trainers.Remove(trainermodel);
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
