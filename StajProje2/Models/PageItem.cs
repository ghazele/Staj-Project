using EntityFrameworkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StajProje2.Models
{
    public class PageItem
    {
        public List<Proc_Urunler_Islem_Result> lstUrnlerIslme = new List<Proc_Urunler_Islem_Result>();
        public List<Proc_Kategoriler_Islem_Result> lstKategorilerIslem = new List<Proc_Kategoriler_Islem_Result>();
        public List<SelectListItem> lstSelectList = new List<SelectListItem>();


    }


}