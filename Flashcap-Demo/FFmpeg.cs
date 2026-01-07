using Xabe.FFmpeg;
using Xabe.FFmpeg.Downloader;

namespace Flashcap_Demo;

public class FFmpeg
{
    public static Task DownloadBackground()
    {
        return FFmpegDownloader.GetLatestVersion(FFmpegVersion.Official, new Progress<ProgressInfo>(info =>
                {
                    if (info.TotalBytes<=1)return;
                    var percentageDone = (double)info.DownloadedBytes / info.TotalBytes;
                    Console.Write($"Downloaded {FormatBytes(info.DownloadedBytes)} of {FormatBytes(info.TotalBytes)},  {FormatPercentage(percentageDone)}\r");
                }));
    }

    private static string FormatBytes(long bytes)
    {
        return $"{bytes / 1000000.0d:#00.00}MB";
    }
    private static string FormatPercentage(double percentage)
    {
        return $"{percentage*100:00.00}%";
    }
    
}