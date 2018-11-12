using NLog;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Transliteration.Managers;
using Transliteration.Models;
using Transliteration.Tools;
using static Transliteration.Properties.Resources;

namespace Transliteration.ViewModels
{
    internal class SignUpViewModel
    {

        internal static Logger Log = LogManager.GetCurrentClassLogger();

        private string _login;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _email;
        private static Regex _regex = CreateRegEx();

        public string LoginText { get => "Login: "; }
        public string PasswordText { get => "Password: "; }
        public string FirstNameText { get => "First Name: "; }
        public string LastNameText { get => "Last Name: "; }
        public string EmailText { get => "Email: "; }

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }

        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        
        private ICommand _closeCommand;
        private ICommand _signInCommand;
        private ICommand _signUpCommand;

        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseExecute));
            }
        }
        public ICommand SignUpCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(SignUpExecute, SignUpCanExecute));
            }
        }
        public ICommand SignInCommand
        {
            get
            {
                return _signInCommand ?? (_signInCommand = new RelayCommand<object>(SignInExecute));
            }
        }

        internal SignUpViewModel()
        {
        }

        private async void SignUpExecute(object obj)
        {            
            Log.Info("User try to Sign up.");
            var passwordContainer = obj as PasswordBox;
            if (passwordContainer != null)
            {
                var pass = passwordContainer.Password;
                _password = pass;
            }
            else
            {
                Log.Warn("User not enter password.");
                MessageBox.Show(EmptyPassword);
                return;
            }

            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    if (!EmailIsValid(_email))
                    {
                        Log.Warn("User enter invalid email.");
                        MessageBox.Show(String.Format(SignUp_EmailIsNotValid, _email));
                        return false;
                    }
                    if (DBManager.UserExists(_login))
                    {
                        Log.Warn("Such user already exist.");
                        MessageBox.Show(String.Format(SignUp_UserAlreadyExists, _login));
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("Problem with validating data: " + ex.ToString());
                    MessageBox.Show(String.Format(SignUp_FailedToValidateData, Environment.NewLine, ex.Message));
                    return false;
                }
                try
                {
                    Log.Info("Try to add new user.");
                    var user = new User(_firstName, _lastName, _email, _login, _password);
                    DBManager.AddUser(user);
                    StationManager.CurrentUser = user;
                    StationManager.AddCurrentUser();
                }
                catch (Exception ex)
                {
                    Log.Error("Promlem with creating new user: " + ex.ToString());
                    MessageBox.Show(String.Format(SignUp_FailedToCreateUser, Environment.NewLine,
                        ex.Message));
                    return false;
                }
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result)
            {
                MessageBox.Show(String.Format(SignUp_UserSuccessfulyCreated, _login));
                NavigationManager.Instance.Navigate(ModesEnum.Translit);
            }           
        }

        private bool EmailIsValid(string email)
        {
            if (email == null)
            {
                return false;
            }

            if (_regex != null)
            {
                return email != null && _regex.Match(email).Length > 0;
            }
            else
            {
                int atCount = 0;

                foreach (char c in email)
                {
                    if (c == '@')
                    {
                        atCount++;
                    }
                }

                return (email != null
                        && atCount == 1
                        && email[0] != '@'
                        && email[email.Length - 1] != '@');
            }
        }

        private static Regex CreateRegEx()
        {
            const string pattern = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";
            const RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;
            TimeSpan matchTimeout = TimeSpan.FromSeconds(2);

            try
            {
                if (AppDomain.CurrentDomain.GetData("REGEX_DEFAULT_MATCH_TIMEOUT") == null)
                {
                    return new Regex(pattern, options, matchTimeout);
                }
            }
            catch
            {
                Log.Trace("Error while create RegEx.");
            }
            return new Regex(pattern, options);
        }

        private bool SignUpCanExecute(object obj)
        {
            return !String.IsNullOrEmpty(_login) &&
                   !String.IsNullOrEmpty(_firstName) &&
                   !String.IsNullOrEmpty(_lastName) &&
                   !String.IsNullOrEmpty(_email);
        }

        private void SignInExecute(object obj)
        {
            Log.Trace("User back to Sign In page.");
            NavigationManager.Instance.Navigate(ModesEnum.SignIn);
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
