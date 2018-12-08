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
        public SignInView()
        {
            InitializeComponent();
            var signInViewModel = new SignInViewModel();
            DataContext = signInViewModel;
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