using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC.Models.EntityFramework;
using OgrenciNotMVC.Models;

namespace OgrenciNotMVC.Controllers
{
    public class NotController : Controller
    {
        // GET: Not
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            //Not Listeleme Kodu
            var NotListele = db.TblNot.ToList();
            return View(NotListele);
        }

        [HttpGet]
        public ActionResult YeniNot()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniNot(TblNot pEkle)
        {
            //Yeni Not Ekleme kodu
            db.TblNot.Add(pEkle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotGetir(int id)
        {
            //id göre verileri deger sayfaya taşama kodu
            var deger = db.TblNot.Find(id);
            db.SaveChanges();
            return View("NotGetir", deger);
        }

        [HttpPost]
        public ActionResult NotGetir(Class1 model, TblNot p, int Viza=0, int Final=0, int But=0, int Proje=0)
        {
            if (model.islem == "Hesapla")
            {
                //hesaplama işlemi 
                int Ortalama = (Viza + Final + But + Proje) / 4;
                ViewBag.ort = Ortalama;
            }
            if (model.islem == "Guncelle")
            {
                //Not Güncelleme kodu
                var snv = db.TblNot.Find(p.Notid);
                snv.Viza = p.Viza;
                snv.Final = p.Final;
                snv.But = p.But;
                snv.Ortalama = p.Ortalama;
                snv.Proje = p.Proje;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}