using Microsoft.EntityFrameworkCore;
using SWP_template.Models;
using SWP_template.Service;

partial class Program
{
    IConfiguration _configuration;
    public Program(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void ConfigureService(IServiceCollection services)
    {
        services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();
        services.AddOptions();
        var mailSettings = _configuration.GetSection("MailSettings");
        services.Configure<MailSettings>(mailSettings);
        services.AddTransient<SendMailServices>();
    }
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDistributedMemoryCache();           // Đăng ký dịch vụ lưu cache trong bộ nhớ (Session sẽ sử dụng nó)
        builder.Services.AddSession(options =>
        {
            options.Cookie.Name = "SWP";
            options.IdleTimeout = TimeSpan.FromMinutes(30);//We set Time here 
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });
        
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddDbContextPool<Swp1Context>(config =>
        {
            config.UseSqlServer(builder.Configuration.GetConnectionString("ArticleContext"));
        });
        var app = builder.Build();
        // builder.Services.AddDistributedMemoryCache();
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        else app.UseDeveloperExceptionPage();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseAuthentication();
        app.UseSession();
        // app.UseMvc();
        app.UseEndpoints(endpoint =>
        {
            endpoint.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
        app.Run();
    }
}