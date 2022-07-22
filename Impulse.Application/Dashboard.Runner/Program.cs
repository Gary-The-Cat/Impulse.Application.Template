using System;
using System.Diagnostics;

const string DashboardLocation = @"[Path]\[To]\Impulse.Dashboard.exe";
var applicationDirectory = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Process);

Process.Start(DashboardLocation, $"--application {applicationDirectory}");