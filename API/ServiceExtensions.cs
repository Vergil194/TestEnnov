using Application.Core.Configuration;
using Application.Gateways;
using Application.Profils;
using Application.UseCases.Queries;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace API
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInterfaceAdaptersExtensions(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.Configure<ZefixPublicRestApiConfiguration>(configuration.GetSection(nameof(ZefixPublicRestApiConfiguration)));

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin().WithMethods("GET","DELETE","OPTIONS ").AllowAnyHeader();
                });
            });

            services.AddHttpClient("ZefixApi", (sp,opts) =>
            {
                var apiOpts = sp.GetRequiredService<IOptions<ZefixPublicRestApiConfiguration>>().Value;
                opts.BaseAddress = new Uri(apiOpts.BaseUrl);

                var authBytes = Encoding.UTF8.GetBytes($"{apiOpts.Credential.Username}:{apiOpts.Credential.Password}");
                opts.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authBytes));
            });

            services.AddScoped<IZefixApiPublicServices, ZefixApiPublicServices>();

            services.AddMediatR(typeof(GetCompanyByUid.Handler));
            services.AddAutoMapper(typeof(CompanyProfile).Assembly);

            return services;
        }
    }
}
