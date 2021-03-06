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
using MySql.Data.MySqlClient;

namespace FinalTestdatbase.Droid
{
    [Activity(Label = "SecondRegister")]
    public class SecondRegister : Activity

        
    {
        private TextView TextView1;
        private Button next;
        private EditText mail, mailconfirmation;

        UserSessionManagement session = new UserSessionManagement();
        private string name, password, email;

        ISharedPreferences pref;
        ISharedPreferencesEditor editor;
        Context _context;

        private static string PREFER_NAME = "AndroidExamplePref";
        public static string KEY_NAME = "name";
        public static string KEY_EMAIL = "email";
        public static string KEY_PASSWORD = "password";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SecondRegister);

            mail = FindViewById<EditText>(Resource.Id.mail);
            mailconfirmation = FindViewById<EditText>(Resource.Id.mailconfirmation);

            TextView1 = FindViewById<TextView>(Resource.Id.TextView1);

            next = FindViewById<Button>(Resource.Id.next);
            session = new UserSessionManagement(Application.Context);

            next.Click += Next_Click;
        }

        private void Next_Click(object sender, EventArgs e)
        { 
            if(mail.Text == mailconfirmation.Text)
            {
                if (session.checkLogin())
                    Finish();

                Dictionary<string, string> user = session.getUserDetails();
                string name = user[UserSessionManagement.KEY_NAME];
                string password = user[UserSessionManagement.KEY_PASSWORD];

                MySqlConnection con = new MySqlConnection("Server=cl1-sql22.phpnet.org;Port=3306;database=yzi38822; User Id=yzi38822;Password=M0kTZX33pyO6;");
                con.Open();

                editor.PutString(KEY_EMAIL, mail.Text);
                

                // string register = "UPDATE members SET mail = '" + mail.Text + "' where user = '" + name + "';";
                //MySqlCommand cmd2 = new MySqlCommand(register, con);
                //cmd2.ExecuteNonQuery();
                //StartActivity(typeof(ThirdRegister));

                TextView1.Text = name;

            } else
            {
                TextView1.Text = "Nop";
            }
            
        }
    }
}