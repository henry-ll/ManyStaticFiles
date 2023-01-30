using ManyStaticFiles;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsystem.json", optional: true, reloadOnChange: true)
.AddJsonFile("appsettings.json", true, reloadOnChange: true)
.AddEnvironmentVariables().Build();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//配置多个静态文件夹访问权限
builder.Services.AddManyStaticFiles(builder, Configuration);
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
//启用多个静态文件夹访问
app.UseManyStaticFiles(Configuration);
app.Run();
