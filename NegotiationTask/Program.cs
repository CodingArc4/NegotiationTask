using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NegotiationTask.CustomFormatters;
using NegotiationTask.Data;

namespace NegotiationTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddControllers(opt =>
            {
                opt.RespectBrowserAcceptHeader = true;
                opt.ReturnHttpNotAcceptable = true;

                opt.OutputFormatters.Insert(0, new HtmlFormater());
                opt.OutputFormatters.Insert(0, new PlainFormater());

            }).AddXmlDataContractSerializerFormatters();


            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}