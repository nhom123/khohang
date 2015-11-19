using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyKhoHang.Models.Entities;

namespace QuanLyKhoHang.Areas.Admin.Controllers
{
    public class GiaoDichController : Controller
    {
        private Entities db = new Entities();

        // GET: Admin/GiaoDich
        public ActionResult Index()
        {
            var cT_HoaDon = db.CT_HoaDon.Include(c => c.HangHoa).Include(c => c.HoaDon);
            return View(cT_HoaDon.ToList());
        }

        // GET: Admin/GiaoDich/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HoaDon cT_HoaDon = db.CT_HoaDon.Find(id);
            if (cT_HoaDon == null)
            {
                return HttpNotFound();
            }
            return View(cT_HoaDon);
        }

        // GET: Admin/GiaoDich/Create
        public ActionResult Create()
        {
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHH", "TenHH");
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "TenTK_NV");
            return View();
        }

        // POST: Admin/GiaoDich/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaHH,SoLuong,DVT,DonGia")] CT_HoaDon cT_HoaDon)
        {
            if (ModelState.IsValid)
            {
                db.CT_HoaDon.Add(cT_HoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHH", "TenHH", cT_HoaDon.MaHH);
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "TenTK_NV", cT_HoaDon.MaHD);
            return View(cT_HoaDon);
        }

        // GET: Admin/GiaoDich/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HoaDon cT_HoaDon = db.CT_HoaDon.Find(id);
            if (cT_HoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHH", "TenHH", cT_HoaDon.MaHH);
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "TenTK_NV", cT_HoaDon.MaHD);
            return View(cT_HoaDon);
        }

        // POST: Admin/GiaoDich/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,MaHH,SoLuong,DVT,DonGia")] CT_HoaDon cT_HoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_HoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHH", "TenHH", cT_HoaDon.MaHH);
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "TenTK_NV", cT_HoaDon.MaHD);
            return View(cT_HoaDon);
        }

        // GET: Admin/GiaoDich/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HoaDon cT_HoaDon = db.CT_HoaDon.Find(id);
            if (cT_HoaDon == null)
            {
                return HttpNotFound();
            }
            return View(cT_HoaDon);
        }

        // POST: Admin/GiaoDich/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CT_HoaDon cT_HoaDon = db.CT_HoaDon.Find(id);
            db.CT_HoaDon.Remove(cT_HoaDon);
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
