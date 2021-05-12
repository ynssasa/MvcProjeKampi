using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context context = new Context();
        public ActionResult Index()
        {
            //Kategori Sayısı
            var numberOfCategory = context.Categories.Count();
            ViewBag.query1 = numberOfCategory;

            //Yazılım ile ilgili başlık sayısı
            var numberOfSoftwareTitle = context.Headings.Count(x => x.HeadingId == 17);
            ViewBag.query2 = numberOfSoftwareTitle;
           
            //İçinde A harfi geçen yazar sayisi
            var writerNameA = context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.query3 = writerNameA;

            //En fazla başlığa sahip kategori
            var CategoryId = context.Headings.GroupBy(x => x.CategoryId).OrderByDescending(x => x.Count()).Select(x=>x.Key).FirstOrDefault();
            var veryHeadingCategory = context.Categories.Where(x => x.CategoryId == CategoryId).Select(x=>x.CategoryName).FirstOrDefault();
            ViewBag.query4 = veryHeadingCategory;

            //kategorilerde aktif pasif arasındaki farkı bulma
            var statusTrue = context.Categories.Count(x => x.CategoryStatus == true);
            var statusFalse = context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.query5 = statusTrue - statusFalse;

            return View();
        }


    }
}