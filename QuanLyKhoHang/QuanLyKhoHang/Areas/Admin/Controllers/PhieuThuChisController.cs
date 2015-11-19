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
    public class PhieuThuChisController : Controller
    {
        private Entities db = new Entities();

        // GET: Admin/PhieuThuChis
        public ActionResult Index()
        {
            var phieuThuChies = db.PhieuThuChies.Include(p => p.DoiTac).Include(p => p.HoaDon);
            return View(phieuThuChies.ToList());
        }

        // GET: Admin/PhieuThuChis/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThuChi phieuThuChi = db.PhieuThuChies.Find(id);
            if (phieuThuChi == null)
            {
                return HttpNotFound();
            }
            return View(phieuThuChi);
        }

        // GET: Admin/PhieuThuChis/Create
        public ActionResult Create()
        {
            ViewBag.MaDT = new SelectList(db.DoiTacs, "MaDT", "MaSoThue");
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "TenTK_NV");
            return View();
        }

        // POST: Admin/PhieuThuChis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPH,MaDT,MaHD,GiaTri,LoaiPhieu,Thoigian")] PhieuThuChi phieuThuChi)
        {
            if (ModelState.IsValid)
            {
                db.PhieuThuChies.Add(phieuThuChi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDT = new SelectList(db.DoiTacs, "MaDT", "MaSoThue", phieuThuChi.MaDT);
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "TenTK_NV", phieuThuChi.MaHD);
            return View(phieuThuChi);
        }

        // GET: Admin/PhieuThuChis/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThuChi phieuThuChi = db.PhieuThuChies.Find(id);
            if (phieuThuChi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDT = new SelectList(db.DoiTacs, "MaDT", "MaSoThue", phieuThuChi.MaDT);
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "TenTK_NV", phieuThuChi.MaHD);
            return View(phieuThuChi);
        }

        // POST: Admin/PhieuThuChis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPH,MaDT,MaHD,GiaTri,LoaiPhieu,Thoigian")] PhieuThuChi phieuThuChi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuThuChi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDT = new SelectList(db.DoiTacs, "MaDT", "MaSoThue", phieuThuChi.MaDT);
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "TenTK_NV", phieuThuChi.MaHD);
            return View(phieuThuChi);
        }

        // GET: Admin/PhieuThuChis/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThuChi phieuThuChi = db.PhieuThuChies.Find(id);
            if (phieuThuChi == null)
            {
                return HttpNotFound();
            }
            return View(phieuThuChi);
        }

        // POST: Admin/PhieuThuChis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuThuChi phieuThuChi = db.PhieuThuChies.Find(id);
            db.PhieuThuChies.Remove(phieuThuChi);
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
