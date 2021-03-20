using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OURCart.Core.IServices;
using OURCart.Infrastructure.Configurations;
using OURCart.Infrastructure.Services;
using System.Text;
using System.Threading.Tasks;

namespace OurCart
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
           services = InfrastructureLayerConfiguration.RunCongiguration(services, Configuration);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               //options.TokenValidationParameters = new TokenValidationParameters
               //{
               //    ValidateIssuer = true,
               //    ValidateAudience = true,
               //    ValidateLifetime = true,
               //    ValidateIssuerSigningKey = true,
               //    ValidIssuer = Configuration["Jwt:Issuer"],
               //    ValidAudience = Configuration["Jwt:Issuer"],
               //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
               //};
               options.Events = new JwtBearerEvents
               {
                   OnAuthenticationFailed = context =>
                   {
                       if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                       {
                           context.Response.Headers.Add("Token-Expired", "true");
                       }
                       return Task.CompletedTask;
                   }
               };
           });
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICartService, CartService>();

            //services.AddScoped<IFavouriteService, FavouriteService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<ICurrentDailyTransfterDetailsService, CurrentDailyTransfterDetailsService>();
            services.AddScoped<ICurrentDailyTransfterHeaderService, CurrentDailyTransfterHeadersService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IFavouriteService, FavService>();
            services.AddScoped<IAppMessagesService, AppMessagesService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "OurCartAPI", Version = "v1" });

            });
            services.AddCors(c =>
            {
                c.AddPolicy("MyPolicy", options => options.AllowAnyOrigin());
            });
            services.AddMvc(c => c.EnableEndpointRouting = false); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();


            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");

            app.UseSwagger();
            app.UseCors("MyPolicy");
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OurCartAPI");

            });
        }
    }
}
