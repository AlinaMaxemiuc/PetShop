using exp.Template.Backend.Auth;
using exp.Template.Backend.Data;
using exp.Template.Backend.Helpers;
using exp.Template.Infrastructure.Context;
using exp.Template.Infrastructure.Repositories.Abonaments;
using exp.Template.Infrastructure.Repositories.Animals;
using exp.Template.Infrastructure.Repositories.Comenzi;
using exp.Template.Infrastructure.Repositories.Discounts;
using exp.Template.Infrastructure.Repositories.Foods;
using exp.Template.Infrastructure.Repositories.Livrarii;
using exp.Template.Infrastructure.Repositories.Users;
using exp.Template.Models.Helpers;
using exp.Template.Services.Animals;
using exp.Template.Services.Email;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("identityDatabase");
builder.Services.AddDbContext<AnimalsFoodContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
 options.UseSqlServer(
                    builder.Configuration.GetConnectionString("identityDatabase"))
 );
// Initialiaze with your DB
builder.Services.AddDbContext<AnimalsFoodContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiDatabase"))
                    );

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
});
    /*
.AddMicrosoftAccount(microsoftOptions =>
{
    microsoftOptions.ClientId =  builder.Configuration["Authentication:MicrosoftClientId"];
    microsoftOptions.ClientSecret = builder.Configuration["Authentication:MicrosoftClientSecret"];
})
.AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = builder.Configuration["Authentication:GoogleClientId"];
        googleOptions.ClientSecret = builder.Configuration["Authentication:GoogleClientSecret"];

    })
 .AddFacebook(facebookOptions =>
  {
      facebookOptions.Scope.Add("email");
      facebookOptions.Scope.Add("public_profile");
      facebookOptions.ClientId = builder.Configuration["Authentication:FacebookClientId"];
      facebookOptions.ClientSecret = builder.Configuration["Authentication:FacebookClientSecret"];
  });
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});
    */
// Configure expired refresh token time
_ = double.TryParse(builder.Configuration.GetSection("JWT:RefreshTokenValidityInDays").Value, out double refreshTokenValidityInDays);
builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromDays(refreshTokenValidityInDays);
    options.Name = "Default";
});

// caching
builder.Services.AddResponseCaching();
builder.Services.AddControllers(options =>
{
    var cacheProfiles = builder.Configuration
            .GetSection("CacheProfiles")
            .GetChildren();
    foreach (var cacheProfile in cacheProfiles)
    {
        options.CacheProfiles
        .Add(cacheProfile.Key,
        cacheProfile.Get<CacheProfile>());
    }
});

builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(x =>
{
    // serialize enums as strings in api responses (e.g. Role)
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers()
            .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
// dependence injection
builder.Services.AddScoped<IBasicRegisterMethods, BasicRegisterMethods>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IAbonamentRepository, AbonamentRepository>();
builder.Services.AddScoped<IComandaRepository, ComandaRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IHranaRepository, HranaRepository>();
builder.Services.AddScoped<ILivrariRepository, LivrariRepository>();
builder.Services.AddScoped<IUtilizatorRepository, UtilizatorRepository>();


builder.Services.AddScoped<IAnimalService, AnimalService>();

Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();


var app = builder.Build();
app.UseCors(x => x
        .SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseResponseCaching();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

app.Run();
