using Constant;
using DentistBooking.Application.System.Bookings;
using DentistBooking.Application.System.Clinics;
using DentistBooking.Application.System.Dentists;
using DentistBooking.Application.System.Discounts;
using DentistBooking.Application.System.Services;
using DentistBooking.Data.DataContext;
using DentistBooking.Data.Entities;
using DentistBooking.ViewModels.System.Dentists;
using DentistBooking.ViewModels.System.Users;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using DentistBooking.Application.System.Users;
using System.Net;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace DentistsBooking.Api
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //Add Dbcontext
            services.AddDbContext<DentistDBContext>(options => options.
            UseSqlServer(Configuration.GetConnectionString(ConnectionString.MainConnectionString)));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                 .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                options.SlidingExpiration = true;
                options.LoginPath = "/Error";
                options.AccessDeniedPath = "/Error";
            });
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<DentistDBContext>().AddDefaultTokenProviders();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = Configuration["JwtIssuer"],
                      ValidAudience = Configuration["JwtAudience"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityKey"]))
                  };
              });

            //Declare DI
            services.AddScoped<UserManager<User>, UserManager<User>>();
            services.AddScoped<SignInManager<User>, SignInManager<User>>();
            services.AddScoped<RoleManager<Role>, RoleManager<Role>>();
            services.AddScoped<IDentistService, DentistService>();
            services.AddScoped<IClinicService, ClinicService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();
            services.AddScoped<IValidator<AddDentistRequest>, AddDentistRequestValidator>();
            services.AddScoped<IClinicService, ClinicService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IUserService, UserService>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DentistsBooking.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DentistsBooking.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .SetIsOriginAllowed(origin => true) // allow any origin
                     .AllowCredentials());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStatusCodePages(async context =>
            {
                var response = context.HttpContext.Response;

                if (response.StatusCode == (int)HttpStatusCode.Unauthorized ||
                        response.StatusCode == (int)HttpStatusCode.Forbidden)
                    response.Redirect("/Error");
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
