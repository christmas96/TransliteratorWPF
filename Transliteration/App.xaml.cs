﻿using Transliteration.Managers;
using System.Windows;

namespace Transliteration
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            LoggerClass log = new LoggerClass();
        }
    }
}
