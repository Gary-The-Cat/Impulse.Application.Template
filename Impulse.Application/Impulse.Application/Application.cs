using Impulse.Application.Documents;
using Impulse.SharedFramework.Application;
using Impulse.SharedFramework.Plugin;
using Impulse.SharedFramework.Ribbon;
using Impulse.SharedFramework.Services;
using Ninject;

namespace Impulse.Application;

public class Application : IApplication
{
    public string DisplayName => Properties.Resources.Title_MyApplication;

    public Uri Icon => new Uri("pack://application:,,,/Impulse.Dashboard;Component/Icons/Export/DefaultIcon.png");

    public IDashboardProvider Dashboard { get; set; }

    public Task Initialize()
    {
        return Task.CompletedTask;
    }

    public Task LaunchApplication()
    {
        var ribbonService = this.Dashboard.RibbonService;

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
        var documentService = this.Dashboard.DocumentService;
        var document = new MyFirstDocumentViewModel();
        documentService.OpenDocument(document);
    }

    public Task OnClose()
    {
        return Task.CompletedTask;
    }
}