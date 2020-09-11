using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using TestAuth.Auth.Common;
using TestAuth.Resource.Api.Models;

namespace TestAuth.Resource.Api
{
    public class Startup
    {

        public Startup(IConfiguration configuration )
        {
            Configuration = configuration;
        }
      public IConfiguration Configuration { get; }

      public void ConfigureServices(IServiceCollection services)
      {
          services.AddControllers();

          var authOptions = Configuration.GetSection("Auth").Get<AuthOptions>();

          services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.RequireHttpsMetadata = false;
                  options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                  {
                      ValidateIssuer = true,
                      ValidIssuer = authOptions.Issuer,

                      ValidateAudience = true,
                      ValidAudience = authOptions.Audience,

                      ValidateLifetime = true,

                      IssuerSigningKey = authOptions.GetSymmetricSecurityKey(), //HS256
                      ValidateIssuerSigningKey = true,
                  };

              });


          services.AddCors(options =>
          {
              options.AddDefaultPolicy(
                  builder =>
                  {
                      builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                  });
          });
          services.AddSingleton(new BookStore());
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
     app.UseRouting();
            app.UseAuthorization();
       
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
