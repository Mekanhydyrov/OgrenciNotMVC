using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;

namespace OgrenciNotMVC.Controllers
{
    public class KulupController : Controller
    {
        // GET: Kulup
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            //Kulup Listeleme Kodu
            var KulupListele = db.TblKulup.ToList();
            return View(KulupListele);
        }
        
        [HttpGet]
        public ActionResult YeniKulup()
        {
            //nul deger döndürmemesi için kod
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulup(TblKulup pEkle)
        {
            //kulup ekleme kodu
            db.TblKulup.Add(pEkle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            //Kulup Silme kodu
            var deger = db.TblKulup.Find(id);
            db.TblKulup.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir(int id)
        {
            //id göre veri taşama kodu
            var deger = db.TblKulup.Find(id);
            return View("KulupGetir",deger);
        }
        public ActionResult Guncelle(TblKulup p)
        {
            //Kulup Güncelleme kodu
            var deger = db.TblKulup.Find(p.Kulupid);
            deger.KulupAd = p.KulupAd;
            deger.KulupKontenjan = p.KulupKontenjan;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}