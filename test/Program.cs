using Microsoft.EntityFrameworkCore;
using test.Data;
using test.IRepository;
using Microsoft.AspNetCore.Identity;

namespace test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            //add connection string--------------------
            builder.Services.AddDbContext<Dbcontext>
                (
                opt=>opt.UseSqlServer(
                    builder.Configuration.GetConnectionString("conn")
                                    )
                );

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Dbcontext>();
            builder.Services.AddTransient(typeof(Repository<>), typeof(ItemRepo<>));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
             
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Items}/{action=Index}/{id?}"
                );

            app.Run();
        }
    }
}
