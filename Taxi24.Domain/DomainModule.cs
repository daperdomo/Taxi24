using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi24.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var _current = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(_current)
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
