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
    public class kategorilerController : Controller
    {
        PageItem item = new PageItem();
        StajProje2Entities db = new StajProje2Entities();
        //==========================List of kategoriler==================================
        public ActionResult kategoriList()
        {
            item.lstKategorilerIslem = db.Proc_Kategoriler_Islem("Liste", 0, "").ToList();
            return View(item);
        }





        //==========================Islem (Ekle/ Silme/ Guncelenme) kategoriler==================================
        [HttpPost]
        public string KategoriIslem(FormCollection collection)
        {
            string result = "";
            try
            {
                int KategoriID = collection["KategoriID"].ToInt();
                string type = collection["type"].ToString();
                if (type == "Kaydet")
                {

                    string KategoriBaslik = collection["txtKategoriBaslik"].ToString();
                    string process = "Yeni";
                    if (KategoriID > 0)
                        process = "Guncelle";

                    Proc_Kategoriler_Islem_Result item = db.Proc_Kategoriler_Islem(process, KategoriID, KategoriBaslik).FirstOrDefault();

                }
                else if (type == "Sil")
                {

                    Proc_Kategoriler_Islem_Result item = db.Proc_Kategoriler_Islem("Sil", KategoriID, "").FirstOrDefault();

                }
                result = MessageHelper.SuccessMessage;
            }
            catch (Exception)
            {
                result = MessageHelper.ErrorMessage;
            }
            return result;
        }

    }
}