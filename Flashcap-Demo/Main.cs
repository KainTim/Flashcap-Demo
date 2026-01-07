
using FlashCap;

var device = new CaptureDevices();
var descriptors = device.GetDescriptors().Where(x=>x.Characteristics.Length > 0).ToList();
var deviceIndex = -1;
while (deviceIndex == -1)
{
    PrintDevices(descriptors);
    var input = Console.ReadLine();
    int.TryParse(input, out var result);
    if (result<1 || result>descriptors.Count)
    {
        continue;
    }
    deviceIndex = result-1;
}
var captureDescriptor = descriptors[deviceIndex];
Console.WriteLine($"Characteristics:\n\t{string.Join("\n\t",captureDescriptor.Characteristics)}");
return;

void PrintDevices(List<CaptureDeviceDescriptor> captureDeviceDescriptors)
{
    Console.WriteLine("Choose your Device:");
    for (var index = 0; index < captureDeviceDescriptors.Count; index++)
    {
        var descriptor = captureDeviceDescriptors[index];
        Console.WriteLine($"\t({index+1}): {descriptor.Name}");
    }
}