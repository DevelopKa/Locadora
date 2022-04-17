using Microsoft.EntityFrameworkCore;
using Rental.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RentalContext>(
    options =>
    {
        options.UseLazyLoadingProxies().UseMySql(builder.Configuration.GetConnectionString("LocacaoDB"),
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28"));
    }
    );

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());   

builder.Services.AddMvc(option => option.EnableEndpointRouting = false)
    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 

builder.Services.AddCors(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    //options.WithOrigins("http://localhost:");
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();   
}
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
