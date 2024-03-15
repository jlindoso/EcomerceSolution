

using Application;
using Application.Company.DTO;
using Application.Company.Mediator.Commands.Handler;

using Application.Profiles;
using Data.Postgres;
using Data.Postgres.Reader.Repositories;
using Data.Postgres.Repositories.Company;
using Domain.Ports;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Npgsql;
using System.Data;
using System.Reflection;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<ICompanyPersistenceRepository, CompanyRepository>();

            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("Postgres");
            builder.Services.AddSingleton<IDbConnection>(conf => new NpgsqlConnection(connectionString));
            builder.Services.AddTransient<ICompanyReaderRepository, CompanyReaderRepository>();
            builder.Services.AddControllers().ConfigureApiBehaviorOptions(x =>
            {
                x.SuppressMapClientErrors = true;
                x.SuppressConsumesConstraintForFormFileParameters = true;
                x.SuppressInferBindingSourcesForParameters = true;
                x.SuppressModelStateInvalidFilter = true;
            });
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CompanyDTO)));
            builder.Services.AddDbContext<EcomerceContext>(options =>
                                                                    options.UseNpgsql(connectionString));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<EcomerceContext>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Ecomerce API",
                    Description = "An API for the Ecomerce project.",
                    TermsOfService = new Uri("https://github.com/jlindoso"),
                    Contact = new OpenApiContact
                    {
                        Name = "Jorge A. Lindoso",
                        Email = "jorge.adriano.lindoso@gmail.com",
                        Url = new Uri("https://github.com/jlindoso"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = new Uri("https://github.com/jlindoso"),
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter your token in the text input below.
                      \r\n\r\n Example: '12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly()?.GetName()?.Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();
            app.UseStaticFiles();
            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.InjectStylesheet("/dracula.css");
            });
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
