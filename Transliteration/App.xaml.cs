using System.Windows;
using Transliteration.Tools;

namespace Transliteration
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            LoggerClass Log = new LoggerClass();
        }
    }
}
