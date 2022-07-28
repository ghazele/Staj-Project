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
    public class UrunlerController : Controller
    {
        PageItem item = new PageItem();
        StajProje2Entities db = new StajProje2Entities();
        //============================List of urunler==================================
        public ActionResult UrunList()
        {
            item.lstUrnlerIslme = db.Proc_Urunler_Islem("Liste", 0, 0, "", "", "", "", 0, 0, 0).ToList();
            return View(item);
        }


        //==========================islem(add or Edit or delete) of urunler=============================
        [HttpPost]
        public string UrunIslem(FormCollection collection, HttpPostedFileBase fileUrunResim)
        {
            double indremYuzde = 100;
            string result = "";
            try
            {
                int UrunID = collection["UrunID"].ToInt();
                string type = collection["type"].ToString();
                if (type == "Kaydet")
                {
                    int KategoriID = collection["selectKategoriler"].ToInt();
                    int urunEskiFiyat = collection["txtUrunEskiFiyat"].ToInt();
                    int Urunindrem = collection["txtUrunIndrem"].ToInt();
                    indremYuzde = (Urunindrem / indremYuzde);
                    double indrem = (urunEskiFiyat * indremYuzde);
                    double UrunFiyat = urunEskiFiyat - indrem;
                    string UrunKodu = collection["txtUrunKodu"].ToString();
                    string UrunBaslik = collection["txtUrunBaslik"].ToString();
                    string UrunAciklama = collection["txtUrunAciklama"].ToString();
                    string UrunResimUrl = collection["hdnUrunResim"].ToString();

                    UrunResimUrl = fileUrunResim.ToFileUploadKaydet("/Assets/Dosyalar/Urunler/Resim/", UrunResimUrl);
                    string process = "Yeni";
                    if (UrunID > 0)
                        process = "Guncelle";
                    Proc_Urunler_Islem_Result item = db.Proc_Urunler_Islem(process, UrunID, KategoriID, UrunKodu, UrunBaslik, UrunAciklama, UrunResimUrl, urunEskiFiyat, Urunindrem, UrunFiyat).FirstOrDefault();

                }
                else if (type == "Sil")
                {

                    Proc_Urunler_Islem_Result item = db.Proc_Urunler_Islem("Sil", UrunID, 0, "", "", "", "", 0, 0, 0).FirstOrDefault();

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