using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesFilmes.Data;
namespace RazorPagesFilmes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<RazorPagesFilmesContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesFilmesContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesFilmesContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection(); 
            // Estou usando os arquivos dessa pasta (wwwroot)
            app.UseStaticFiles();
            // Roteamento de pondot de extremidade at� as nossas p�ginas Razor
            app.UseRouting();
            // Consigo criar autoriza��o (EX: n�o quero que essa pasta seja utilizada por tais pessoas, perfis)
            app.UseAuthorization();
            // Estou mapeando uma rota (Quando algu�m coloca um caminho ou endere�o na pagina, (P�g A,B,C)
            app.MapRazorPages();
            // 
            app.Run();
        }
    }
}
