using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using Template_Design_Pattern.DAL.Entities;

namespace Template_Design_Pattern.TemplateDesignPattern
{
    public class UserCardTagHelper:TagHelper
    {
        //Sistemin tasarımı olan kullanıcının sisteme giriş yapıp yapmamasına göre göstereceği template sayfaların yönetimini burada yazdık

        private readonly IHttpContextAccessor _httpContextAccessor;    //Bu user işlemlerini getirebilmek için kullanacağım interace'dir
        //Yani view'de tag helper'dan çağırırız.
        //Burada httpContextAccessor giriş yapan kullanıcının bilgilerini tutuyor. 

        public UserCardTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public AppUser AppUser { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            UserCardTemplate userCardTemplate;
            //bu UserCardTemplate'in içi başka şekilde dolacak
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                //eğer bu kullanıcı sisteme authentice olduysa User Card Template Gold'u alacak. Yani Gold'u gösterecek
                userCardTemplate = new GoldUserCardTemplate();
            }
            else
            {
                userCardTemplate = new DefaultUserCardTemplate();
                //eğer kullanıcı sisteme giriş yapmamışsa DdefaultCard'ı
                //olur.

            }
            userCardTemplate.SetUser(AppUser);
            output.Content.SetHtmlContent(userCardTemplate.Build());//veritabanı ile ilgili işlemi yapı içerisine çeker
            //Böylece Build'i çağırarak tüm oluşturduğum metodları kullandım

        }




    }
}
