using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Data.Interfaces;
using Project.Data.Mocks;
using Project.Data.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //���������� �������� � ���������
        builder.Services.AddControllersWithViews();

        //��������� ��������� ������������(������ �������� � DI)
        builder.Services.AddScoped<IAllProducts, MockAllProducts>();
        builder.Services.AddScoped<IProductCategory, MockCategory>();
        builder.Services.AddScoped<IAuthenticationService, InMemoryAuthenticationService>();

        var app = builder.Build();

        // ������������ DbContext
        using (var scope = app.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;

            try
            {
                var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<AppDBContent>>();

                using (var dbContext = new AppDBContent(dbContextOptions))
                {
                    dbContext.Database.Migrate(); // ���������� ��������

                    //dbContext ����� � �������������
                    //����� �������� � ����� ������
                }
            }
            catch (Exception ex)
            {
                //��������� ����������
                Console.WriteLine($"An error occurred: {ex.Message}");
                
            }
        }

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
