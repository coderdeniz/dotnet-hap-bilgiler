









#region lazy-loading

/*
 * Lazy loading, bir nesnenin yalnızca gerçekten ihtiyaç duyulduğunda yüklenmesini sağlar.
 * Bu, uygulamanın başlangıcında tüm verilerin yüklenmesi yerine, sadece gerektiği zaman yüklenmesi anlamına gelir. 
 * Bu durum, uygulamanın başlangıç performansını artırabilir ve gereksiz veritabanı sorgularını önleyebilir.
 * Lazy loading, ilişkisel veritabanlarındaki ilişkili verilere erişimi optimize eder. 
 * Örneğin, bir veritabanı nesnesinin ilişkili nesnelerine erişildiğinde, bu ilişkili nesneler yalnızca gerçekten kullanıldığında yüklenir. 
 * Bu, veritabanı trafiğini ve uygulama bellek kullanımını azaltabilir.
 * Lazy loading, uygulamanın ölçeklendirilebilirliğini artırabilir. 
 * İhtiyaç duyulan verilerin yalnızca kullanıldıkları zaman yüklenmesi, uygulamanın daha fazla talebi karşılamasına ve daha iyi performans göstermesine olanak tanır.
 * 
 * Eager Loading, Lazy'nin tam aksine çalışır. Kullanacağı nesneleri nesneye daha ihtiyaç olmadan çok önce create eder ve bekletir. Eager Loading Linq sorgusu
 * çalıştırıldığında verilerin tamamını yükler ve hafızaya alır. (Ef'de dbContxt.Users.Include(u=>u.Orders))
 * 
 * 
 * Performans Farkları
 * Lazy loading ve Eager loading arasındaki çalışma hızı farkını değerlendirecek olursak, 
 * lazy loadingin tekrar tekrar database’e bağlanması sebebiyle hızı kayıt sayısı arttıkça eager loadingin üzerine çıkıyor.
 * 
 * Örnek durum: Kullanıcı siparişleri için eager, kullanıcı etkileşimiyle bağlantılı olmayan yorumları görüntüleme gibi alanlarda lazy
 * 
 */

Order o = new Order();
Console.WriteLine(o.Product.Name);
o.Product = new Product("deniz");
Console.WriteLine(o.Product.Name);

public class Order
{
    private Lazy<Product> _products = new Lazy<Product>(() => new Product());

    public int OrderId { get; set; }
    public string OrderNumber { get; set; }

    public Product Product { get { return _products.Value; } set { _products = new Lazy<Product>(() => value); } }
}

public class Product
{
    public string ID { get; set; }
    public string Name { get; set; }
    public Product()
    {
        ID = "1";
        Name = "Test";
    }
    public Product(string name)
    {
        ID = "2";
        Name = name;
    }
}
#endregion


