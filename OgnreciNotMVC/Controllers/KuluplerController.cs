using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgnreciNotMVC.Models.EntityFramework;


namespace OgnreciNotMVC.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DbMVCOkulEntities db = new DbMVCOkulEntities();
        public ActionResult Index()
        {
            var Kulupler = db.Tbl_Kulupler.ToList();
            return View(Kulupler);
        }

        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulup(Tbl_Kulupler p2)
        {
            db.Tbl_Kulupler.Add(p2);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id) //Silme işlemi gerçekleştiricem ama buraya bi tane id değeri gönderiyorum neden çünkü bir id'ye göre silicem
        {
            var kulup = db.Tbl_Kulupler.Find(id); //Silme işlemi gerçekleştiricem ama ilk önceye silinecek değeri bulmam gerekiyor
                                                  //db.Tbl_kulupler içerisinde bul neyi bulacak benim gönderdiğim id'ye göre değer bul anlamında kullandık burayı tamam buldu sonra ne yapıcak
            db.Tbl_Kulupler.Remove(kulup); //Tbl_kulupler içerisinden gelen değeri sil nerden gelen değer kulup içerisinde gelen değerden sil anlamında kullandık
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir(int id) //Güncelleme işlemi yaparken başta taşıma işlemi yapıcaz
        {
            var GetirilecekKulup = db.Tbl_Kulupler.Find(id); //Dersi Buldurduk burda id'sine göre
            return View("KulupGetir", GetirilecekKulup); //Burada bize Sayfayı Döndür ama neyle birlikte döndür kulup değişkeninden gelen değerle
        }

        public ActionResult Guncelle(Tbl_Kulupler p)
        {
            var klp = db.Tbl_Kulupler.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulupler");
        }
    }
}