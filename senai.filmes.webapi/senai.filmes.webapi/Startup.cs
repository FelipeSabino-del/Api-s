using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace senai.filmes.webapi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //ADICIONA MVC AO PROJETO
            services.AddMvc()
            .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "jwtBearer";
            })
            .AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //QUEM ESTÁ SOLICITANDO
                    ValidateIssuer = true,

                    //QUEM ESTÁ RECEBENDO
                    ValidateAudience = true,

                    //VALIDA O TEMPO DE EXPERIÇÃO
                    ValidateLifetime = true,

                    //FORMA DA CRIPTOGRAFIA
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao")),

                    //TEMPO DE EXPIRAÇÃO DO TOKEN
                    ClockSkew = TimeSpan.FromMinutes(30),

                    //NOME DE QUEM ESTÁ EMITINDO
                    ValidIssuer = "Filmes.WebApi",

                    //NOME DE QUEM VAI RECEBER
                    ValidAudience = "Filmes.WebApi"
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            // DEFINE USO DO MVC
            app.UseMvc();
           
        }
    }
}
