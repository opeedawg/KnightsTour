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
// File             : ClassicStartup.cs
// ************************************************************************

using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightsTour.WebAPI.DotNetCore
{
    public class RestStartup
    {
        #region Public methods
        public static void ConfigureServices(IServiceCollection services, IHostingEnvironment environment)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false).AddNewtonsoftJson();
        }
        public static void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=rest}/{action=ping}/{id?}");
                routes.MapRoute("classic", "rest/{controller}/{action=ping}/{id?}");
            });
        }
        #endregion
    }
}