const string DashboardLocation = @"C:\Program Files\Impulse Dashboard\Impulse.Dashboard.exe";

var applicationDirectory =
    @"[Path][To][Repo]\Impulse.Application.Template\Impulse.Application\Impulse.Application\bin\Debug\net6.0-windows";

System.Diagnostics.Process.Start(DashboardLocation, $"--application {applicationDirectory}");