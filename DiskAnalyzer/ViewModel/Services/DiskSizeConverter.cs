namespace DiskAnalyzer.ViewModel.Services;

public static class DiskSizeConverter
{
    public static double ToGigabytes(long bytes)
    {
        return Math.Round(bytes / 1073741824.0, 2);
    } 
    
    public static int BytesToPercent(long usedBytes, long totalBytes) 
    {
        if (totalBytes == 0) return 0;
        return (int)Math.Round((double)usedBytes / totalBytes * 100, MidpointRounding.AwayFromZero);
    }
}