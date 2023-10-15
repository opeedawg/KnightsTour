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
// File             : ODataStartup.cs
// ************************************************************************

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System.Linq;

namespace KnightsTour.WebAPI.DotNetCore
{
    public class ODataStartup
    {
        #region Public methods
        public static void ConfigureServices(IServiceCollection services, IHostingEnvironment environment)
        {
            // services.AddOData();
            services.AddMvc(op =>
            {
                foreach (var formatter in op.OutputFormatters
                    .OfType<ODataOutputFormatter>()
                    .Where(it => !it.SupportedMediaTypes.Any()))
                {
                    formatter.SupportedMediaTypes.Add(
                        new MediaTypeHeaderValue("application/prs.mock-odata"));
                }
                foreach (var formatter in op.InputFormatters
                    .OfType<ODataInputFormatter>()
                    .Where(it => !it.SupportedMediaTypes.Any()))
                {
                    formatter.SupportedMediaTypes.Add(
                        new MediaTypeHeaderValue("application/prs.mock-odata"));
                }
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
        public static void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //app.UseMvc(routeBuilder =>
            //{
            //    routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            //});
        }
        #endregion

        #region Private support methods
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

			builder.EntitySet<KnightsTour.Board>("Boards");
			builder.EntitySet<KnightsTour.DifficultyLevel>("DifficultyLevels");
			builder.EntitySet<KnightsTour.Puzzle>("Puzzles");
			builder.EntitySet<KnightsTour.Solution>("Solutions");

            return builder.GetEdmModel();
        }
        #endregion
    }
}