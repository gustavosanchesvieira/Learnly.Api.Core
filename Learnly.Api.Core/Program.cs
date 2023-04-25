using Learnly.Api.Core.Configuration;
using Learnly.Api.Core.Data;
using Learnly.Api.Core.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string conexaoDb = builder.Configuration.GetConnectionString("connectionMySql");
builder.Services.AddDbContext<DataContext>(x => x.UseMySql(conexaoDb, ServerVersion.AutoDetect(conexaoDb)));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
        c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Learnly API", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
            });
        }
    );
builder.Services.SetUpSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Learnly API v1"));

InfoLearnlySystem.ApiKey = builder.Configuration.GetValue<string>("ApiKey");
InfoLearnlySystem.SecretKey = builder.Configuration.GetValue<string>("SecretKey");

app.Run();
