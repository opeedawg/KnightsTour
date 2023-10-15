// © 2023 DXterity Solutions
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : January 13, 2023 7:25:02 AM
// File             : Startup.cs
// ************************************************************************

using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Types;
using KnightsTour.CoreLibrary;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.GraphQL;
using WebAPI.GraphQL.Types;

namespace KnightsTour.WebAPI.DotNetCore
{
    public class Startup
    {
        #region Properties
        public IHostingEnvironment Environment { get; }
        public IConfiguration Configuration { get; }
        public string[] AllowedOrigins
        {
            get
            {
                string allowedUrlConfigurations = ConfigurationAssistant.GetString("allowedUiUrls", "http://localhost:*");
                return allowedUrlConfigurations.Split(',');
            }
        }
        #endregion

        #region Methods
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("*", options => options
            .WithOrigins(AllowedOrigins)
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials());
            });

            SwaggerStartup.ConfigureServices(services, Environment);
            GraphQLStartup.ConfigureServices(services, Environment);
            RestStartup.ConfigureServices(services, Environment);
            // ODataStartup.ConfigureServices(services, Environment);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors(options => options.WithOrigins(AllowedOrigins).SetIsOriginAllowedToAllowWildcardSubdomains().AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                ForwardedHeaders.XForwardedProto
            });
            SwaggerStartup.Configure(app, env, loggerFactory);
            GraphQLStartup.Configure(app, env, loggerFactory);
            RestStartup.Configure(app, env, loggerFactory);
            // ODataStartup.Configure(app, env, loggerFactory);
        }
        #endregion
    }
}