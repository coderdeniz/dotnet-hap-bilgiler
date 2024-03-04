using System.Threading;





#region asynchronous-programming

//await MethodA();

//async Task MethodA()
//{

//    await Task.WhenAll(
//         Task.Run(() =>
//         {
//             for (long i = 0; i < 5; i++)
//             {
//                 Console.WriteLine(i);
//                 Thread.Sleep(1000);
//             }
//             Console.WriteLine("bitti");
//         }),
//        Task.Run(() =>
//        {
//            Thread.Sleep(1000);
//            Console.WriteLine("bitti-2");
//        })
//        );   
//}
 
#endregion

#region Threads

/*
 * Thread(iş parçacığı) kendi program ve memory alanına sahip temel bir CPU kullanım birimidir.
 * Bir zamanlayıcı tarafından bağımsız bir şekilde yönetilebilen talimatların en küçük bölümüdür. 
 * Thread’ler .NET’ e ait bir yapı değildir, OS’daki iş parçacıklarıdır. 
 * .NET’in Thread sınıfı aslında threadleri oluşturabilmenin ve yönetmenin bir yoludur. .
 * Task yapılması gereken görevleri temsil eden bir nesnedir. Bir işi paralel olarak yürütmek istediğimizde bu yapıyı kullanırız. 
 * Async ve await anahtar kelimelerini kullanarak asenkron(eş zamanlı çalışan) uygulamalar gerçekleştirebiliriz. 
 * Net’de System.Threading.Tasks isim alanı altında Task yapısına ulaşabiliriz
 * Task yapısında bir işin tamamlanıp tamamlanmadığını öğrenebilir ve bu işlem bir sonuç döndürüyorsa bu sonuca ulaşabiliriz.
 * Değer döndüren işlemler için Task <TResult> sınıfını kullanmamız gerekmektedir.
 * 
 * 
 */


//object lockObj = new object();

//Thread thread_1 = new Thread(new ThreadStart(AMethod));
//Thread thread_2 = new Thread(new ThreadStart(AMethod));
//thread_1.Start();
//thread_2.Start();
//thread_1.Join();
//thread_2.Join();

//void AMethod()
//{
//    for (int i = 0; i < 10000; i++)
//    {
//        lock (lockObj)
//        {
//            Console.WriteLine(i);
//        }
//        Thread.Sleep(1000);
//    }
//}



//Thread t1 = new Thread(() =>
//{
//    CustomThreadClass c = CustomThreadClass.Instance;

//    Thread.Sleep(1000);

//    CustomThreadClass c2 = CustomThreadClass.Instance;


//    Console.WriteLine($"Thread 1: {ReferenceEquals(c, c2)}");
//});

//Thread t2 = new Thread(() =>
//{
//    CustomThreadClass c = CustomThreadClass.Instance;

//    Thread.Sleep(1000);

//    CustomThreadClass c2 = CustomThreadClass.Instance;

//    Console.WriteLine($"Thread 1: {ReferenceEquals(c, c2)}");
//});

//t1.Start();
//t2.Start();

//t1.Join();
//t2.Join();

class CustomThreadClass
{
    private int _count = 100;
    private static CustomThreadClass _obj;

    private CustomThreadClass()
    {
        
    }

    public static CustomThreadClass Instance
    {
        get
        {
            if (_obj == null)
            {
                _obj = new CustomThreadClass();
            }
            return _obj;
        }
    }

    public void Decryment()
    {
        for (int i = 0; i < 5; i++)
        {
            _count--;
        }
    }

    public void Show()
    {
        Console.WriteLine(_count);
    }

}


#endregion

#region singleton-design-pattern

/*
 * Singleton tasarım deseni, bir sınıfın tek bir örneğini oluşturup, bu örneğe global bir erişim noktası sağlamayı amaçlar.
 * AddSingleton'dan farkı DI bağımlı değil, istediğin zaman manuel olarak dispose edebilirsin. 
 * 
 * lock keyword'ü = anahtar kelimesi, eşzamanlı programlamada senkronizasyonu sağlamak için kullanılan bir yapıdır.
 * Birden çok iş parçacığının aynı anda aynı kaynağa (örneğin, bir değişken veya nesne) erişmesini önler.
 * Bu, bir iş parçacığının belirli bir kaynağı kullanırken diğer iş parçacıklarının o kaynağa erişimini engeller.
 * lock anahtar kelimesi bir nesne üzerinde kilitleme işlemi yapar.
 * Bu nesne, belirli bir kaynağa erişimi kontrol etmek için kullanılır.
 * Sıklıkla, bir iş parçacığı güvenli bir şekilde bir kaynağa erişirken, diğer iş parçacıklarının beklemesini sağlamak için kullanılır.
 * lockObject isimli nesne, CustomSingleton sınıfındaki Instance ve DisposeInstance metodları arasında eşzamanlı erişimi kontrol etmek için kullanılır.
 * Eğer bir iş parçacığı Instance metodunu çağırıyorsa, diğer iş parçacıkları aynı anda DisposeInstance metodunu çağıramaz. 
 * Bu, aynı anda birden fazla iş parçacığının lock bloğuna girmesini engeller ve eşzamanlılık sorunlarını önler.
*/

//CustomSingleton customSingleton = CustomSingleton.Instance;

//Thread thread_1 = new Thread(new ThreadStart(customSingleton.A));
//Thread thread_2 = new Thread(new ThreadStart(customSingleton.A));

//thread_1.Start();
//thread_2.Start();

//thread_1.Join();
//thread_2.Join();

public class CustomSingleton
{
    private static CustomSingleton _instance;

    private static readonly object lockObject = new object();

    private CustomSingleton()
    {
        Console.WriteLine("CustomSingleton Örneği oluşturuldu");
    }

    public void A()
    {
        Console.WriteLine("Test");
    }

    public static CustomSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new CustomSingleton();
                    }
                }
            }
            return _instance;
        }
    }

    public static void DisposeInstance()
    {
        if (_instance != null)
        {
            lock (lockObject)
            {
                if (_instance != null)
                {
                    _instance = null;
                    Console.WriteLine("Custom Singleton Örneği Kaldırıldı");
                }
            }
        }
    }
}

#endregion

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

//Order o = new Order();
//Console.WriteLine(o.Product.Name);
//o.Product = new Product("deniz");
//Console.WriteLine(o.Product.Name);

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