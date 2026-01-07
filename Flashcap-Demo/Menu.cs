using FlashCap;

namespace Flashcap_Demo;

public class Menu
{
    public required  List<CaptureDeviceDescriptor> DeviceDescriptors { get; init; }
    
    public CaptureDeviceDescriptor ShowDeviceMenu()
    {
        var deviceIndex = -1;
        while (deviceIndex == -1)
        {
            PrintDevices();
            var input = Console.ReadLine();
            int.TryParse(input, out var result);
            if (result<1 || result>DeviceDescriptors.Count)
            {
                continue;
            }
            deviceIndex = result-1;
        }
        return DeviceDescriptors[deviceIndex];
    }
    private void PrintDevices()
    {
        Console.WriteLine("Choose your Device:");
        for (var index = 0; index < DeviceDescriptors.Count; index++)
        {
            var descriptor = DeviceDescriptors[index];
            Console.WriteLine($"\t({index+1}): {descriptor.Name}");
        }
    }
}
