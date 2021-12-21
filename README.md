
## Projenin Amacı
- İki bilgisayar arasında server-client yapısı kurularak soketler aracılığı ile birbirlerine bağlanabilmeleri 
- SHA-256 ve SPN-16 Şifreleme Algoritmaları Kullanılarak  şifreli olarak mesaj gönderebilmeleri ve geri şifreleri çözerek mesaj içeriğine erişebilmeleri.
- Dosya gönderiminin sağlanması, Dosyaların karşı tarafa sıkıştırılmış bir şekilde gönderilmesi ve karşıdaki kullanıcı dosyaya erişebilmesi
- Yukarıda belirtilen isterlerin gerçekleştirilmesi amaçlanmıştır

## Projenin Mimarisi
Uygulama server ve client olmak üzere iki ayrı program olarak değil, Bir uygulama ile hem sunucu hem dinleme işlemi aynı yapı içerisinde kullanarak tek bir çatıda toplanmıştır. Kullanıcılar bir ip ile birbirlerine bağlanarak 80 portu üzerinden hem yayın hem de dinleme işlemini yapabilirler. Aynı bilgisayar üzerinde aynı porttan yayın yapılamaz.

## Projenin Katmanları
Projede 4 adet katman vardır.
- **Library:** proje içerisinde kullandığımız SPN şifreleme algoritması, Ip validasyonu ,Binary  text çevirme sınıflarının tanımlandığı ve geliştirildiği Class Library katmanı
- **ChatApp.UnitTest:** birim testlerimizin yazıldığı class XUnit katmanımız.
- **EasyFileTransfer:** Dosya transferi yapacak olan proje sınıfımız.
-  **ChatApp5.0 :** Windows Form arayüzümüzün bulunduğu arayüz katmanımız.

### Library Katmanı :
-  BinaryToText : Binary verilerimizi ASCII texte dönüştüren sınıfımız. ConvertToAscii: Gelen text içerisindeki Türkçe karakterlerimizi ascii  tablosundaki değerlerle eşleştiren sınıfımız.
-  Ipv4Validator: gelen ip adres formatının ipv4 sınıfına ait olup  olmadığını validate eden sınıfımız.
- SPN : gelen veri ve şifrenin SPN algoritmasıyla şifreleyebilen ve  çözebilen sıfımız. 

### EasyFileTransfer Katmanı :
-  EftServer : Dosya gönderimini yapan sunucu sınıfımız.
- EftClient : Aldığı dosyayı ilgili dizine yazan client sınıfımız. ChatAppV5.0 Katmanı.

###  WinFormUI : 
- Programımızın arayüzünün tasarlandığımız ve çağırıları  gerçekleştirdiğimiz form sınıfımız.  CxFlatUI ve Magic.ModernUI gibi farklı arayüz componentlerini  içeren farklı kütüphanelerden yararlanıldı.
#### Örnek Arayüz görüntüsü

![Untitled](https://user-images.githubusercontent.com/78824631/146924199-15d66201-f54f-4495-ab41-97a0cada1276.png)

### ChatApp.UnitTest Katmanı 
- **SPNDecodeTest** : SPN algoritmamız gelen veriyi çözmesini sağlayan SPN.Decode sınıfımızın birim testi.
- **SPNEncodeTest** : SPN algoritmamızın gelen veriyi şifrelyebilmesini sağlayan SPN.Encode sınıfımızın birim testi.
- **SPNEncodeFailedTest** : SPN algoritmasının çuvalladığını öngördüğümüz istisnai durumlarının yaşanması durumunda programımızın doğru bir şekilde hata fırlatmasını test Ettiğimiz SPN.Encode hata ayıklama birim testi.
- **ConvertCharacterTest** : Girilen Türkçe karakterlerin ascii karakterlere dönüştürülmesi, Metoda giren verilerin Türkçe karakter kontrol testli
- **Ipv4ValidatorTest** : Girilen IP değerleri doğru formatta girilip girilmediğini, doğru formatta girilmediği taktirde ilgili Exceptionları fırlatması gerektiği test

- **Testlerin Konsol Çıktısı**
![image](https://user-images.githubusercontent.com/78824631/146924409-ce67d1ab-29fb-474d-bb4e-48e41751ed65.png)

### Kaynak kod Grafiksel Analizi

![image](https://user-images.githubusercontent.com/78824631/146924344-3e518784-f3e3-4180-8d1a-93e3b15f1ef9.png)
