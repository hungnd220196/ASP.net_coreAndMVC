namespace ASP.net_coreAndMVC
{
    public class Lythuyet
    {
        /*
        Dependency Injection:
        - Là một design pattern khi một đối tượng không được tạo trong các thành phần phụ thuộc vào nó mà yêu cầu nó
            Vai trò: Cung cấp một cách quản lý các đối tượng và phụ thuộc của chúng, giúp giảm sự phụ thuộc chặt chẽ giữa các lớp.
            Thành phần:
            Service Registration: Đăng ký các dịch vụ trong Startup.cs.
            Service Injection: Tiêm các dịch vụ vào các Controller, Middleware, hoặc các thành phần khác.


        - TÌm hiểu service

       Trong ASP.NET Core, "Service" là một thành phần quan trọng trong kiến trúc của ứng dụng, được sử dụng để triển khai các logic nghiệp vụ, xử lý dữ liệu và thực hiện các nhiệm vụ mà không liên quan trực tiếp đến giao diện người dùng. Dịch vụ trong ASP.NET Core thường được quản lý bởi một cơ chế gọi là Dependency Injection (DI), giúp giảm thiểu sự phụ thuộc giữa các thành phần của ứng dụng và làm cho mã dễ dàng bảo trì, kiểm thử và mở rộng.

        1. Các loại Service trong ASP.NET Core
        Trong ASP.NET Core, có ba loại dịch vụ chính mà bạn có thể đăng ký vào hệ thống DI:

        Transient: Dịch vụ được tạo mới mỗi khi nó được yêu cầu. Loại này phù hợp với các dịch vụ không lưu trữ trạng thái và yêu cầu thực hiện nhanh chóng.

        csharp
        Sao chép mã
        services.AddTransient<IMyService, MyService>();
        Scoped: Dịch vụ được tạo mới cho mỗi yêu cầu HTTP. Dịch vụ này sẽ được dùng chung trong suốt thời gian của một request, nhưng sẽ được tạo mới cho mỗi request khác nhau.

        
        services.AddScoped<IMyService, MyService>();
        Singleton: Dịch vụ được tạo mới lần đầu tiên khi nó được yêu cầu và sẽ được dùng lại cho tất cả các yêu cầu sau đó trong suốt vòng đời của ứng dụng.

        services.AddSingleton<IMyService, MyService>();
        2. Sử dụng Service trong ASP.NET Core
        Để sử dụng dịch vụ trong ASP.NET Core, bạn cần thực hiện các bước sau:

        Bước 1: Tạo Interface và Class triển khai
        Đầu tiên, bạn tạo một interface để định nghĩa các phương thức của dịch vụ và một class để triển khai chúng.

        public interface IMyService
        {
            string GetGreeting();
        }

        public class MyService : IMyService
        {
            public string GetGreeting()
            {
                return "Hello, ASP.NET Core!";
            }
        }
        Bước 2: Đăng ký Service trong Startup.cs
        Tiếp theo, bạn đăng ký dịch vụ vào container DI trong phương thức ConfigureServices của Startup.cs.

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMyService, MyService>();
            services.AddControllersWithViews();
        }
        Bước 3: Sử dụng Service trong Controller
        Cuối cùng, bạn có thể sử dụng dịch vụ bằng cách inject nó vào trong một controller.


        public class HomeController : Controller
        {
            private readonly IMyService _myService;

            public HomeController(IMyService myService)
            {
                _myService = myService;
            }

            public IActionResult Index()
            {
                var greeting = _myService.GetGreeting();
                return Content(greeting);
            }
        }


        3. Các dịch vụ mặc định của ASP.NET Core

        ASP.NET Core cung cấp nhiều dịch vụ mặc định mà bạn có thể sử dụng, như ILogger, IConfiguration, IOptions, IHttpContextAccessor, v.v. Bạn có thể inject những dịch vụ này vào controller hoặc các lớp khác trong ứng dụng.

        4. Lợi ích của việc sử dụng Service trong ASP.NET Core

        Tăng tính module hóa và khả năng tái sử dụng: Dịch vụ giúp phân chia ứng dụng thành các phần nhỏ hơn, dễ bảo trì và tái sử dụng.
        Hỗ trợ kiểm thử dễ dàng: Bằng cách inject dịch vụ vào các thành phần khác, bạn có thể dễ dàng tạo mock cho dịch vụ và kiểm thử từng phần riêng biệt của ứng dụng.
        Quản lý vòng đời của đối tượng: ASP.NET Core quản lý vòng đời của dịch vụ giúp tối ưu hóa tài nguyên và hiệu suất của ứng dụng.



        - Tìm hiểu các thành phần trong ASP>NET core MVC

        * Trong ASP.NET Core MVC, các thành phần chính bao gồm:

           - Controllers: Thư mục này chứa các Controller, là nơi chứa các logic xử lý yêu cầu HTTP. Mỗi Controller sẽ trả về một View hoặc một dữ liệu (JSON, XML, etc.) tùy thuộc vào yêu cầu của người dùng.

           - Models: Thư mục này chứa các lớp mô hình (Model), đại diện cho dữ liệu ứng dụng. Các lớp trong thư mục này thường được sử dụng để tương tác với cơ sở dữ liệu và thực hiện các logic nghiệp vụ.

           - Views: Thư mục này chứa các tệp giao diện người dùng (UI) được hiển thị cho người dùng. Các View thường được viết bằng Razor (.cshtml) và kết hợp với dữ liệu từ các Model để tạo ra giao diện động.

           - wwwroot: Thư mục này chứa các tài nguyên tĩnh như CSS, JavaScript, hình ảnh, v.v. Đây là nơi chứa tất cả các tài nguyên mà trình duyệt có thể truy cập trực tiếp.

           - appsettings.json: Tệp cấu hình chứa các thiết lập cấu hình cho ứng dụng, bao gồm các thông tin như chuỗi kết nối cơ sở dữ liệu, cấu hình dịch vụ bên ngoài, và các thiết lập khác.

           - Program.cs: Tệp này là điểm bắt đầu của ứng dụng, nơi cấu hình máy chủ web và các dịch vụ ứng dụng.

            Ngoài ra còn có một số thư mục và tệp khác như:

           - Connected Services: Nơi bạn có thể thêm và quản lý các dịch vụ bên ngoài mà ứng dụng của bạn kết nối đến.

           - Properties: Thư mục này chứa thông tin cấu hình dự án, như tệp launchSettings.json dùng để cấu hình cách ứng dụng được khởi động khi chạy thử.


        - Tìm hiểu middleware

        Middleware trong ASP.NET Core là các thành phần phần mềm được sử dụng để xử lý các yêu cầu HTTP và đáp ứng trong pipeline của ứng dụng. 
        Pipeline là một chuỗi các middleware mà yêu cầu HTTP sẽ đi qua khi được gửi đến ứng dụng và phản hồi sẽ đi qua khi được trả về từ ứng dụng. 
        Mỗi middleware có thể thực hiện các hành động như xử lý yêu cầu, sửa đổi yêu cầu hoặc phản hồi, hoặc chuyển yêu cầu đến middleware tiếp theo.

        + Đặc điểm của Middleware:

        Thứ tự thực thi: Middleware trong ASP.NET Core được thực thi theo thứ tự mà chúng được đăng ký trong Startup.cs. Thứ tự này rất quan trọng vì middleware có thể ảnh hưởng lẫn nhau.

        Gọi middleware tiếp theo: Một middleware có thể chuyển yêu cầu sang middleware tiếp theo trong pipeline bằng cách gọi next() hoặc kết thúc xử lý yêu cầu mà không cần chuyển tiếp.

        Sử dụng delegate: Middleware thường được viết bằng cách sử dụng delegate RequestDelegate, cho phép linh hoạt trong việc xử lý yêu cầu.

        + Các loại Middleware thông dụng:

        Authentication Middleware: Xác thực người dùng.
        Authorization Middleware: Kiểm tra quyền truy cập của người dùng.
        Exception Handling Middleware: Xử lý các ngoại lệ toàn cầu cho ứng dụng.
        Routing Middleware: Điều hướng yêu cầu đến các endpoint tương ứng.

        - tìm hiểu repository pattern

        + Repository pattern là một mẫu thiết kế phần mềm phổ biến được sử dụng để tách biệt logic truy cập dữ liệu khỏi logic nghiệp vụ trong các ứng dụng. Trong ASP.NET Core, Repository pattern giúp quản lý và truy vấn dữ liệu từ cơ sở dữ liệu một cách dễ dàng và có tổ chức hơn, bằng cách trừu tượng hóa lớp truy cập dữ liệu.

        + Lợi ích của Repository Pattern:

            Tách biệt giữa logic nghiệp vụ và logic truy cập dữ liệu: Giúp mã nguồn dễ bảo trì, dễ kiểm thử và có thể thay đổi dễ dàng mà không ảnh hưởng đến các thành phần khác.
            Tái sử dụng mã nguồn: Các phương thức truy cập dữ liệu được tái sử dụng nhiều nơi trong ứng dụng.
            Độc lập với loại cơ sở dữ liệu: Bạn có thể dễ dàng thay đổi cơ sở dữ liệu hoặc ORM (Object-Relational Mapping) mà không cần thay đổi logic nghiệp vụ.
        
        + Cấu trúc của Repository Pattern:
            Repository pattern thường bao gồm các thành phần sau:

            Interface (IRepository): Định nghĩa các phương thức truy cập dữ liệu chung như GetAll, GetById, Add, Update, Delete.
            Repository Implementation: Hiện thực các phương thức của IRepository để truy cập dữ liệu từ cơ sở dữ liệu.


        
        Entity Framework Core (EF Core) là một Object-Relational Mapper (ORM) hiện đại cho .NET. Nó giúp các nhà phát triển làm việc với cơ sở dữ liệu bằng cách sử dụng các đối tượng .NET mà không cần phải viết mã SQL thuần. EF Core là phiên bản mới nhất của Entity Framework, được thiết kế lại từ nền tảng để hỗ trợ tốt hơn cho các ứng dụng hiện đại và đa nền tảng.

        Các tính năng chính của Entity Framework Core:
        Cross-platform: EF Core có thể chạy trên nhiều nền tảng khác nhau như Windows, macOS, và Linux.

        Lightweight and Modular: EF Core được thiết kế nhẹ nhàng và modular, nghĩa là bạn chỉ cần cài đặt những phần mà bạn thực sự cần cho ứng dụng của mình.

        Support for multiple databases: EF Core hỗ trợ nhiều loại cơ sở dữ liệu khác nhau, như SQL Server, SQLite, MySQL, PostgreSQL, và cả các cơ sở dữ liệu NoSQL như Cosmos DB.

        Code First & Database First: EF Core hỗ trợ cả hai cách tiếp cận trong việc phát triển ứng dụng:

        Code First: Bạn bắt đầu từ việc viết các lớp C# và EF Core sẽ tự động tạo ra cơ sở dữ liệu dựa trên các lớp đó.
        Database First: Bạn có một cơ sở dữ liệu hiện có và sử dụng EF Core để tạo ra các lớp C# từ cơ sở dữ liệu này.
        LINQ (Language Integrated Query): EF Core hỗ trợ LINQ, cho phép bạn viết các truy vấn mạnh mẽ bằng C# thay vì phải sử dụng SQL trực tiếp.

        Migrations: Tính năng này cho phép bạn cập nhật mô hình dữ liệu của mình và áp dụng những thay đổi đó vào cơ sở dữ liệu mà không mất dữ liệu hiện có.

        Tracking & No-Tracking Queries: EF Core cho phép bạn kiểm soát việc theo dõi các thực thể (entities) để quản lý hiệu quả bộ nhớ và hiệu suất.

         */
    }
}
