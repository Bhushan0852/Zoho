using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkDemo.Core.Interfaces;
using UnitOfWorkDemo.Infrastructure.Repositories;
using UnitOfWorkDemo.Infrastructure.ServiceExtension;
using Zoho.AutoMapper;
using Zoho.Dapper.Abstract;
using Zoho.Dapper.Interfaces;
using Zoho.Data;
using FluentValidation.AspNetCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Zoho.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/Zoho_Log.txt",rollingInterval : RollingInterval.Minute)
    .MinimumLevel.Warning()
    .CreateLogger();

var allowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("*");
                          builder.AllowAnyHeader();
                          builder.AllowAnyMethod();
                      });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter a valid JWT bearer token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securityScheme, new string[] {} }
    });
});

//builder.Services.AddFluentValidation(configurationExpression: Options => Options.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddFluentValidation(x => { x.RegisterValidatorsFromAssemblyContaining<Program>();});
//builder.Services.AddFluentValidation(configurationExpression: Options => Options.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ZohoConnectionString"));
});
builder.Services.AddDIServices(builder.Configuration);
//builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientRepository,UnitOfWorkDemo.Infrastructure.Repositories.ClientRepository>();
builder.Services.AddScoped<ICurrencyRepository,CurrencyRepository>();
builder.Services.AddScoped<IBillingMethodRepository, BillingMethodRepository>();
builder.Services.AddScoped<IGenericRepository, GenericRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenHandler, UnitOfWorkDemo.Infrastructure.Repositories.TokenHandler>();
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<UnitOfWorkDemo.Core.Interfaces.IUnitOfWork, UnitOfWorkDemo.Infrastructure.Repositories.UnitOfWork>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  ValidIssuer = builder.Configuration["Jwt:Issuer"],
                  ValidAudience = builder.Configuration["Jwt:Audience"],
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
              };
          });

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//app.UseSwagger();
//app.UseSwaggerUI();
//}

// Configure Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlerMiddleware>();

//app.UseDeveloperExceptionPage();
//}

app.UseHttpsRedirection();

//app.UseCors("NUXT");
app.UseCors(allowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
