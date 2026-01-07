
using FlashCap;

namespace Flashcap_Demo;

internal static class Program
{
    public static void Main(string[] args)
    {
        var device = new CaptureDevices();
        var deviceDescriptors = device.GetDescriptors()
            .Where(x=>x.Characteristics.Length > 0)
            .ToList();
        var menu = new Menu
        {
            DeviceDescriptors = deviceDescriptors,
        };
        var captureDeviceDescriptor = menu.ShowDeviceMenu();
        Console.WriteLine($"Characteristics:\n\t" +
                          $"{string.Join("\n\t",captureDeviceDescriptor.Characteristics)}");
    }
    
}