using AgcTelefonicaPH.Data;
using AgcTelefonicaPH.Repositorio;
using Microsoft.EntityFrameworkCore;
//para o Websockets
using AgcTelefonicaPH.Hubs;

namespace AgcTelefonicaPH
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
            builder.Services.AddScoped<IContactoRepositorio, ContactoRepositorio>();
            builder.Services.AddScoped<IObraRepositorio, ObraRepositorio>();
            //SignalR
            builder.Services.AddSignalR();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapHub<ChatHub>("/chatHub");

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
