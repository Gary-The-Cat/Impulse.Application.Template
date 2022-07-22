
using Impulse.Shared.Application;
using Ninject;

namespace Impulse.Application
{
    public class Application : IApplication
    {
        private WeakReference<IKernel> kernelReference;

        public Application(IKernel kernel)
        {
            this.kernelReference = new WeakReference<IKernel>(kernel);
        }

        // The kernel can safely be assumed alive for the duration of the application.
        public IKernel GetKernel()
        {
            _ = kernelReference.TryGetTarget(out var kernel);
            return kernel;
        }

        public string DisplayName => Properties.Resources.Title_MyApplication;

        public Uri Icon => new Uri("pack://application:,,,/Impulse.Application;Component/Resources/DefaultIcon.png");

        public Task Initialize()
        {
            throw new NotImplementedException();
        }

        public Task LaunchApplication()
        {
            throw new NotImplementedException();
        }

        public Task OnClose()
        {
            throw new NotImplementedException();
        }
    }
}