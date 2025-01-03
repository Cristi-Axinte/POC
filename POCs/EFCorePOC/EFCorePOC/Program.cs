using EFCorePOC.Data;
using EFCorePOC.Data.Repositories;
using EFCorePOC.Services.Authors;
using EFCorePOC.Services.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddDbContext<BookStoreDbContext>(options => 
                options.UseInMemoryDatabase("BookStoreDbContext"));

        builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
        builder.Services.AddScoped<IWebsiteRepository, WebsiteRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
        builder.Services.AddScoped<IGetBooksService, GetBooksService>();
        builder.Services.AddScoped<IUpdateBookService, UpdateBookService>();
        builder.Services.AddScoped<IDeleteBookService, DeleteBookService>();
        builder.Services.AddScoped<ICreateBookService, CreateBookService>();
        builder.Services.AddScoped<IGetAuthorsService, GetAuthorsService>();

        // Add services to the container.

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<BookStoreDbContext>();
            dbContext.Database.EnsureCreated();
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
