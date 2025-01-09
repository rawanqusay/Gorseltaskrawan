﻿using Firebase.Auth;
using Firebase.Auth.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorseltaskrawan.Models
{
    internal class FireBaseServices
    {
        static string project_id = "finalodev-8b721";
        static string ApiKey = "AIzaSyCpYWfue9TCTEYYqpvYKgXR_uA92QAzkns";
        static string AuthDomain = $"{project_id}.firebaseapp.com";

        static FirebaseAuthConfig config = new FirebaseAuthConfig()
        {
            ApiKey = ApiKey,
            AuthDomain = AuthDomain,
            Providers = new[] { new EmailProvider() }
        };

        public static async Task<User> Login(string email, string pass)
        {
            try
            {
                var client = new FirebaseAuthClient(config);
                var res = await client.SignInWithEmailAndPasswordAsync(email, pass);
                return res.User;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static async Task<User> Register(string dispname, string email, string pass)
        {

            try
            {
                var client = new FirebaseAuthClient(config);
                var res = await client.CreateUserWithEmailAndPasswordAsync(email, pass, dispname);
                return res.User;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
