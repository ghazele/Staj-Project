using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary
{
    public static class ItemHelper
    {
        public static string GetResimYokUrl { get { return "/Assets/images/resim_yok.png"; } set { } }
    }
    public static class MessageHelper
    {
        public static string SuccessMessage { get { return "Ok|İşleminiz başarıyla tamamlandı."; } set { } }
        public static string ErrorMessage { get { return "Hata|İşlem sırasında bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.!"; } set { } }
        public static string GirisMessage { get { return "Giriş Hata|lütfen önce giriş yapınız.!"; } set { } }
    }
}
