using Ninject.Modules;
using WSG.BAL.Interfaces;
using WSG.BAL.Services;

namespace WSG.UI.Util
{
    public class AviaInvoiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAviaInvoiceService>().To<AviaInvoiceService>();
        }
    }
}