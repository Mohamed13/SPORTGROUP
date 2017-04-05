using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Data;
using MySql.Data.MySqlClient;


namespace FinalTestdatbase.Droid

{

    [Activity(Theme = "@android:style/Theme.Material.Light",
          Label = "MyApp", MainLauncher = true, Icon = "@drawable/icon")]
    // [Activity (Label = "FinalTestdatbase.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        UserSessionManagement session = new UserSessionManagement();
        public Button button1;
        private TextView textview1, textview2;
        

        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate (bundle);
            SetContentView(Resource.Layout.Home);
            session = new UserSessionManagement(Application.Context);

            button1 = FindViewById<Button>(Resource.Id.connect);
            textview1 = FindViewById<TextView>(Resource.Id.TextView1);
            textview2 = FindViewById<TextView>(Resource.Id.textView2);

            button1.Click += Button1_Click;
            

            if (session.checkLogin())
                Finish();

            Dictionary<string, string> user = session.getUserDetails();

            string name = user[UserSessionManagement.KEY_NAME];
            string email = user[UserSessionManagement.KEY_EMAIL];

            MySqlConnection con = new MySqlConnection("Server=cl1-sql22.phpnet.org;Port=3306;database=yzi38822; User Id=yzi38822;Password=M0kTZX33pyO6;");

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string query = "SELECT user,password FROM members WHERE user = '" + name + "'";

            MySqlDataReader reader = new MySqlCommand(query, con).ExecuteReader();

            if (reader.Read())
            {
                new AlertDialog.Builder(this)
                .SetMessage("Bienvenue " + (reader["user"].ToString()))
                .Show();
                StartActivity(typeof(Profil));
            }
            else
            {
                reader.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(LoginActivity));
        }
    }
}


