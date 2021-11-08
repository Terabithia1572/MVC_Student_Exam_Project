using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgnreciNotMVC.Models.EntityFramework;
using OgnreciNotMVC.Models;

namespace OgnreciNotMVC.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Sinavlar
        DbMVCOkulEntities db = new DbMVCOkulEntities();
        public ActionResult Index()
        {
            var Not = db.Tbl_Notlar.ToList();
            return View(Not);
        }

        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }
        [HttpPost]

        public ActionResult YeniSinav(Tbl_Notlar tbn)
        {
            db.Tbl_Notlar.Add(tbn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NotGetir(int id)
        {
            var notlar = db.Tbl_Notlar.Find(id);

            return View("NotGetir",notlar);
        }

        [HttpPost]
        public ActionResult NotGetir(Class1 model,Tbl_Notlar p,int SINAV1 = 0,int SINAV2 = 0,int SINAV3 = 0,int PROJE = 0)
        {
            //Tbl_notlardan bir tane p nesnesi türettim içerisinden diğer parametre olarak sinav gönderidm bide class 1 den modeli aldım

            if (model.islem == "HESAPLA")
            {
                //İşlem 1

                int ORTALAMA = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;

                ViewBag.orta = ORTALAMA;

            }
                if(model.islem=="NOTGUNCELLE")
                {
                //İŞLEM 2

                var not = db.Tbl_Notlar.Find(p.NOTID);
                not.SINAV1 = p.SINAV1;
                not.SINAV2 = p.SINAV2;
                not.SINAV3 = p.SINAV3;
                not.PROJE = p.PROJE;
                not.ORTALAMA = p.ORTALAMA;
                not.DURUM = p.DURUM;
               not.OGRID = p.OGRID;
                db.SaveChanges();
                return RedirectToAction("Index", "Notlar");
                }
            return View();
        }
    }
}