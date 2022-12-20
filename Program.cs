using CodeFirstApi.Interfaces;
using CodeFirstApi.Services;
using DB;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddTransient<ICountryServices, CountryServices>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TestEFContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestEFConnection"))
);


var app = builder.Build();

//using(var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetService<TestEFContext>();
//    context.Database.Migrate();
//}

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
