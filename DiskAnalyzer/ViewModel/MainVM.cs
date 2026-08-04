using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using DiskAnalyzer.Model;
using DiskAnalyzer.ViewModel.Services;

namespace DiskAnalyzer.ViewModel;

public class MainVM
{
    public List<Drive> Drives { get; set; } = new();
    
    public MainVM()
    {
        Drives = AnalyzeDisk();
    }

    private List<Drive> AnalyzeDisk()
    {
        var drives = new List<Drive>();
        foreach (var drive in DriveInfo.GetDrives())
        {
            try
            {
                drives.Add(new Drive()
                {
                    DriveName = drive.Name,
                    TotalSize = DiskSizeConverter.ToGigabytes(drive.TotalSize),
                    FreeSize = DiskSizeConverter.ToGigabytes(drive.AvailableFreeSpace),
                    UsedSize = DiskSizeConverter.ToGigabytes(drive.TotalSize - drive.AvailableFreeSpace),
                    UsagePercent = DiskSizeConverter.BytesToPercent(
                        drive.TotalSize - drive.AvailableFreeSpace, 
                        drive.TotalSize)
                });
            }
            catch
            {
            }
        }

        return drives;
    }
}