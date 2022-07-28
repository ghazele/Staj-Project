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
    public class PartialKategorilerController : Controller
    {
        PageItem item = new PageItem();
        StajProje2Entities db = new StajProje2Entities();
        //===================================kategoriler islemle(Ekleme ve guncellem)======================================================
        [HttpPost]
        public ActionResult GetKategoriForm(FormCollection collection)
        {
            int KategoriID = collection["KategoriID"].ToInt();

            if (KategoriID > 0)
            {
                item.lstKategorilerIslem = db.Proc_Kategoriler_Islem("Liste", KategoriID, "").ToList();
            }
            else
            {
                item.lstKategorilerIslem.Add(new Proc_Kategoriler_Islem_Result { kategoriID = 0 });
            }
            item.lstSelectList = db.Proc_Kategoriler_Islem("Liste", 0, "").Select(x => new SelectListItem { Value = x.kategoriID.ToString(), Text = x.kategoriBaslik }).ToList();

            return View(item);
        }

        //===================================kategoriler Silme======================================================

        public ActionResult GetKategoriSil(int id)
        {
            item.lstKategorilerIslem = db.Proc_Kategoriler_Islem("Liste", id, "").ToList();
            return View(item);
        }


    }
}