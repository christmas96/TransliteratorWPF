﻿using System.Windows;
using Transliteration.Tools;

namespace Transliteration.Managers
{
    internal class LoaderManager
    {
        private static readonly object Lock = new object();
        private static LoaderManager _instance;

        internal static LoaderManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                lock (Lock)
                {
                    return _instance = new LoaderManager();
                }
            }
        }

        private ILoaderOwner _loaderOwner;

        internal void Initialize(ILoaderOwner loaderOwner)
        {
            _loaderOwner = loaderOwner;
        }

        internal void ShowLoader()
        {
            _loaderOwner.LoaderVisibility = Visibility.Visible;
            _loaderOwner.IsEnabled = false;

        }

        internal void HideLoader()
        {
            _loaderOwner.LoaderVisibility = Visibility.Hidden;
            _loaderOwner.IsEnabled = true;
        }
    }
}

