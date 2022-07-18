Blog App:
EP 1:
Temel olarak ASP.Net Core MVC projesidir.
.Net 5.0 ile geliþtirilecek olan bu proje temellerinde N-Tier Architecture kullanýlacaktýr
Veri tabaný olarak MS-Sql kullanýlacak olup Docker üzerinden ayaða kaldýrýlacaktýr.
Sql server yönetimi için DBeaver kullanýlacaktýr.
ORM(Object Relational Mapping) olarak Entity FrameWork kullanýlacaktýr.
-------------------------------------------------------------------------------
docker pull mcr.microsoft.com/mssql/server:2019-latest
docker run --name sql_server -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=123456Abc' -p 1401:1433 -d mcr.microsoft.com/mssql/server:2019-latest
--------------------------------------------------------------------------------
EP 2:
N-Tier Architecture
	*Entity Layer
		Makale		Kategori		Yorum		Yazar		Hakkýnda		Ýletiþim		Adres
	*Data Acces Layer
	*Business Layer
	*Presentation Layer
	*Core Layer
	*Api
Entity FrameWork için gerekli Paketlerin yüklenmesi
	Microsoft.EntityFramewworkCore
	Microsoft.EntityFramewworkCore.Desing
	Microsoft.EntityFramewworkCore.SqlServer
	Microsoft.EntityFramewworkCore.Tools
-----------------------------------------------------------------------------------
EP 3 :
Connection string AppSettings.json dosyasýna eklenmiþtir.
DbContext sýnýfý oluþturulmuþ ve tanýmlanmýþtýr.
Projede bulunan entitylerin validation iþlemleri FluentValidation ile  gerçekleþtirilmiþtir.
Deneme amaçlý Migration ve reflection yapýlarak baðlantý ve yapýlanlar kontrol edildi.
-----------------------------------------------------------------------------------
EP 4 :
w3layouts üzerinden alýnan hazýr þablon uygulama arayüzü için uygun hale getirildi
Gerekli css, js ve fontlar dahil edildi.
Header ve footer bölünerek partial view haline getirildi
IBlogService ve BlogManager sýnýflarý üzerinden veri tabaný ve arayüz iliþkileri test edildi.
-----------------------------------------------------------------------------------
Ýliþkisel tablolarda çalýþýrken EfCore özelinde listemele yapýlýrken method Include olarak bildirilerek yazýlmalýdýr.
-----------------------------------------------------------------------------------
EP 5:
Listenen Bloglarýn altýnda bulunan yorum kýsýmlarý view component olarak eklenmiþtir.
ayný zamanda category kýsmý da veri tabanýna baðlý þekilde gelmektedir.
veri tabaný ve category kýsmý için ViewComponent yapýsý kullanýlmýþtýr.
ViewComponent yapýsý esasýnda PartialView ile ayný amaca hizmet etmektedir lakin teknik anlamda farklar bulunmaktadýr.
ViewComponent'lar Shared/Components/ComponentAdý(Personeller)/default.cshtml
ViewComponents/PersonellerViewComponents.cs
@await Component.InvokeAsync("Personeller");
https://miro.com/app/board/uXjVOsBeZTE=/?share_link_id=848986511297
-----------------------------------------------------------------------------------
EP 6 :
Kayýt ekranýnýn basit olarak hazýrlanýp ayarlanmasý.
FluentValidasyon ile bazý kontrollerin saðlanmasý gerçekleþmiþtir.
Business/FluentValidation.AspNetCore
UI/FluentValidation & FluentValidation.AspNetCore
---------------------------------------------------------------------------------
EP 6.1:
https://colorlib.com/wp/template/colorlib-error-404-4/ hata sayfasý þablonu
Þablonun projeye dahil edilmesi
---------------------------------------------------------------------------------
EP 7 : Authenticate / Authorize
Proje seviyesinde authorize iþlemi gerektirdiði için hiçbir contoller/view yapýsýna eriþilememektedir.
[AllowAnonymous] attribute'u [Login/Index] sayfasýný bütün sýnýrlama ve kýsýtlamalardan arýndýrmaktadýr.
Session :
Session’ýn kelime anlamý oturumdur.Her hangi bir ziyaretçi sitemize ilk girdiði anda, o ziyaretçiyle ilgili Session baþlatýlmýþ olur.
Ziyaretçimizle ilgili bir bilginin baþka bir sayfada elde edilmesini istiyorsak Sessionlarý kullanabiliriz.
Server taraflý çalýþan Sessionlar, bir sayfada aldýklarý bilgileri diðer sayfada kaybetmezler.Session deðerlerini sayfalar arasýnda taþýmamýza gerek yoktur.
O bilgiler oturum aktif olduðu sürece hafýzada kalýrlar.Sessionlar sunucu üzerinde tutulurlar.
Claim : 
Claimler; rollerin dýþýnda kullanýcý hakkýnda bilgi tutmamýzý ve bu bilgilere göre yetkilendirme yapmamýzý saðlayan yapýlardýr.
Kullanýcýya dair tanýmlanmýþ ekstra bilgiler olan claimleri kullanarak yetkilendirme iþlevini gerçekleþtirebilmek için cookie deðeri kullanýlmaktadýr. 
Sisteme giriþ yapacak olan kullanýcýya özel tanýmlanmýþ claimler oluþturulan Cookie deðerinin içerisine eklenmekte ve lazým olduðu taktirde oradan eriþilmektedir. 
---------------------------------------------------------------------------------
EP 8 : Blog yazýlarýna ait istatistikleri tutmak için BlogRating tablosu oluþturulmuþtur.
Ardýndan Triger yardýmý ile yeni eklenen bloglarýn ID deðerinin Rating tablosuna eklenmesi saðlanmýþtýr.
-------------------------------------------------
CREATE TRIGGER AddBlogIdInRatingTable
ON Blogs AFTER INSERT
AS 
DECLARE @ID INT 
SELECT @ID = Id FROM INSERTED
INSERT INTO BlogRatings (BlogId,BlogTotalScore,BlogRatingCount)
VALUES (@ID,0,0)
-------------------------------------------------
Yorum yapýlmasýnýn ardýndan yorum yapýlan blog'un Rating tablosunda gerekli iþlemler Trigger ile eklenmiþtir.
----------------------------------------------------------
CREATE TRIGGER UpdateBlogRatingCount
ON Comments
AFTER INSERT
AS 
DECLARE @ID INT 
DECLARE @SCORE INT
DECLARE @RATINGCOUNT INT
SELECT @ID = BlogId,@SCORE = BlogScore FROM INSERTED
UPDATE BlogRatings SET BlogTotalScore = BlogTotalScore + @SCORE, BlogRatingCount +=1 
WHERE BlogId = @ID
----------------------------------------------------------
Admin arayüzü eklendi
Area altyapý hazýrlýklarý
Sayfalama(Pagination) iþlemi için XPagedList paketi  kullanýldý.
Excel raporlama iþlemi için ClosedXML paketi dahil edilmiþtir.
-------------------------------------------------------------
https://openweathermap.org/current Dashboard ekranýna hava durumu bilgisinin getirilmesi
https://apilayer.com/marketplace/fixer-api üzerinden dashboard'a güncel kur bilgilerinin getirilmesi 
Her iki Api kullanýmý içinde ücretsiz üye olup kendi apiKey bilginiz ile çalýþtýrabilirsiniz. 
bir takým sayýsal bilginin ekrana eklenmesi saðlanmýþtýr.
---------------------------------------------------------------