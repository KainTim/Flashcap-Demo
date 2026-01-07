
using FlashCap;
using Xabe.FFmpeg;

namespace Flashcap_Demo;

internal static class Program
{
    public async static Task Main(string[] args)
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
        var characteristic = menu.ShowCharacteristicMenu();
        Console.WriteLine($"Chosen:\n\t" +
                          $"{captureDeviceDescriptor}\n\t" +
                          $"{characteristic}");
        
        var cancellationTokenSource = new CancellationTokenSource();
        var mediaInfo = await FFmpeg.GetMediaInfo(captureDeviceDescriptor.Identity.ToString(), cancellationTokenSource.Token);
        
        var outName = Path.Join(Directory.GetCurrentDirectory(),"output");

        var parameters =
            $"-f v4l2 " +
            $"-framerate {characteristic.FramesPerSecond} " +
            $"-video_size {characteristic.Width}x{characteristic.Height} " +
            $"-input_format mjpeg " +
            $"-y " +
            $"-report " +
            $"-i {captureDeviceDescriptor.Identity} " +
            $"{outName}.mkv";
        FFmpeg.Conversions.New()
            .Start(parameters, cancellationTokenSource.Token);
        //     .Build();
        // Console.WriteLine(cli);

        Console.WriteLine(parameters);
        await Task.Delay(5000);
        cancellationTokenSource.Cancel();
    }
    
}