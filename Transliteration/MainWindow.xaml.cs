using NLog;
using System.Windows.Controls;
using Transliteration.Managers;
using Transliteration.Tools;
using Transliteration.ViewModels;

namespace Transliteration
{
    public partial class MainWindow : IContentWindow
    {
        private DBManager _manager;
        public static Logger log = LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();
            var navigationModel = new NavigationModel(this);
            NavigationManager.Instance.Initialize(navigationModel);
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;
            _manager = new DBManager();
            if (StationManager.CheckCurrentUser())
            {
                StationManager.GetCurrentUser();
                navigationModel.Navigate(ModesEnum.Translit);
                log.Trace("Поепередньо залогінений користувач увійшов до застосуку.");
            }
            else
            {
                navigationModel.Navigate(ModesEnum.SignIn);
                log.Trace("Поепередньо залогінений користувач відсутній.");
            }
        }

        public ContentControl ContentControl
        {
            get { return _content; }
        }
    }
}
