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
    [Activity(Label = "ThirdRegister")]
    public class ThirdRegister : Activity
    {
        UserSessionManagement session = new UserSessionManagement();
        private EditText ville, age;
        private String user, email, password;
        public Button Enregistrer { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            session = new UserSessionManagement(Application.Context);
            age = FindViewById<EditText>(Resource.Id.age);
            ville = FindViewById<EditText>(Resource.Id.ville);
            Enregistrer = FindViewById<Button>(Resource.Id.enregistrer);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ThirdRegister);

            Enregistrer.Click += Enregister_Click;      
        }

        private void Enregister_Click(object sender, EventArgs e)
        {
            if (session.checkLogin())
                Finish();

            Dictionary<string, string> user = session.getUserDetails();
            string name = user[UserSessionManagement.KEY_NAME];
            string email = user[UserSessionManagement.KEY_EMAIL];
            string password = user[UserSessionManagement.KEY_PASSWORD];

            MySqlConnection con = new MySqlConnection("Server=cl1-sql22.phpnet.org;Port=3306;database=yzi38822; User Id=yzi38822;Password=M0kTZX33pyO6;");
            con.Open();
            string register = "INSERT INTO members (id,user,password,email,city) VALUES ('','" + user + "','" + password + "','" + email + "','" + ville.Text + "');"; ;
            MySqlCommand cmd2 = new MySqlCommand(register, con);
            cmd2.ExecuteNonQuery();
            StartActivity(typeof(ThirdRegister));
        }
    }
}