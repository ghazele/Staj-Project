using BusinessLibrary;
using EntityFrameworkLibrary;
using StajProje2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StajProje2.Controllers
{

    public class PartialUrunController : Controller
    {
        PageItem item = new PageItem();
        StajProje2Entities db = new StajProje2Entities();
        //===================================urunler islemle(Ekleme ve guncellem pop modal)======================================================
        [HttpPost]
        public ActionResult GetUrunForm(FormCollection collection)
        {
            int UrunID = collection["UrunID"].ToInt();

            item.lstKategorilerIslem = db.Proc_Kategoriler_Islem("Liste", 0, "").ToList();

            if (UrunID > 0)
            {
                item.lstUrnlerIslme = db.Proc_Urunler_Islem("Liste", UrunID, 0, "", "", "", "", 0, 0, 0).ToList();
            }
            else
            {
                item.lstUrnlerIslme.Add(new Proc_Urunler_Islem_Result { urunID = 0, kategoriID = 0, urunResimUrl = ItemHelper.GetResimYokUrl });
            }

            return View(item);
        }

        //===================================urunler sil pop modal======================================================
        public ActionResult GetUrunSil(int id)
        {
            item.lstUrnlerIslme = db.Proc_Urunler_Islem("Liste", id, 0, "", "", "", "", 0, 0, 0).ToList();
            return View(item);
        }

    }
}