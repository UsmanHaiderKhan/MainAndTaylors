using MainTaylorANDClothes.Models;
using Rotativa;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MainTaylorANDClothes.Controllers
{
    public class TaylorsController : Controller
    {
        private TaylorContext db = new TaylorContext();

        // GET: Taylors
        public ActionResult Index()
        {
            return View(db.Taylors.ToList());
        }

        // GET: Taylors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Taylor taylor = db.Taylors.Find(id);
            if (taylor == null)
            {
                return HttpNotFound();
            }

            return View(taylor);
        }

        public ActionResult PrintDetails()
        {
            var q = new ActionAsPdf("Index");
            return q;
        }
        // GET: Taylors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Taylors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerName,CellNo,KamezLenght,Tera,Galla,Kandha,Baghal,Bazoo,Kohni,Chest,Kamar,Ghera,ShalwaarLenght,Aasan,Ponchha,Palla,Kundha,Kundhi,Saali,Kaff,Button,Pocket,Sticker,TotalSuit,Gheras")] Taylor taylor)
        {
            if (ModelState.IsValid)
            {
                db.Taylors.Add(taylor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taylor);
        }

        // GET: Taylors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taylor taylor = db.Taylors.Find(id);
            if (taylor == null)
            {
                return HttpNotFound();
            }
            return View(taylor);
        }

        // POST: Taylors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerName,CellNo,KamezLenght,Tera,Galla,Kandha,Baghal,Bazoo,Kohni,Chest,Kamar,Ghera,ShalwaarLenght,Aasan,Ponchha,Palla,Kundha,Kundhi,Saali,Kaff,Button,Pocket,Sticker,TotalSuit,Gheras")] Taylor taylor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taylor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taylor);
        }

        // GET: Taylors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taylor taylor = db.Taylors.Find(id);
            if (taylor == null)
            {
                return HttpNotFound();
            }
            return View(taylor);
        }

        // POST: Taylors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Taylor taylor = db.Taylors.Find(id);
            db.Taylors.Remove(taylor);
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
