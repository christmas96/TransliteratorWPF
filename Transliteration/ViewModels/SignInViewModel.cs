﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Transliteration.Managers;
using Transliteration.Models;
using Transliteration.Tools;
using static Transliteration.Properties.Resources;
using System.Windows.Controls;
using Transliteration.Properties;
using NLog;

namespace Transliteration.ViewModels
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        public static Logger log = LogManager.GetCurrentClassLogger();

        public string LoginText { get => "Login: "; }
        public string PasswordText { get => "Password: "; }

        private string _password;
        private string _login;
        
        private ICommand _closeCommand;
        private ICommand _signInCommand;
        private ICommand _signUpCommand;

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        public ICommand CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseExecute)); }
        }
        public ICommand SignInCommand
        {
            get { return _signInCommand ?? (_signInCommand = new RelayCommand<object>(SignInExecute, SignInCanExecute)); }
        }
        public ICommand SignUpCommand
        {
            get { return _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(SignUpExecute)); }
        }
        

        public SignInViewModel()
        {
        }

        private void SignUpExecute(object obj)
        {
            log.Trace("User go to Sign Up page.");
            NavigationManager.Instance.Navigate(ModesEnum.SingUp);
        }

        private void SignInExecute(object obj)
        {
            var passwordContainer = obj as PasswordBox;
            if (passwordContainer != null)
            {
                var pass = passwordContainer.Password;
                _password = pass;
            }
            else
            {
                log.Error("User not enter password.");
                MessageBox.Show(EmptyPassword);
                return;
            }

            User user;
            try
            {
                user = DBManager.GetUserByLogin(_login);
            }
            catch (Exception ex)
            {
                log.Error("Problem to get user: " + ex.ToString());
                MessageBox.Show(String.Format(SignIn_FailedToGetUser, Environment.NewLine,
                    ex.Message));
                return;
            }
            if (user == null)
            {
                log.Info("Such user doesn't exist in DB.");
                MessageBox.Show(String.Format(SignIn_UserDoesntExist, _login));
                return;
            }
            try
            {
                if (user.CheckPassword(user.Password, _password) == false)
                {
                    log.Trace("User enter wrong password.");
                    MessageBox.Show(SignIn_WrongPassword);
                    return;
                }
            }
            catch (Exception ex)
            {
                log.Trace("Problem with password: " + ex.ToString());
                MessageBox.Show(String.Format(SignIn_FailedToValidatePassword, Environment.NewLine,
                     ex.Message));
                return;
            }
            StationManager.CurrentUser = user;
            StationManager.AddCurrentUser();
            log.Trace("User go to Translit page.");
            NavigationManager.Instance.Navigate(ModesEnum.Translit);
        }

        private bool SignInCanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_login);
        }

        private void CloseExecute(object obj)
        {
            log.Trace("User close app.");
            StationManager.CloseApp();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}