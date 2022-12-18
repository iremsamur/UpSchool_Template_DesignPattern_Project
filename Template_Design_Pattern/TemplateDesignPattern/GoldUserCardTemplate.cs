using System.Text;

namespace Template_Design_Pattern.TemplateDesignPattern
{
    //Gold üyelerin görebileceği değişen sayfa için authenicate olan kullanıcılar görebilecek.
    public class GoldUserCardTemplate : UserCardTemplate
    {
        protected override string SetFooter()
        {
            //Authenicate olan kullanıcılarda aşağıda butonlar açılacaktı
            //onların html kodunu yazıp string builder ile birleştiriyoruz
            var sb = new StringBuilder();
            sb.Append("<a href='#' class='card-link'>Profili Gör</a>");
            sb.Append("<a href='#' class='card-link'>Mesaj Gönder</a>");
            return sb.ToString();
        }

        protected override string SetImage()
        {
            //değişen image alanı
            //Bu defa authentica kullanıcının resmi geleceği için 
            //AppUser.Image'den gelecek. AppUser'ı zaten UserCardTemplate içerdiği için bu sınıfı oradan miras alması ile kullanabiliyoruz
            return $"<img class='car-img-top' src='{AppUser.Image}' style='width:50px;height:50px;'>";
        }
    }
}
