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
//���ö����̬�ļ��з���Ȩ��
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
//���ö����̬�ļ��з���
app.UseManyStaticFiles(Configuration);
app.Run();
