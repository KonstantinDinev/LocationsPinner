﻿using System;
using System.ComponentModel;
using TravelRecord.Model;

namespace TravelRecord
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("Email");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("Password");
            }
        }

        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("ConfirmPassword");
            }
        }

        private User user;

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public RegisterCommand RegisterCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterViewModel()
        {
            RegisterCommand = new RegisterCommand(this);
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Register(User user)
        {
            User.Register(user);
        }
    }
}
