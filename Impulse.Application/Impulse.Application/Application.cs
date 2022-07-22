using Impulse.Application.Documents;
using Impulse.Shared.Application;
using Impulse.SharedFramework.Ribbon;
using Impulse.SharedFramework.Services;
using Ninject;

namespace Impulse.Application;

public class Application : IApplication
{
    private WeakReference<IKernel> kernelReference;

    public Application(IKernel kernel)
    {
        this.kernelReference = new WeakReference<IKernel>(kernel);
    }

    /// <summary>
    /// The kernel can safely be assumed alive for the duration of the application.
    /// </summary>
    /// <returns>An instance of the dashboards kernel.</returns>
    public IKernel GetKernel()
    {
        _ = kernelReference.TryGetTarget(out var kernel);
        return kernel;
    }

    public string DisplayName => Properties.Resources.Title_MyApplication;

    public Uri Icon => new Uri("pack://application:,,,/Impulse.Dashboard;Component/Icons/Export/DefaultIcon.png");

    public Task Initialize()
    {
        return Task.CompletedTask;
    }

    public Task LaunchApplication()
    {
        var ribbonService = this.GetKernel().Get<IRibbonService>();

        ribbonService.AddTab("ApplicationTemplate.Home", "Home");
        ribbonService.AddGroup("ApplicationTemplate.Home.GettingStarted", "Group");

        var myButton = new RibbonButtonViewModel()
        {
            Id = "ApplicationTemplate.Home.GettingStarted.MyButton",
            Title = "Button",
            Callback = this.MyButtonClick,
            EnabledIcon = "pack://application:,,,/Impulse.Dashboard;Component/Icons/Export/DefaultIcon.png",
        };

        ribbonService.AddButton(myButton);

        return Task.CompletedTask;
    }

    private void MyButtonClick()
    {
        var kernel = this.GetKernel();
        var documentService = kernel.Get<IDocumentService>();
        var document = kernel.Get<MyFirstDocumentViewModel>();
        documentService.OpenDocument(document);
    }

    public Task OnClose()
    {
        return Task.CompletedTask;
    }
}