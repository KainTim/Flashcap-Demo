
using FlashCap;

namespace Flashcap_Demo;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        var backgroundDownload = FFmpeg.DownloadBackground();
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