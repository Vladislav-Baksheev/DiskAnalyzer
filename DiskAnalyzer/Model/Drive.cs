using CommunityToolkit.Mvvm.ComponentModel;

namespace DiskAnalyzer.Model;

public partial class Drive : ObservableObject
{
    [ObservableProperty] 
    private string _driveName;

    [ObservableProperty] 
    private double _totalSize;
    [ObservableProperty]
    private double _usedSize;
    [ObservableProperty] 
    private double _freeSize;
    [ObservableProperty] 
    private int _usagePercent;
}