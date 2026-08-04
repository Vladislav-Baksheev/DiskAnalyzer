namespace DiskAnalyzer.Model;

public class Drive
{
    public string DriveName { get; set; }
    public double TotalSize { get; set; }
    public double UsedSize { get; set; }
    public double FreeSize { get; set; }
    public int UsagePercent { get; set; }
}