using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Patrimonios.Context;
using Patrimonios.Profiles;
using Patrimonios.Repositorio.Impl;
using Patrimonios.Repositorio.Interfaces;
using Patrimonios.Services.Impl;
using Patrimonios.Services.Interface;

namespace Patrimonios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegistrarContexto(services);
            services.AddCors(options =>
            {
                options.AddPolicy("CorsConfig",
                builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                });
            });
            services.AddControllers();
            RegistrarJWT(services);
            RegistrarSwager(services);
            RegistrarServicos(services);
            RegistrarAutoMapper(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsConfig");

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Patrimonios");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            


            
        }

        private void RegistrarServicos (IServiceCollection service)
        {
            service.AddSingleton<IMarcaRepositorio, MarcaRepositorio>();
            service.AddSingleton<IPatrimonioRepositorio, PatrimonioRepositorio>();
            service.AddSingleton<IUsuarioRepositorio, UsuarioRepositorio>();
            
            service.AddScoped<IMarcaService, MarcaService>();
            service.AddScoped<IPatrimonioService, PatrimonioService>();
            service.AddScoped<IUsuarioService, UsuarioService>();
            service.AddScoped<IAuthenticationService, AuthenticationService>();
            service.AddScoped<IExercio1Service, Exercicio1Service>();

        }


        private void RegistrarContexto (IServiceCollection service)
        {
            service.AddDbContextPool<PatrimoniosContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PatrimonioDbContext")));
        }


        private void RegistrarAutoMapper(IServiceCollection service)
        {
            service.AddAutoMapper(typeof(UsuarioProfile));
            service.AddAutoMapper(typeof(PatrimonioProfile));
            service.AddAutoMapper(typeof(MarcaProfile));
        }

        private void RegistrarSwager (IServiceCollection service)
        {
            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                                new OpenApiInfo
                                {
                                    Title = "Patrimonios",
                                    Version = "v1",
                                    Description = "Projeto criado para avalição",
                                    Contact = new OpenApiContact
                                    {
                                        Name = "Vitor Ricardo",
                                        Url = new Uri("https://www.linkedin.com/in/vitor-ricardo-847a28b9/"),
                                        Email = "viitoricardo@gmail.com"
                                    }
                                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
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
            });

        }

        public void RegistrarJWT(IServiceCollection services)
        {
            
            var secret = Encoding.ASCII.GetBytes("gPvwLhqx3zqFng74JdrtgPvwLhqx3z");
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secret),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
