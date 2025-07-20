
using ToDoRepository;

namespace TodoApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        

        builder.Services.AddControllers();
        builder.Services.AddSingleton(new MongoDbRepositoryOptions
        {
            ConnectionString = builder.Configuration.GetConnectionString("TodoApiDatabase")!,
            DatabaseName = builder.Configuration["TodoApiDatabaseName"]

        });
        builder.Services.AddTransient<IToDoRepository,MongoDbToDoRepository>();
        
       
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

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