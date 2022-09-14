using SplatoonBot.CqHttp;
using SplatoonBot.Splatoon2;
using SplatoonBot.Splatoon3;
using SplatoonBot.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOptions().Configure<CqHttpOptions>(builder.Configuration.GetSection("CqHttp"));
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<ISplatoon3Manager, Splatoon3Manager>();
builder.Services.AddSingleton<ISplatoon2Manager, Splatoon2Manager>();
builder.Services.AddSingleton<ITextManager, TextManager>();
builder.Services.AddSingleton<ICqHttpManager, CqHttpManager>();
builder.Services.AddSingleton<ICqHttpService, CqHttpService>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();