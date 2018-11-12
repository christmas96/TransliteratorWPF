using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Transliteration.Managers;
using Transliteration.Tools;
using Transliteration.Models;
using static Transliteration.Properties.Resources;
using System.Collections.Generic;
using NLog;
using System;
using System.Windows;

namespace Transliteration.ViewModels
{
    internal class TranslitViewModels : INotifyPropertyChanged
    {
        private ICommand _translitCommand;
        private ICommand _historyCommand;
        private ICommand _logOutCommand;
        private ICommand _closeCommand;
        private string _enterText = string.Empty;
        private string _translitText = string.Empty;
        private List<Translit> _translits;
        private static Logger Log = LogManager.GetCurrentClassLogger();

        public string TranslitLabelText { get => "Your Text"; }
        public string ResultLabelText { get => "Result Text"; }

        public List<Translit> Translits
        {
            get => _translits;
            set
            {
                _translits = value;
                OnPropertyChanged();
            }
        }

        public string EnterText
        {
            get { return _enterText; }
            set
            {
                _enterText = value;
                OnPropertyChanged();
            }
        }

        public string TranslitText
        {
            get { return _translitText; }
            set
            {
                _translitText = value;
                OnPropertyChanged();
            }
        }

        public ICommand TranslitCommand
        {
            get { return _translitCommand ?? (_translitCommand = new RelayCommand<object>(TranslitExecute)); }
        }

        public ICommand HistoryCommand
        {
            get { return _historyCommand ?? (_historyCommand = new RelayCommand<object>(HistoryExecute)); }
        }

        public ICommand LogOutCommand
        {
            get { return _logOutCommand ?? (_logOutCommand = new RelayCommand<object>(LogOutExecute)); }
        }

        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseExecute));
            }
        }

        internal TranslitViewModels()
        {
        }

        private async void TranslitExecute(object obj)
        {
            if(EnterText == string.Empty)
            {
                MessageBox.Show("Empty text! Enter some text");
                return;
            }
            TranslitText = await TranslitQuery(EnterText);
            var Translit = new Translit(EnterText, TranslitText);
            DBManager.AddTranslit(Translit);
            Translits = DBManager.GetTranslitsByUserId(StationManager.CurrentUser.Id);
            Log.Trace("User enter text was translited and write to translits history.");
        }

        private async Task<string> TranslitQuery(string text)
        {
            LoaderManager.Instance.ShowLoader();
            string translit = string.Empty;
            var result = await Task.Run(() =>
            {
                try
                {
                    translit = TranslitDictionary.Front(text);
                    Log.Trace("Entered text finish to translit.");
                }
                catch(Exception e)
                {
                    Log.Error("Error while translit: " + e.ToString());
                    return false;
                }
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result) return translit;
            return string.Empty;
        }

        private async void HistoryExecute(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    Log.Trace("User ask DB for own translits.");
                    Translits = DBManager.GetTranslitsByUserId(StationManager.CurrentUser.Id);
                    Log.Trace("DB answer successful for asking about current user translits.");
                }
                catch(Exception e)
                {
                    Log.Error("Error while get translit history: " + e.ToString());
                    return false;
                }
                return true;
            });
            LoaderManager.Instance.HideLoader();
        }

        private async void LogOutExecute(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    Log.Trace("User want to log out.");
                    Log.Trace("Clear current user for auto login.");
                    StationManager.RemoveCurrentUser();                   
                    Log.Trace("Now another user can Sign In.");
                }
                catch (Exception e)
                {
                    Log.Error("Error while user log out: " + e.ToString());
                    return false;
                }
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if(result) NavigationManager.Instance.Navigate(ModesEnum.SignIn);
        }

        private void CloseExecute(object obj)
        {
            Log.Trace("User close app.");
            StationManager.CloseApp();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        internal virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            Log.Trace("Change value of {0} property.", propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
