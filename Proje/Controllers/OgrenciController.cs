using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;

namespace OgrenciNotMVC.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            //Öğrenci Listeleme işlemi
            var OgrenciListele = db.TblOgrenci.ToList();
            return View(OgrenciListele);
        }

        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            //DropdownListe Veri Yazdırma
            var deger = (from i in db.TblKulup.ToList()
                         select new SelectListItem
                         {
                             Text = i.KulupAd,
                             Value = i.Kulupid.ToString()
                         }).ToList();
            ViewBag.dgr = deger;
            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrenci(TblOgrenci pEkle)
        {
            //DrownList veri tabana Ekleme kodu
            var klp = db.TblKulup.Where(m => m.Kulupid == pEkle.TblKulup.Kulupid).FirstOrDefault();
            pEkle.TblKulup = klp;

            //yeni Öğrenci Eklemek
            db.TblOgrenci.Add(pEkle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            //Ogrenci silme kodu
            var deger = db.TblOgrenci.Find(id);
            db.TblOgrenci.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrGetir(int id)
        {
            //DrownListe deger taşamak ve yazdırmak
            var kulup = (from i in db.TblKulup.ToList()
                         select new SelectListItem
                         {
                             Text = i.KulupAd,
                             Value = i.Kulupid.ToString()
                         }).ToList();
            ViewBag.dgr = kulup;

            //ogrenci id göre verileri taşama kodu
            var deger = db.TblOgrenci.Find(id);
            return View("OgrGetir", deger);
        }
        public ActionResult Guncelle(TblOgrenci p)
        {
            //Ogrenci Güncelleme kodu
            var deger = db.TblOgrenci.Find(p.Ogrid);
            deger.OgrAd = p.OgrAd;
            deger.OgrSoyad = p.OgrSoyad;
            deger.OgrFoto = p.OgrFoto;
            deger.OgrCinsiyet = p.OgrCinsiyet;

            //DropnList veri Güncelleme
            var ogr = db.TblKulup.Where(m => m.Kulupid == p.TblKulup.Kulupid).FirstOrDefault();
            deger.OgrKulup = ogr.Kulupid;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}