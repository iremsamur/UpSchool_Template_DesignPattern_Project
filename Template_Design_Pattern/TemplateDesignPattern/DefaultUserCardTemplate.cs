namespace Template_Design_Pattern.TemplateDesignPattern
{
    public class DefaultUserCardTemplate : UserCardTemplate
    {
        //Authentice olmayan kullanıcıların göreceği sayfa için 
        //DefaultUserCardTemplate'i ortak alanları gösterebilmek içi,n
        //UserCardTemplate'den miras alır. Bunun dışında onun içindeki
        //SetFooter() SetImage() metodları ile değişcek olan alanları kendine
        //göre özelleştirir.
        protected override string SetFooter()
        {
            return string.Empty;
        }
        protected override string SetImage()
        {
            //değişen image alanı
            return "<img class='car-img-top' src='/images/user.jpg' style='width:50px;height:50px;'>";
        }
    }
}
