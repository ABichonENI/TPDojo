using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using TPDojo1.Data;
using TPDojo1.Models;

namespace TPDojo1.Controllers
{
    public class SamouraisController : Controller
    {
        private TPDojo1Context db = new TPDojo1Context();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {

            var samouraiVM = new SamouraiVM();
            samouraiVM.Armes = db.Armes.ToList();
            samouraiVM.ArtMartials = db.ArtMartials.ToList();
            return View(samouraiVM);
        }

        // POST: Samourais/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiVM samouraiVM)
        {
            if (ModelState.IsValid)
            {
                samouraiVM.Samourai.Arme = db.Armes.FirstOrDefault(a=> a.Id == samouraiVM.IdArmeSamourai);
                samouraiVM.Samourai.ArtMartials = db.ArtMartials.Where(x=> samouraiVM.IdArtmartials.Contains(x.Id)).ToList();
                db.Samourais.Add(samouraiVM.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(samouraiVM);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }

            SamouraiVM samouraiVM = new SamouraiVM();
            samouraiVM.Samourai = samourai;
            samouraiVM.Armes = db.Armes.ToList();
            if(samouraiVM.Samourai.Arme != null)
            {
                samouraiVM.IdArmeSamourai = samouraiVM.Samourai.Arme.Id;
            }
            samouraiVM.ArtMartials = db.ArtMartials.ToList();
            samouraiVM.IdArtmartials = samouraiVM.Samourai.ArtMartials.Select(m => m.Id).ToList();
            
            return View(samouraiVM);
        }

        // POST: Samourais/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( SamouraiVM samouraiVM)
        {
            if (ModelState.IsValid)
            {
                var samourai = db.Samourais.Include(x=>x.ArtMartials).FirstOrDefault(x=> x.Id == samouraiVM.Samourai.Id);
                samourai.Force = samouraiVM.Samourai.Force ;
                samourai.Nom = samouraiVM.Samourai.Nom ;
                
                samourai.Arme = db.Armes.FirstOrDefault(a => a.Id == samouraiVM.IdArmeSamourai);

                if(samouraiVM.Samourai.Arme != null)
                {
                    samouraiVM.IdArmeSamourai = samouraiVM.Samourai.Arme.Id; 
                }
                
                samourai.ArtMartials = db.ArtMartials.Where(x=>samouraiVM.IdArtmartials.Contains(x.Id)).ToList();
                
               // if (samouraiVM.Samourai.ArtMartials != null) 
                //{
                  //  samouraiVM.IdArtmartials = samouraiVM.Samourai.ArtMartials.
                //}

                    db.Entry(samourai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(samouraiVM);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
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
