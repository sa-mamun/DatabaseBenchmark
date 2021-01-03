using Autofac;
using DatabaseBenchmark.Core.Entity;
using DatabaseBenchmark.Core.Repositories;
using DatabaseBenchmark.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RootBookService>().As<IRootBookService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<Repository<RootBook>>().As<IRepository<RootBook>>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
