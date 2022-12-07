using Autofac;
using Microsoft.AspNetCore.Identity;
using Planeat.Core.Domain;
using Planeat.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.IcC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //builder.RegisterType<Encrypter>()
            //    .As<IEncrypter>()
            //    .SingleInstance();

            builder.RegisterType<PasswordHasher<User>>()
                .As<IPasswordHasher<User>>()
                .InstancePerLifetimeScope();
        }
    }
}
