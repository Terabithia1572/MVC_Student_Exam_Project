using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgnreciNotMVC.Models.EntityFramework;// bizim burda entitiy framework içindeki models ulaşmamız için kütüphane tanımladık

namespace OgnreciNotMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        // Action Result üzerinde bir nesne oluşturacağız bu nesne bizim DbMVCOkulEntities olacak
        DbMVCOkulEntities db = new DbMVCOkulEntities(); // bu nesnemiz ne işe yarayacak DbMVCOkulEntities içinde bulunan tablolara ulaşmak için kullanacağımız nesne
        public ActionResult Index() //Index sağ tıklayıp bir view ekleyeceğiz bu controllere ait bir sayfa olacak anlamında her controllerın bir sayfa değeri olacak
        {

            var dersler = db.Tbl_Dersler.ToList(); //bir değişken oluşturduk adını dersler yaptık sonra db nesnemden gelen hangi tabloya ait alanım tbl_dersler alanıma ait alanlar tbl_dersler metdoumu ne yapıcam listeleyecem
            return View(dersler); //geriye sayfayı döndüreceksin ama sayfa içinde neyi döndüreceksin dersler adlı değilşkinime gelecek değerleri döndür
        }

        //Burası Çok önemli ekleme yapmak için [HttpPost] komutumuz var
        //Bnunun Bir Değer Göndereceğim zaman bir Tetikleme olacak anlamında
     //   [HttpPost]

        [HttpGet] //bura ne zaman çalışacak Http Get olduğu zaman çalışıcak
        public ActionResult YeniDers()
        {
            return View();
        }
        [HttpPost] //bura ne zaman çalışacak Http Post olduğu zaman çalışıcak yani bir değer göndereceğim zaman 
        public ActionResult YeniDers(Tbl_Dersler p) //Burada Yeni Ders Kaydı Yapmak İçin Bir ActionResult Tanımladık ve Kendi View'ini oluşturucaz Yeni Ders Sağ tıklatıp Add View Diyicez
            //Tablodan bir değer türettik yani Tbl_Dersler parametre(p) olsun dedik
        {
            db.Tbl_Dersler.Add(p); //şimdi burda db yukarda türettiğimiz nesnemiz bu parametreden yani(p) den gelen değeri nerden alıcak YeniDers.chtml kısmında Ders ekle kısmından
            db.SaveChanges(); //C# da ExecuteNonQuery Kısmının karşılığı gibi düşünebilir
            return View();
        }

        public ActionResult Sil(int id)
        {
            var ders = db.Tbl_Dersler.Find(id);
            db.Tbl_Dersler.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DersGetir(int id)
        {
            var ders = db.Tbl_Dersler.Find(id);
            return View("DersGetir",ders);
        }

        public ActionResult Guncelle(Tbl_Dersler p)
        {
            var drs = db.Tbl_Dersler.Find(p.DERSID);
            drs.DERSAD = p.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}