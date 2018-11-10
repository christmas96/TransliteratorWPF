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

        internal NavigationModel(IContentWindow Content)
        {
            _content = Content;
        }

        internal void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.SignIn:
                    _content.ContentControl.Content = _signInView = new SignInView();
                    break;
                case ModesEnum.SingUp:
                    _content.ContentControl.Content = _signUpView = new SignUpView();
                    break;
                case ModesEnum.Translit:
                    _content.ContentControl.Content = _mainView = new TranslitView();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

    }
}