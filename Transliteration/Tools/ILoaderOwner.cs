using System.ComponentModel;
using System.Windows;

namespace Transliteration.Tools
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {

        Visibility LoaderVisibility { get; set; }
        bool IsEnabled { get; set; }
    }
}