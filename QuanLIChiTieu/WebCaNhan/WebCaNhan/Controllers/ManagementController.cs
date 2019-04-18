using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebCaNhan.Controllers
{
    public class ManagementController : Controller
    {
        private Expenditure99Entities db = new Expenditure99Entities();

        // GET: /Management/
        public ActionResult Index()
        {
            return View(db.QuanLyChiTieuCaNhans.ToList());
        }

        // GET: /Management/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanLyChiTieuCaNhan quanlychitieucanhan = db.QuanLyChiTieuCaNhans.Find(id);
            if (quanlychitieucanhan == null)
            {
                return HttpNotFound();
            }
            return View(quanlychitieucanhan);
        }

        // GET: /Management/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Management/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuanLyChiTieuCaNhan model)
        {
            ValidateExpenditure(model);
            if (ModelState.IsValid)
            {
                model.Date = DateTime.Today;
                db.QuanLyChiTieuCaNhans.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        private void ValidateExpenditure(QuanLyChiTieuCaNhan model)
        {
            if (model.Amount <= 0)
            {
                ModelState.AddModelError("Amount", "Số tiền quá ít!");
            }
        }

        // GET: /Management/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanLyChiTieuCaNhan quanlychitieucanhan = db.QuanLyChiTieuCaNhans.Find(id);
            if (quanlychitieucanhan == null)
            {
                return HttpNotFound();
            }
            return View(quanlychitieucanhan);
        }

        // POST: /Management/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Date,Amount,Detail")] QuanLyChiTieuCaNhan quanlychitieucanhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quanlychitieucanhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quanlychitieucanhan);
        }

        // GET: /Management/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanLyChiTieuCaNhan quanlychitieucanhan = db.QuanLyChiTieuCaNhans.Find(id);
            if (quanlychitieucanhan == null)
            {
                return HttpNotFound();
            }
            return View(quanlychitieucanhan);
        }

        // POST: /Management/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuanLyChiTieuCaNhan quanlychitieucanhan = db.QuanLyChiTieuCaNhans.Find(id);
            db.QuanLyChiTieuCaNhans.Remove(quanlychitieucanhan);
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
