﻿using System.IO;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Solid.Practices.Modularity;
using Swashbuckle.AspNetCore.Swagger;

namespace Samples.Specifications.Server.Api
{
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IServiceCollection>
    {
        public void RegisterModule(IServiceCollection dependencyRegistrator) => dependencyRegistrator.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"});
            c.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath,
                $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
        });
    }
}
