using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Transliteration.Managers;
using Transliteration.Models;
using Transliteration.Tools;
using static Transliteration.Properties.Resources;
using System.Windows.Controls;
using NLog;
using System.Threading.Tasks;

namespace Transliteration.ViewModels
{
    internal class SignInViewModel : INotifyPropertyChanged
    {
        internal static Logger Log = LogManager.GetCurrentClassLogger();

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


        internal SignInViewModel()
        {
        }

        private void SignUpExecute(object obj)
        {
            Log.Trace("User go to Sign Up page.");
            NavigationManager.Instance.Navigate(ModesEnum.SingUp);
        }

        private async void SignInExecute(object obj)
        {
            var passwordContainer = obj as PasswordBox;
            if (passwordContainer != null)
            {
                var pass = passwordContainer.Password;
                _password = pass;
                if (_password == string.Empty)
                {
                    Log.Error("User not enter password.");
                    MessageBox.Show(EmptyPassword);
                    return;
                }
            }
            else
            {
                Log.Error("User not enter password.");
                MessageBox.Show(EmptyPassword);
                return;
            }
            
                LoaderManager.Instance.ShowLoader();
                var result = await Task.Run(() =>
                {
                    User user;
                    try
                    {
                        user = DBManager.GetUserByLogin(_login);
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Problem to get user: " + ex.ToString());
                        MessageBox.Show(String.Format(SignIn_FailedToGetUser, Environment.NewLine,
                            ex.Message));
                        return false;
                    }
                    if (user == null)
                    {
                        Log.Info("Such user doesn't exist in DB.");
                        MessageBox.Show(String.Format(SignIn_UserDoesntExist, _login));
                        return false;
                    }
                    try
                    {
                        if (user.CheckPassword(user.Password, _password) == false)
                        {
                            Log.Trace("User enter wrong password.");
                            MessageBox.Show(SignIn_WrongPassword);
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Problem with password: " + ex.ToString());
                        MessageBox.Show(String.Format(SignIn_FailedToValidatePassword, Environment.NewLine,
                             ex.Message));
                        return false;
                    }
                    StationManager.CurrentUser = user;
                    StationManager.AddCurrentUser();
                    return true;
                }
               );
                LoaderManager.Instance.HideLoader();
                if (result)
                {
                    Log.Trace("User go to Translit page.");
                    NavigationManager.Instance.Navigate(ModesEnum.Translit);
                }
            }

            private bool SignInCanExecute(object obj)
            {
                return !String.IsNullOrWhiteSpace(_login);
            }

            private void CloseExecute(object obj)
            {
                Log.Trace("User close app.");
                StationManager.CloseApp();
            }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
