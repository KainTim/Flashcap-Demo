using FlashCap;

namespace Flashcap_Demo;

public class Menu
{
    public required  List<CaptureDeviceDescriptor> DeviceDescriptors { get; set; }
    public CaptureDeviceDescriptor? ChosenDevice { get; set; }
    public VideoCharacteristics? ChosenCharacteristic { get; set; }
    
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
        ChosenDevice = DeviceDescriptors[deviceIndex];
        return ChosenDevice;
    }
    public VideoCharacteristics ShowCharacteristicMenu(CaptureDeviceDescriptor? deviceDescriptor = null)
    {
        if (ChosenDevice == null && deviceDescriptor == null)
        {
            throw new ArgumentException("You must choose a device");
        }
        ChosenDevice ??= deviceDescriptor;
        var index = -1;
        while (index == -1)
        {
            PrintCharacteristics();
            var input = Console.ReadLine();
            int.TryParse(input, out var result);
            if (result<1 || result>ChosenDevice!.Characteristics.Length)
            {
                continue;
            }
            index = result-1;
        }
        ChosenCharacteristic = ChosenDevice!.Characteristics[index];
        return ChosenCharacteristic;
    }
    private void PrintCharacteristics()
    {
        Console.WriteLine("Choose your Resolution/Framerate:");

        for (var index = ChosenDevice!.Characteristics.Length-1; index >=0; index--)
        {
            var characteristic = ChosenDevice.Characteristics[index];
            Console.WriteLine($"\t({index + 1}): {characteristic}");
        }
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
