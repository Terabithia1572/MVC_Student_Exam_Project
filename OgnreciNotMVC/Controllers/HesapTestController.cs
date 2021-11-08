using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgnreciNotMVC.Controllers
{
    public class HesapTestController : Controller
    {
        // GET: HesapTest
        public ActionResult Index(int sayi1=0,int sayi2=0)
        {
            int sonuc = sayi1 + sayi2; //sayi 1 ve sayi 2 adlı değişkenleri topla sonuc adlı değişkene aktar sonra
            ViewBag.snc = sonuc; //daha sonra ViewBag(Controller Tarafmızdaki Bilgileri Index Sayfamıza Taşıyorduk) snc rastgele verdik sonuc kısmınıda Viewbag.snc'ye aktardık
            return View();
        }
    }
}