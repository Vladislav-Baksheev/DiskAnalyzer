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
                    TotalSize = ByteConverter.ToGigabytes(drive.TotalSize),
                    FreeSize = ByteConverter.ToGigabytes(drive.AvailableFreeSpace),
                    UsedSize = ByteConverter.ToGigabytes(drive.TotalSize - drive.AvailableFreeSpace)
                });
            }
            catch
            {
            }
        }

        return drives;
    }
}