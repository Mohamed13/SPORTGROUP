using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FinalTestdatbase.Droid
{
    [Activity(Label = "UserSessionManagement")]
    public class UserSessionManagement : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            
        }

        ISharedPreferences pref;
        ISharedPreferencesEditor editor;
        Context _context;
        int PRIVATE_MODE = 0;

        private static string PREFER_NAME = "AndroidExamplePref";
        private static string IS_USER_LOGIN = "IsUserLoggedIn";
        public static string KEY_NAME = "name";
        public static string KEY_EMAIL = "email";

        public UserSessionManagement(Context context)
        {
            this._context = context;
            pref = _context.GetSharedPreferences(PREFER_NAME, 0);
            editor = pref.Edit();

        }

        public UserSessionManagement()
        {

        }

        //Create login session
        public void createUserLoginSession(string name, string email)
        {
            // Storing login value as TRUE
            editor.PutBoolean(IS_USER_LOGIN, true);

            // Storing name in pref
            editor.PutString(KEY_NAME, name);

            // Storing email in pref
            editor.PutString(KEY_EMAIL, email);

            // commit changes
            editor.Commit();
        }

        public Boolean checkLogin()
        {
            // Check login status
            if (!this.isUserLoggedIn())
            {

                // user is not logged in redirect him to Login Activity
                Intent i = new Intent(_context, typeof(LoginActivity));

                // Closing all the Activities from stack
                i.AddFlags(ActivityFlags.ClearTop);

                // Add new Flag to start new Activity
                i.AddFlags(ActivityFlags.NewTask);

                // Staring Login Activity
                _context.StartActivity(i);
                 
                return true;
            }
            return false;
        }

        public bool isUserLoggedIn()
        {
            return pref.GetBoolean(IS_USER_LOGIN, false);
        }

        public Dictionary<string, string> getUserDetails()
{

    //Use hashmap to store user credentials
    Dictionary<string, string> user = new Dictionary<string, string>();


            // user name
            user[KEY_NAME] = pref.GetString(KEY_NAME, null);

            // user email id
            user[KEY_EMAIL] = pref.GetString(KEY_EMAIL, null);
    
            // return user
            return user;
}

    /**
     * Clear session details
     * */
    public void logoutUser()
{

    // Clearing all user data from Shared Preferences
    editor.Clear();
    editor.Commit();

    // After logout redirect user to Login Activity
    Intent i = new Intent(_context, typeof(LoginActivity));

            // Closing all the Activities
            i.AddFlags(ActivityFlags.ClearTop);

            // Add new Flag to start new Activity
            i.AddFlags(ActivityFlags.NewTask);
             
            // Staring Login Activity
            _context.StartActivity(i);
        }
         


    }
}