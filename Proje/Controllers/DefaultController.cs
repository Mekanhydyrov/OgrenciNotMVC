using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;

namespace OgrenciNotMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            //Dersleri Listeleme kodu
            var dersListesi = db.TblDers.ToList();
            return View(dersListesi);
        }

        [HttpGet]
        public ActionResult YeniDers()
        {
            //boş deger döndürmemesi için kod
            return View();
        }

        [HttpPost]
        public ActionResult YeniDers(TblDers pEkle)
        {
            //yeni ders eklemek için kod
            db.TblDers.Add(pEkle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            //Ders Silme kodu
            var deger = db.TblDers.Find(id);
            db.TblDers.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            //Deger sayfaya id göre veri taşama kodu
            var deger = db.TblDers.Find(id);
            return View("DersGetir",deger);
        }
        public ActionResult Guncelle(TblDers p)
        {
            var deger = db.TblDers.Find(p.Dersid);
            deger.DersAd = p.DersAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}