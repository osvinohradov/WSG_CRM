using Ninject.Modules;
using WSG.DAL.Interfaces;
using WSG.DAL.Repositories;
using WSG.DAL.Repositories.Avia;

namespace WSG.BAL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            this.connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
