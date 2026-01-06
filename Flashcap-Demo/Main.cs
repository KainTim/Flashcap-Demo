
using FlashCap;

var device = new CaptureDevices();
foreach (var descriptor in device.GetDescriptors())
{
    Console.WriteLine($"Name: {descriptor.Name}, " +
                      $"Description: {descriptor.Description}, " +
                      $"DeviceType: {descriptor.DeviceType}, " +
                      $"Identity: {descriptor.Identity}" +
                      $"Characteristics:\n" +
                      $"\t{string.Join("\n\t",descriptor.Characteristics.Where(x=>x.Height >=1080))}"
                      );
}