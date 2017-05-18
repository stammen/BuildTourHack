//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using System;
using Caliburn.Micro;
using Microsoft.Knowzy.Authentication;

namespace Microsoft.Knowzy.WPF.ViewModels
{
    public class LoginViewModel : Screen
    {
        private readonly IAuthenticationService _authenticationService;
        private string _userName;
        private string _password;

        public LoginViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public string UserName
        {
            get => _userName;
            set
            {
                if (value == _userName) return;
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public void DoLogin()
        {
            if (string.IsNullOrWhiteSpace(UserName)) return;
            try
            {
                _authenticationService.Login(UserName, Password);
                Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Password = string.Empty;
            }
        }

        public void Close()
        {
            UserName = string.Empty;
            Password = string.Empty;
            TryClose();
        }
    }
}
