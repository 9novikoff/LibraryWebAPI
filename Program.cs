using AutoMapper;
using LibraryWebAPI.BLL;
using LibraryWebAPI.DAL;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace LibraryWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpLogging(logging =>
            {
                logging.LoggingFields = HttpLoggingFields.All;
                logging.RequestHeaders.Add(HeaderNames.Accept);
                logging.RequestHeaders.Add(HeaderNames.ContentType);
                logging.RequestHeaders.Add(HeaderNames.ContentDisposition);
                logging.RequestHeaders.Add(HeaderNames.ContentEncoding);
                logging.RequestHeaders.Add(HeaderNames.ContentLength);

                logging.MediaTypeOptions.AddText("application/json");
                logging.RequestBodyLogLimit = 4096;
                logging.ResponseBodyLogLimit = 4096;
            });


            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddDbContext<LibraryContext>();

            builder.Services.AddTransient<LibraryRepository>();

            builder.Services.AddTransient(s =>
                new LibraryService(s.GetRequiredService<LibraryRepository>(), s.GetRequiredService<IMapper>()));

            builder.Services.AddControllers();


            var app = builder.Build();


            app.UseExceptionHandler("/error");

            app.Map("/error", ap => ap.Run(async context =>
            {
                await context.Response.WriteAsync("An error occurred while processing the request!");
            }));


            app.UseHttpLogging();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}