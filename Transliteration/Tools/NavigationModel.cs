﻿using System;
using System.Windows.Controls;
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
        private Page _currentPage;

        public Page CurrentPage
        {
            get => _currentPage;
            set => _currentPage = value;
        }

        public NavigationModel(IContentWindow Content)
        {
            _content = Content;
        }

        public void Navigate(ModesEnum mode)
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