using System.Windows.Controls;
using Transliteration.ViewModels;

namespace Transliteration.Views
{
    /// <summary>
    /// Логика взаимодействия для TranslitView.xaml
    /// </summary>
    public partial class TranslitView : Page
    {
        internal TranslitView()
        {
            InitializeComponent();
            var TranslitViewModel = new TranslitViewModels();
            DataContext = TranslitViewModel;
        }
    }
}
