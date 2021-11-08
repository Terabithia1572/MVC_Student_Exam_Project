using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgnreciNotMVC.Models.EntityFramework;

namespace OgnreciNotMVC.Controllers
{
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler
        DbMVCOkulEntities db = new DbMVCOkulEntities();
        public ActionResult Index()
        {
            var Ogrenciler = db.Tbl_Ogrenciler.ToList();
            return View(Ogrenciler);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.Tbl_Kulupler.ToList() //4 parametreli bir başlığı var ilk from nerden alacağı 2.si i değişken adımız 3.sü db. nesnemizden türettiğmiz hangi tablodan Tolist'de Listeleme metodu

                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString() //KulupID int olduğu için metne çevirmen lazım diyor
                                             }).ToList();
            ViewBag.dgr = degerler; //Benim Controller tarafımdaki bu ifademi View tarafına taşımam için bir komut ataması yapıyorum dgs anonoim bir isim rastgele verdik birazdan onu kullanıcaz
            return View();
          
        }
        [HttpPost]
        public ActionResult YeniOgrenci(Tbl_Ogrenciler p3)
        {
            var klp = db.Tbl_Kulupler.Where(m => m.KULUPID == p3.Tbl_Kulupler.KULUPID).FirstOrDefault();
            db.Tbl_Ogrenciler.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ogr = db.Tbl_Ogrenciler.Find(id);
            db.Tbl_Ogrenciler.Remove(ogr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.Tbl_Ogrenciler.Find(id);

            List<SelectListItem> degerler = (from i in db.Tbl_Kulupler.ToList() //4 parametreli bir başlığı var ilk from nerden alacağı 2.si i değişken adımız 3.sü db. nesnemizden türettiğmiz hangi tablodan Tolist'de Listeleme metodu

                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString() //KulupID int olduğu için metne çevirmen lazım diyor
                                             }).ToList();
            ViewBag.dgr = degerler; //Benim Controller tarafımdaki bu ifademi View tarafına taşımam için bir komut ataması yapıyorum dgs anonoim bir isim rastgele verdik birazdan onu kullanıcaz
            return View("OgrenciGetir", ogrenci);
        }

        public ActionResult Guncelle(Tbl_Ogrenciler p)
        {
            var ogr = db.Tbl_Ogrenciler.Find(p.OGRENCIID);
            ogr.OGRAD = p.OGRAD;
            ogr.OGRSOYAD = p.OGRSOYAD;
            ogr.OGRFOTO = p.OGRFOTO;
            ogr.OGRCINSIYET = p.OGRCINSIYET;
            ogr.OGRKULUP = p.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index","Ogrenciler");
        }

    }
}

//List<SelectListItem> items = new List<SelectListItem>(); //Burada bi tane Liste oluşturduk items adlı bir nesnem var items aracılığı ile listemdeki alanlara değer eklemesi yapıyorum
//                                                         //bu değerler 2 parametreden oluşuyor 1.si Text 2.si Value,Text dediğimiz alan kullanıcının göreceği alanı gösteriyor Value ise o text'in arka planda kullanacağı değeri gösteriyor


//items.Add(new SelectListItem { Text = "Matematik", Value = "0" });

//            items.Add(new SelectListItem { Text = "Fen Bilgisi", Value = "1" });

//            items.Add(new SelectListItem { Text = "Atatürk İlke ve İnkılapları", Value = "2"});

//            items.Add(new SelectListItem { Text = "Coğrafya", Value = "3" });

//           // ViewBag.MovieType = items; //ViewBag komutu aracalığı ile de ben bunları nereye taşıyacağım View'e taşıyacağım MovieType ise bunların isimleri demek yani şu yapının ismi
//                                        //MovieType şimdi ben bunu nerde kullanıcam şimdi bi komut var onu göstericem .(Noktadan) sonraki değeri biz yazıcaz bir dğeişken ismi gibi olacak
//                                        //örneğin MovieType değilde DersAdlari Olsun mesela ya da Ders Ad
//              ViewBag.DersAd = items;