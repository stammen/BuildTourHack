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

namespace Microsoft.Knowzy.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public void Login(string name, string password)
        {
            // TODO: Develop this service
            UserLogged = name;
        }

        public void Logout()
        {
            // TODO: Develop this service
            UserLogged = string.Empty;
        }

        public string UserLogged { get; private set; }
    }
}
