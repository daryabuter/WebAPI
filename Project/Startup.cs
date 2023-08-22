using Project.Data.Interfaces;
using Project.Data.Repository;
using Project.Data.Services;

namespace Project
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Добавление контекста базы данных
            //services.AddDbContext<AppDBContent>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Регистрация сервиса аутентификации и авторизации
            services.AddSingleton<IAuthenticationService, InMemoryAuthenticationService>();
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Account/Login", ""); // Маршрут на страницу авторизации
            });

            services.AddControllersWithViews();
            services.AddScoped<IAllProducts, ProductRepository>();
            services.AddScoped<IProductCategory, CategoryRepository>();
            services.AddMvc();
        }
        
        /*
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                dbContext.Database.Migrate(); // Применение миграций
                                
                // Вызов операций с базой данных
                
            }
        }*/
    }
}
