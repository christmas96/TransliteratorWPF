using Transliteration.Tools;
using Transliteration.ViewModels;

namespace Transliteration.Views
{
    /// <summary>
    /// Логика взаимодействия для SignUpView.xaml
    /// </summary>
    public partial class SignUpView : IHaveSignUpPass
    {
        internal SignUpView()
        {
            InitializeComponent();
            var signUpViewModel = new SignUpViewModel();
            DataContext = signUpViewModel;
        }

        public System.Security.SecureString SignUpPassword
        {
            get
            {
                return pwdBox.SecurePassword;
            }
        }
    }
}
