using Transliteration.Managers;
using Transliteration.Tools;
using Transliteration.ViewModels;

namespace Transliteration.Views
{
    /// <summary>
    /// Логика взаимодействия для SignInView.xaml
    /// </summary>
    public partial class SignInView : IHaveSignInPass
    {
        private DBManager _manager;

        public SignInView()
        {
            InitializeComponent();
            var signInViewModel = new SignInViewModel();
            DataContext = signInViewModel;
            _manager = new DBManager();
        }

        public System.Security.SecureString SignInPassword
        {
            get
            {
                return pwdBox.SecurePassword;
            }
        }
    }
}