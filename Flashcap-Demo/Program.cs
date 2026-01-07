
using FlashCap;
using Terminal.Gui.App;
using Terminal.Gui.Configuration;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace Flashcap_Demo;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        var backgroundDownload = FFmpeg.DownloadBackground();
        var app = Application.Create();
        app.Run<MainWindow>();
        app.Dispose();
        var device = new CaptureDevices();
        var deviceDescriptors = device.GetDescriptors()
            .Where(x=>x.Characteristics.Length > 0)
            .ToList();
        var menu = new Menu
        {
            DeviceDescriptors = deviceDescriptors,
        };
        var captureDeviceDescriptor = menu.ShowDeviceMenu();
        var characteristic = menu.ShowCharacteristicMenu();
        Console.WriteLine($"Chosen:\n\t" +
                          $"{captureDeviceDescriptor}\n\t" +
                          $"{characteristic}");
        if (!backgroundDownload.IsCompleted)
        {
            await backgroundDownload;
        }

        Console.WriteLine("We have both a selected Device and FFmpeg");
        
        
    }
    
}

internal class MainWindow : Window
{
    public MainWindow()
    {
        Title = "CapEd";
    }
}