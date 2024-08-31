﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace VoipService.Api.Configuration
{
    public static class ApiVersioningConfiguration
    {
        public static void RegisterApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(option =>
            {
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(1, 0);
                option.ApiVersionReader = new UrlSegmentApiVersionReader();
                option.ReportApiVersions = true;
            });
        }
    }
}
