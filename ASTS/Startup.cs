using System;
using ASTS.EF;
using ASTS.Services;
using ASTS.Services.Interfaces;
using ASTS.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;


namespace ASTS
{
    public class Startup
    {
        private AuthOptions _authOptions;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _authOptions = Configuration.GetSection(nameof(AuthOptions)).Get<AuthOptions>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AuthOptions>(Configuration);
            services.Configure<AuthOptions>(options =>
            {
                Configuration.GetSection("AuthOptions").Bind(options);
            });

            services.AddDbContext<AstsDbContext>(
                options =>
                {
                    string connStrAzure = Configuration.GetConnectionString("AzureDbConnectionString");
                    string SQLConnectionString = Configuration.GetConnectionString("SQLConnectionString");
                    // string connStrPostgre = Configuration.GetConnectionString("PostgreSQLConnectionString");
                    // options.UseNpgsql(connStrPostgre);

                    options.UseSqlServer(SQLConnectionString);
                    options.UseLazyLoadingProxies();
                });
            services.AddScoped<AstsDbContext>();
            services.AddScoped<IAsyncRepository, EfAsyncRepository>();
            services.AddScoped<IMaterialRequestService, MaterialRequestService>();
            services.AddScoped<IParametersService, ParametersService>();




            services.AddIdentityCore<IdentityUser>().AddSignInManager<SignInManager<IdentityUser>>()
                .AddUserManager<UserManager<IdentityUser>>()
                .AddRoles<IdentityRole>()
                // .AddRoleValidator<RoleValidator<IdentityRole>>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddEntityFrameworkStores<AstsDbContext>();


            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "MyApi",
                    Version = "v1"
                });
                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = "header",
                    Name = "Authorization",
                    Type = "apiKey"
                });
            });



            services.AddIdentityCore<IdentityUser>().AddDefaultTokenProviders();
            services.AddScoped<RoleManager<IdentityRole>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = _authOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = _authOptions.Audience,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = _authOptions.GetSymmetricSecurityKey(),
                        ClockSkew = TimeSpan.Zero
                    };
                });
            services.Configure<IdentityOptions>(
                options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 5;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCors(o => o.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseSwagger();
            app.UseSwaggerUI(setup => {
                setup.SwaggerEndpoint(
                    "/swagger/v1/swagger.json",
                    "My API v1"
                );
            });

            app.UseMvc();
        }
    }
}
