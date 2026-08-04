using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiskAnalyzer.Model;
using DiskAnalyzer.ViewModel.Services;

namespace DiskAnalyzer.ViewModel;

public partial class MainVM : ObservableObject
{
    private ObservableCollection<Drive> _drives = new();
    
    public ObservableCollection<Drive> Drives
    {
        get => _drives;
        set => SetProperty(ref _drives, value);
    }
    
    public MainVM()
    {
        AnalyzeDisk();
    }
    
    private void AnalyzeDisk()
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
                throw new Exception("Возникла проблема с диском.");
            }
        }

        Drives = new ObservableCollection<Drive>(drives);
    }

    [RelayCommand]
    private void Update()
    {
        AnalyzeDisk();
    }
}