# Raporlama Servisi
Harici bir api servisinden raporlama yapmak için geliştirilmiş uygulama.

## Gereklilikler
  * PostgreSQL
  * Apache ZooKeeper
  * Apache Kafka

Yapılandırmalar:
Web servislerinin ayarları ContactService.Web ve ReportService.Web projeleri altındaki appsettings.json dosyasında saklanır.





![image](https://user-images.githubusercontent.com/17264859/189953961-48afda3b-3c70-46eb-be53-379e689bf202.png)

Veritabanı yapılandırmasını "appsettings.json" altındaki "ConnectionStrings:Default" altında düzenleyebilirsiniz.
Ek olarak DbMigrator uygulaması veritabanı migration işlemini kolaylaştırmaya yarayan bir CommandLineTool'dur. Bu uygulamayı çalıştırarak migration işlemini hızlıca halledebilirsin. DbMigrator, *.Web uygulamasındaki "appsettings.json"ı kullanmaz, kendine özgü bir dosyası vardır. Aynı değişiklikleri orada da yapmanızı tavsiye ederim.

ContactService tarafında yapıldığı şekilde ReportService'de de veritabanı yapılandırma ayarları ayarlandıktan sonra, bu serviste Kafka kullanacağımız için onun yapılandırma ayarlarını da *.Web altındaki "appsettings.json" dosyasına ekliyoruz. Gerekli yapılandırmalar şu şekilde:

![image](https://user-images.githubusercontent.com/17264859/189965267-20ebbd69-f971-4621-95b8-ee11d9243d6f.png)

  * BootstrapServers: Kafka sunucusunun erişim adresini tanımlar.
  * GroupId: Üzerinde çalışılacak kafka grubunu belirler.
  * TopicName: Kafka veri iletişiminin sağlanacağı konuyu belirler.


## ContactService
ContactService Abp çatısı altında geliştirilip, Abpnin sağladığı temel uygulama şablonunu kullanıldı. Veritabanı yönetim sistemi olarak PostgreSQL, ORM olarak ise EntityFrameworkCore kullanıldı. Api şablonuna erişmek için dahili swagger aktif, kullanılabilir durumda. Servisin ana görevi bir rehber uygulamasına api hizmeti vermektir. Built-in özellikleri haricinde "rehber" özelliğini yerine getirmesi için oluşturulan "Contact" ve "ContactInfo" nesnelerini barındırır.

### Contact nesnesi içerisinde AuditedAggregateRoot dışında aşağıdaki alanları barındırır:
* FirstName: Kişinin ismini barındırır.
* LastName: Kişinin soyismini barındırır.
* Company: Kişinin şirket bilgisini barındırır.
* ContactInfos: Kişiye atanmış iletişim bilgilerini listeli olarak saklar. (Contact 1:N ContactInfo ilişkisine sahiptir.)

### Contact hizmeti temel CRUD işlemleri hariç şu özellikleri barındırır:
![image](https://user-images.githubusercontent.com/17264859/189942177-be8afa7a-8dcb-490c-ae5c-a88fba4825cf.png)

ContactDetails: Id si gönderilen kaydı iletişim bilgileriyle birlikte döner.




![image](https://user-images.githubusercontent.com/17264859/189945770-f465bba9-d820-4c52-a228-ec7d9960cd9d.png)

FilteredList: Sayfalamayı destekleyerek veritabanındaki tüm verileri döner. Ek olarak iletişim bilgisine göre filtreleme yapabilir.
Parametreler:
* ContactType: Filtrelenmek istenen iletişim bilgisini belirleyen parametredir. (Undefined=0 , PhoneNumber=1 , Mail=2 , Location=3)
* Information: ContactType'da belirlenen tipin verisinin saklandığı alandır. Filtrelemek için sadece tip değil bilgi de seçilebilir.
* Sorting: "Pagination" özelliğinin sıralanma özelliğinin parametresidir.
* SkipCount: "Pagination" özelliğinin dönen verilerin başlangıç noktasını belirleyen parametredir.
* MaxResultCount: "Pagination" özelliği ile tek seferde en fazla kaç veri geleceğini belirleyen parametredir.




![image](https://user-images.githubusercontent.com/17264859/189946236-655564b4-164e-4424-870a-420c1fbcc5fe.png)

* ReportData: Konuma göre filtrelenmiş bir şekilde konumu,o konumdaki insan sayısını ve yine o konumdaki kayıtlı telefon numarası sayısını döner.
  Parametreler:
* location : Hedef konumu belirlemek için kullanılan parametre.

### ContactInfo nesnesi içerisinde AggregateRoot dışında aşağıdaki alanları barındırır:
* ContactId: Contact tablosu ile 1:N ilişkiyi oluşturabilmek için bağlı olduğu "Contact" elemanının Id'sinin saklandığı alandır.
* Information: İletişim bilgisinin saklandığı alandır.
* ContactType: Saklanan iletişim bilgisinin tipini belirleyen alandır. (Undefined=0 , PhoneNumber=1 , Mail=2 , Location=3)

## ReportService
ReportService Abp çatısı altında geliştirilip, Abpnin sağladığı temel uygulama şablonunu kullanıldı. Veritabanı yönetim sistemi olarak PostgreSQL, ORM olarak ise EntityFrameworkCore kullanıldı. Api şablonuna erişmek için dahili swagger aktif, kullanılabilir durumda. Servisin ana görevi gelen istek doğrultusunda uzak api sunucusuna erişip Excel dosyası olarak raporlamaktır. Built-in özellikleri haricinde  ExportToExcelService ve ContactReportBackgroundWorker servisleri vardır.

### ExportToExcel
Girdi olarak verilen nesneyi Excel olarak çıktı verir.
### ContactReportBackgroundWorker
Rapor isteği yapıldıktan sonra raporun hazırlanıp excel haline getirmekten sorumlu servis.

### Report nesnesi içerisinde AuditedAggregateRoot dışında aşağıdaki alanları barındırır:
* ReportState: Raporun durumu hakkında bilgi saklar. (Preparing=0,Completed=1)
* ReportURL: Rapor sonucu elde edilen excelin indirilebileceği linki saklar.

### Report hizmeti temel CRUD işlemleri hariç şu özellikleri barındırır:
![image](https://user-images.githubusercontent.com/17264859/189976316-7724d227-5067-4325-b3c1-39b6b3b1e492.png)

  location: Raporlamanın yapılacağı konum bilgisini alır.

