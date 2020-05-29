using GigHub.Persistence;
using Ninject.Modules;

namespace GigHub.Core.Models
{
    public class GigHubModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}