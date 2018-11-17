using System.ComponentModel;
using System.Windows;

namespace Transliteration.Tools
{
    public interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsEnabled { get; set; }
    }
}