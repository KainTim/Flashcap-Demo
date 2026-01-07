
using FlashCap;

namespace Flashcap_Demo;

internal static class Program
{
    public static void Main(string[] args)
    {
        var device = new CaptureDevices();
        var deviceDescriptors = device.GetDescriptors().Where(x=>x.Characteristics.Length > 0).ToList();
        var deviceIndex = -1;
        while (deviceIndex == -1)
        {
            PrintDevices(deviceDescriptors);
            var input = Console.ReadLine();
            int.TryParse(input, out var result);
            if (result<1 || result>deviceDescriptors.Count)
            {
                continue;
            }
            deviceIndex = result-1;
        }
        var captureDescriptor = deviceDescriptors[deviceIndex];
        Console.WriteLine($"Characteristics:\n\t{string.Join("\n\t",captureDescriptor.Characteristics)}");
    }
    private static void PrintDevices(List<CaptureDeviceDescriptor> descriptors)
    {
        Console.WriteLine("Choose your Device:");
        for (var index = 0; index < descriptors.Count; index++)
        {
            var descriptor = descriptors[index];
            Console.WriteLine($"\t({index+1}): {descriptor.Name}");
        }
    }
}