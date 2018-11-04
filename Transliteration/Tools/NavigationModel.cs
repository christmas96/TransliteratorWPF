using System;
using System.Windows.Controls;
using Transliteration.Views;

namespace  Transliteration.Tools
{
    internal enum ModesEnum
    {
        SignIn,
        SingUp,
        Translit
    }

    internal class NavigationModel
    {
        private IContentWindow _content;
        private SignInView _signInView;
        private SignUpView _signUpView;
        private TranslitView _mainView;
        private Page _currentPage;

        internal Page CurrentPage
        {
            get => _currentPage;
            set => _currentPage = value;
        }

        internal NavigationModel(IContentWindow Content)
        {
            _content = Content;
        }

        internal void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.SignIn:
                    _currentPage = _signInView = new SignInView();
                    _content.ContentControl.Content = _currentPage;
                    break;
                case ModesEnum.SingUp:
                    _currentPage = _signUpView = new SignUpView();
                    _content.ContentControl.Content = _currentPage;
                    break;
                case ModesEnum.Translit:
                    _currentPage = _mainView = new TranslitView();
                    _content.ContentControl.Content = _currentPage;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

    }
}