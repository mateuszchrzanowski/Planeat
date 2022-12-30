using Autofac;
using FluentValidation;
using Planeat.Infrastructure.Commands.Users;
using Planeat.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Planeat.Infrastructure.IcC.Modules
{
    public class ValidatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //var assembly = typeof(ValidatorModule).GetTypeInfo().Assembly;

            //builder.RegisterAssemblyTypes(assembly)
            //    .Where(x => x.IsAssignableTo<IValidator>())
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();

            builder.RegisterType<CreateUserValidator>()
                .As<IValidator<CreateUser>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<LoginUserValidator>()
                .As<IValidator<LoginUser>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ChangeUserPasswordValidator>()
                .As<IValidator<ChangeUserPassword>>()
                .InstancePerLifetimeScope();
        }
    }
}
