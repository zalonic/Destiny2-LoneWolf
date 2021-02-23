using System.Windows;
using Destiny2LoneWolf.Views;
using Prism.Ioc;

namespace Destiny2LoneWolf
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry) {}
    }
}
