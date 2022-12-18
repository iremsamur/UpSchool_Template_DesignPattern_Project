using System.Text;
using Template_Design_Pattern.DAL.Entities;

namespace Template_Design_Pattern.TemplateDesignPattern
{
    public abstract class UserCardTemplate
    {
        //Ana template'in içini burada şekillendiriyoruz.
        //Abstract class metodun içini doldurmamızı sağlıyor.
        //Bu yüzden interface değilde abstract class kullandık
        protected AppUser AppUser { get; set; }
        protected abstract string SetImage();
        protected abstract string SetFooter();

        public void SetUser(AppUser appUser)
        {
            AppUser = appUser;//kullanıcıyı karşılaşayabilmesi için kullanıyoruz
        }

        //build ile html'den gelen ifadeleri string birleştiririz
        public string Build()
        {
            //Build içinde tüm bu sınıftan miras alacak alt kartlarında
            //aynı şekilde göreceği alanları html string olarak yazıyorum. Mesela kullanıcı bilgileri alanı gibi ya da
            //yapının card çerçevesii gibi
            //Ama mesela butonlar  veya yetkiye göre karta göre
            //değişen image için metod olarak tanımlayarak yazıyorum

            var sb = new StringBuilder();
            sb.Append("<div class='card'>");//User card template'deki
            //çerçeveyi oluşturacak html kodunu yazdım.
            //"" içinde '' ile cardı yazdım
            sb.Append(SetImage());//Burada SetImage değeri
                                  //kullanıcıdan kullanıcıya göre farklılık göstereceği için metod olarak SetImage'ı verdim. Çünkü sisteme giriş yapmayan image'ı farklı görecek authentice olan daha farklı görecek
                                  //Burada $ kullanımı string için {} ile değişken yazmamızı
                                  //sağlıyor. @ sembolü kodu alt satıra geçirerek yazmayı sağlıyor.

            sb.Append($@"<div class='card-body'>
                            <h5>{AppUser.UserName}</h5>
                            <p>{AppUser.Description}</p>");//Burada kullanıcı bilgileri alanını getirdim. 
            sb.Append(SetFooter());
            sb.Append("</div>");
            sb.Append("</div>");
            return sb.ToString();
            //Mesela bazı web sitelerinde yazının devamını okumak için giriş yapın diyor. Ya da netflixde mesela herkes filmi izliyor. aldığı paket özelliğine göre premium vb.
            //farklı özellikleri kullanarak izliyor.


            //Bu template aslında ortak bir ana sınıf iskelet yapı kuruluyor. Bu alt sınıflara miras verilerek alt sınıflar hem buradan ortak özellikleri kendileirne direk alıyor. Aynı zamanda set Metodları ile kendilerine göre o iskelette bulunan alanları küçük farklılıklar ile kendine göre özelleştirebiliyor.
        }


    }
}
