using System;
using Transliteration.Views;

namespace  Transliteration.Tools
{
    public enum ModesEnum
    {
        SignIn,
        SingUp,
        Translit
    }

    public class NavigationModel
    {
        private IContentWindow _content;
        private SignInView _signInView;
        private SignUpView _signUpView;
        private TranslitView _mainView;

        public NavigationModel(IContentWindow Content)
        {
            _content = Content;
        }

        public void Navigate(ModesEnum mode)
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