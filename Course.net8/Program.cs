
using Course.net8.Infra.ApplicationDbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
     options.AddPolicy("AllowAngularApp",
          policy => { policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod(); });
});

// Add services to the container.

builder.Services.Configure<HeadersRemoveConfig>(builder.Configuration.GetSection("HeaderToRemove"));
// builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CourseDbContext>(o=>o.UseInMemoryDatabase("CourseDb"));

//Resolve DI
// builder.Services.AddSingleton<IProductsRepository, ProductsRepository>();
//builder.Services.AddTransient<IProductsRepository, ProductsRepository>();//מייצר בכל פעם איסטנס חדש
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();//best Practise
//אחד פאר בקשה

var app = builder.Build();


app.UseHttpsRedirection();


if (app.Environment.IsDevelopment())
{
     app.UseSwagger();
     app.UseSwaggerUI();
}
app.UseCors("AllowAngularApp");
app.MapProducts();
app.UseHttpsRedirection();
// app.UseAuthorization();
// app.MapControllers();



app.Run();







