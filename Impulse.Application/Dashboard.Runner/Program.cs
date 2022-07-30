using System;
using System.Diagnostics;

const string DashboardLocation = @"C:\Program Files\Impulse Dashboard\Impulse.Dashboard.exe";
var applicationDirectory = @"C:\Users\lukeb\Documents\Impulse.Application.Template\Impulse.Application\Impulse.Application\bin\Debug\net6.0-windows";

Process.Start(DashboardLocation, $"--application {applicationDirectory}");