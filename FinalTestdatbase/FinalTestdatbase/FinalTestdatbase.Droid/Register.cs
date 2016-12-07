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
using System.Data;
using MySql.Data.MySqlClient;

namespace FinalTestdatbase.Droid
{
    [Activity(Label = "Activity1")]
    public class Register : Activity
    {
        private EditText user, password;
        private TextView result;
        private Button register, buttonconnexion;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Register);

            user = FindViewById<EditText>(Resource.Id.user);
            password = FindViewById<EditText>(Resource.Id.password);
            register = FindViewById<Button>(Resource.Id.register);
            buttonconnexion = FindViewById<Button>(Resource.Id.buttonconnexion);
            result = FindViewById<TextView>(Resource.Id.result);

            register.Click += register_Click;
            buttonconnexion.Click += buttonconnexion_Click;

        }

        private void register_Click(object sender, EventArgs e)
        {

            MySqlConnection con2 = new MySqlConnection("Server=sql7.freemysqlhosting.net;Port=3306;database=sql7148210; User Id=sql7148210;Password=msvYc7aw45;");

            try
            {
                if (con2.State == ConnectionState.Closed)
                {
                    con2.Open();
                }
            }
            catch (MySqlException ex)
            {
                result.Text = ex.ToString();
            }
         
            string chercheruser = "SELECT user,password FROM members WHERE user = '" + user.Text + "'";
            MySqlDataReader reader2 = new MySqlCommand(chercheruser, con2).ExecuteReader();

            if (reader2.Read())
            {
                result.Text = "Ce nom d'utilisateur existe déjà";
                reader2.Close();
            }
            else
            {
                reader2.Close();
                string register = "INSERT INTO members (id,user,password) VALUES ('','" + user.Text + "','" + password.Text + "');";
                MySqlCommand cmd2 = new MySqlCommand(register, con2);
                cmd2.ExecuteNonQuery();
                result.Text = "Votre compte a été créé !";  
            }
            reader2.Close();
        }

        private void buttonconnexion_Click(object sender, EventArgs e)
        {

            StartActivity(typeof(MainActivity));
        }

    }
}