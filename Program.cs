using AutoMapper;
using LibraryWebAPI.BLL;
using LibraryWebAPI.DAL;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddDbContext<LibraryContext>();

            builder.Services.AddTransient<LibraryRepository>();

            builder.Services.AddTransient(s =>
                new LibraryService(s.GetRequiredService<LibraryRepository>(), s.GetRequiredService<IMapper>()));

            builder.Services.AddControllers();


            var app = builder.Build();

            app.UseHttpLogging();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}