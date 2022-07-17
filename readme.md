Blog App:
EP 1:
Temel olarak ASP.Net Core MVC projesidir.
.Net 5.0 ile geli�tirilecek olan bu proje temellerinde N-Tier Architecture kullan�lacakt�r
Veri taban� olarak MS-Sql kullan�lacak olup Docker �zerinden aya�a kald�r�lacakt�r.
Sql server y�netimi i�in DBeaver kullan�lacakt�r.
ORM(Object Relational Mapping) olarak Entity FrameWork kullan�lacakt�r.
-------------------------------------------------------------------------------
docker pull mcr.microsoft.com/mssql/server:2019-latest
docker run --name sql_server -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=123456Abc' -p 1401:1433 -d mcr.microsoft.com/mssql/server:2019-latest
--------------------------------------------------------------------------------
EP 2:
N-Tier Architecture
	*Entity Layer
		Makale		Kategori		Yorum		Yazar		Hakk�nda		�leti�im		Adres
	*Data Acces Layer
	*Business Layer
	*Presentation Layer
	*Core Layer
	*Api
Entity FrameWork i�in gerekli Paketlerin y�klenmesi
	Microsoft.EntityFramewworkCore
	Microsoft.EntityFramewworkCore.Desing
	Microsoft.EntityFramewworkCore.SqlServer
	Microsoft.EntityFramewworkCore.Tools
-----------------------------------------------------------------------------------
EP 3 :
Connection string AppSettings.json dosyas�na eklenmi�tir.
DbContext s�n�f� olu�turulmu� ve tan�mlanm��t�r.
Projede bulunan entitylerin validation i�lemleri FluentValidation ile  ger�ekle�tirilmi�tir.
Deneme ama�l� Migration ve reflection yap�larak ba�lant� ve yap�lanlar kontrol edildi.
-----------------------------------------------------------------------------------
EP 4 :
w3layouts �zerinden al�nan haz�r �ablon uygulama aray�z� i�in uygun hale getirildi
Gerekli css, js ve fontlar dahil edildi.
Header ve footer b�l�nerek partial view haline getirildi
IBlogService ve BlogManager s�n�flar� �zerinden veri taban� ve aray�z ili�kileri test edildi.
-----------------------------------------------------------------------------------
�li�kisel tablolarda �al���rken EfCore �zelinde listemele yap�l�rken method Include olarak bildirilerek yaz�lmal�d�r.
-----------------------------------------------------------------------------------
EP 5:
Listenen Bloglar�n alt�nda bulunan yorum k�s�mlar� view component olarak eklenmi�tir.
ayn� zamanda category k�sm� da veri taban�na ba�l� �ekilde gelmektedir.
veri taban� ve category k�sm� i�in ViewComponent yap�s� kullan�lm��t�r.
ViewComponent yap�s� esas�nda PartialView ile ayn� amaca hizmet etmektedir lakin teknik anlamda farklar bulunmaktad�r.
ViewComponent'lar Shared/Components/ComponentAd�(Personeller)/default.cshtml
ViewComponents/PersonellerViewComponents.cs
@await Component.InvokeAsync("Personeller");
https://miro.com/app/board/uXjVOsBeZTE=/?share_link_id=848986511297
-----------------------------------------------------------------------------------
EP 6 :
Kay�t ekran�n�n basit olarak haz�rlan�p ayarlanmas�.
FluentValidasyon ile baz� kontrollerin sa�lanmas� ger�ekle�mi�tir.
Business/FluentValidation.AspNetCore
UI/FluentValidation & FluentValidation.AspNetCore
---------------------------------------------------------------------------------
EP 6.1:
https://colorlib.com/wp/template/colorlib-error-404-4/ hata sayfas� �ablonu
�ablonun projeye dahil edilmesi
---------------------------------------------------------------------------------
EP 7 : Authenticate / Authorize
Proje seviyesinde authorize i�lemi gerektirdi�i i�in hi�bir contoller/view yap�s�na eri�ilememektedir.
[AllowAnonymous] attribute'u [Login/Index] sayfas�n� b�t�n s�n�rlama ve k�s�tlamalardan ar�nd�rmaktad�r.
Session :
Session��n kelime anlam� oturumdur.Her hangi bir ziyaret�i sitemize ilk girdi�i anda, o ziyaret�iyle ilgili Session ba�lat�lm�� olur.
Ziyaret�imizle ilgili bir bilginin ba�ka bir sayfada elde edilmesini istiyorsak Sessionlar� kullanabiliriz.
Server tarafl� �al��an Sessionlar, bir sayfada ald�klar� bilgileri di�er sayfada kaybetmezler.Session de�erlerini sayfalar aras�nda ta��mam�za gerek yoktur.
O bilgiler oturum aktif oldu�u s�rece haf�zada kal�rlar.Sessionlar sunucu �zerinde tutulurlar.
Claim : 
Claimler; rollerin d���nda kullan�c� hakk�nda bilgi tutmam�z� ve bu bilgilere g�re yetkilendirme yapmam�z� sa�layan yap�lard�r.
Kullan�c�ya dair tan�mlanm�� ekstra bilgiler olan claimleri kullanarak yetkilendirme i�levini ger�ekle�tirebilmek i�in cookie de�eri kullan�lmaktad�r. 
Sisteme giri� yapacak olan kullan�c�ya �zel tan�mlanm�� claimler olu�turulan Cookie de�erinin i�erisine eklenmekte ve laz�m oldu�u taktirde oradan eri�ilmektedir. 
---------------------------------------------------------------------------------
EP 8 : Blog yaz�lar�na ait istatistikleri tutmak i�in BlogRating tablosu olu�turulmu�tur.
Ard�ndan Triger yard�m� ile yeni eklenen bloglar�n ID de�erinin Rating tablosuna eklenmesi sa�lanm��t�r.
-------------------------------------------------
CREATE TRIGGER AddBlogIdInRatingTable
ON Blogs AFTER INSERT
AS 
DECLARE @ID INT 
SELECT @ID = Id FROM INSERTED
INSERT INTO BlogRatings (BlogId,BlogTotalScore,BlogRatingCount)
VALUES (@ID,0,0)
-------------------------------------------------
Yorum yap�lmas�n�n ard�ndan yorum yap�lan blog'un Rating tablosunda gerekli i�lemler Trigger ile eklenmi�tir.
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
Admin aray�z� eklendi
Area altyap� haz�rl�klar�
Sayfalama(Pagination) i�lemi i�in XPagedList paketi  kullan�ld�.
Excel raporlama i�lemi i�in ClosedXML paketi dahil edilmi�tir.
