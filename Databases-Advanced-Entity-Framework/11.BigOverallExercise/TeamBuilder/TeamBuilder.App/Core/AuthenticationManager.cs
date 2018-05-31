﻿namespace TeamBuilder.App.Core
{
    using Models;
    using System;
    using Utilities;

    public static class AuthenticationManager
    {
        private static User currentUser;

        public static void LoginUser(User user)
        {
            if (IsAuthenticated())
            {
                throw new InvalidOperationException("You should logout first!");
            }

            currentUser = user;
        }
        public static void Logout()
        {   
            if (!IsAuthenticated())
            {
                throw new InvalidOperationException("You should login first!");
            }

            currentUser = null;
        }
        public static void Authorize()
        {
            if (currentUser==null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
            }
        }
        public static bool IsAuthenticated()
        {
            return currentUser != null;
        }
        public static User GetCurrentUser()
        {
            return currentUser;
        }
    }
}