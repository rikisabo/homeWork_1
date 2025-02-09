using תשתית_לניהול_חנות_פיצה_חני_גולדברג;
using myServices;
using myModels.Interfaces;
using myModels;
using FileService;
using FileService.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using תשתית_לניהול_חנות_פיצה_חני_גולדברג.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
//בשביל הרשאת גישה לריאקט
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000/");
                      });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IpizzaMannager, ChanisPizzaServices>();
builder.Services.AddTransient<Iorders, OrdersServices>();
builder.Services.AddScoped<Iworker, WorkerServices>();
builder.Services.AddScoped<Ilogin, LoginServices>();
//לבדוק ניתוב יחסי
builder.Services.AddSingleton<IFileService<ChanisPizza>>(new ReadWrite<ChanisPizza>(@"file.json"));
builder.Services.AddSingleton<IFileService<string>>(new ReadWrite<string>(@"actionLog.txt"));
builder.Services.AddSingleton<IFileService<Worker>>(new ReadWrite<Worker>(@"workerFile.json"));




//הזרקת תלות 
builder.Services
      .AddAuthentication(options =>
      {
          options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(cfg =>
      {
          cfg.RequireHttpsMetadata = false;
          cfg.TokenValidationParameters = PizzaTokenService.GetTokenValidationParameters();
      });
//       public void ConfigureServices(IServiceCollection services)
// {
//     services.AddAuthorization(options =>
//     {
//         options.AddPolicy("superWorker", policy =>
//             policy.RequireClaim("YourClaimType", "ExpectedValue")); // Customize as needed
//     });

//     services.AddControllers();
//     // Add other services...
// }

builder.Services.AddAuthorization(cfg =>
{
    
    cfg.AddPolicy("Admin", policy => policy.RequireClaim("Role", "admin"));

     cfg.AddPolicy("SuperWorker", policy => policy.RequireClaim("Role", "superWorker"));
    // cfg.AddPolicy("ClearanceLevel1", policy => policy.RequireClaim("ClearanceLevel", "1", "2"));
    // cfg.AddPolicy("ClearanceLevel2", policy => policy.RequireClaim("ClearanceLevel", "2"));
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FBI", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                { new OpenApiSecurityScheme
                        {
                         Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                    new string[] {}
                }
                });
});

var app = builder.Build();
//הורדתי את זה בשביל הסווגר
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

//בשביל html
app.UseDefaultFiles();
app.UseStaticFiles();


// app.UseAuthorization();

// app.MapControllers();
//  app.UseCustom();
// app.Run();
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
// app.UseEndpoints(); 
app.MapControllers();
app.Run();
