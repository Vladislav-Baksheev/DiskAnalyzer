namespace DiskAnalyzer.ViewModel.Services;

public static class ByteConverter
{
    public static double ToGigabytes(long bytes)
    {
        return Math.Round(bytes / 1073741824.0, 2);
    } 
}