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
// File             : GraphQLStartup.cs
// ************************************************************************

using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.GraphQL;

namespace KnightsTour.WebAPI.DotNetCore
{
    public class GraphQLStartup
    {
        #region Public methods
        public static void ConfigureServices(IServiceCollection services, IHostingEnvironment environment)
        {
            // Universal
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddSingleton<IDocumentExecuter>(new DocumentExecuter());
            services.AddSingleton<IDocumentWriter>(new DocumentWriter(true));

            // Data
            services.AddSingleton(new KnightsTourData());

            // CRUD
            services.AddSingleton<KnightsTourQuery>();
            services.AddSingleton<KnightsTourMutation>();

            #region Types
            foreach (var type in GetGraphQlTypes())
            {
                services.AddSingleton(type);
            }
            services.AddSingleton(new ShortGraphType());
            #endregion

            //Schema
            services.AddSingleton<ISchema, KnightsTourSchema>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Add GraphQL services and configure options
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = environment.IsDevelopment();
            })
                .AddWebSockets() // Add required services for web socket support
                .AddDataLoader(); // Add required services for DataLoader support

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }
        public static void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseGraphQL<ISchema>("/graphql");
        }
        #endregion

        #region Private support methods
        static IEnumerable<Type> GetGraphQlTypes()
        {
            return typeof(Startup).Assembly
                .GetTypes()
                .Where(x => !x.IsAbstract &&
                            (typeof(IObjectGraphType).IsAssignableFrom(x) ||
                             typeof(IInputObjectGraphType).IsAssignableFrom(x)));
        }
        #endregion
    }
}

