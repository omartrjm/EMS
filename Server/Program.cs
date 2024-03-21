
using BaseLibrary.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServerLibrary.Data;
using ServerLibrary.Helpers;
using ServerLibrary.Repositories.Contracts;
using ServerLibrary.Repositories.Implementations;
using System.Text;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //
            builder.Services.Configure<JwtSection>(builder.Configuration.GetSection("JwtSection"));
            var jwtSection = builder.Configuration.GetSection(nameof(JwtSection)).Get<JwtSection>();
            // starting 
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
                    throw new InvalidOperationException("No Connection Found"));
            }
            );

            builder.Services.AddAuthentication(options => 
            { 
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer( options => 
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtSection!.Issuer,
                    ValidAudience = jwtSection.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection.Key))
                };
            });
            //
            builder.Services.AddScoped<IUserAccount, UserAccountRepository>();

            builder.Services.AddScoped<IGenericRepositoryInterface<GeneralDepartment>, GeneralDepartmentRepository>();
            builder.Services.AddScoped<IGenericRepositoryInterface<Department>, DepartmentRepository>();
            builder.Services.AddScoped<IGenericRepositoryInterface<Branch>, BranchRepository>();

            builder.Services.AddScoped<IGenericRepositoryInterface<Country>, CountryRepository>();
            builder.Services.AddScoped<IGenericRepositoryInterface<City>, CityRepository>();
            builder.Services.AddScoped<IGenericRepositoryInterface<Town>, TownRepository>();

            builder.Services.AddScoped<IGenericRepositoryInterface<Employee>, EmployeeRepository>();
            builder.Services.AddCors( options =>
            {
                options.AddPolicy("AllowBlazorWasm",
                    builder => builder
                    .WithOrigins("http://localhost:5267", "https://localhost:7176")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowBlazorWasm");

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
