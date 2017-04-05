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
        public EditText user, password, passwordconfirmation;
        private TextView result;
        private Button register, buttonconnexion;
        UserSessionManagement session = new UserSessionManagement();

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
            SetContentView(Resource.Layout.Register);

            user = FindViewById<EditText>(Resource.Id.user);
            password = FindViewById<EditText>(Resource.Id.password);
            register = FindViewById<Button>(Resource.Id.register);
            buttonconnexion = FindViewById<Button>(Resource.Id.buttonconnexion);
            result = FindViewById<TextView>(Resource.Id.result);
            passwordconfirmation = FindViewById<EditText>(Resource.Id.passwordconfirmation);

            session = new UserSessionManagement(Application.Context);

            register.Click += register_Click;
            buttonconnexion.Click += buttonconnexion_Click;

        }

        private void register_Click(object sender, EventArgs e)
        {

            // pref = _context.GetSharedPreferences(PREFER_NAME, 0);
            // editor = pref.Edit();

            MySqlConnection con2 = new MySqlConnection("Server=cl1-sql22.phpnet.org;Port=3306;database=yzi38822; User Id=yzi38822;Password=M0kTZX33pyO6;");

                    con2.Open();
                   
            string chercheruser = "SELECT user,password FROM members WHERE user = '" + user.Text + "'";
            MySqlDataReader reader2 = new MySqlCommand(chercheruser, con2).ExecuteReader();

            if (password.Text.Length < 3)
            {
                result.Text = "Le mot de passe doit comporter plus de 3 caractères";
            }
            else
            {
                if (password.Text != passwordconfirmation.Text)
                {
                    result.Text = "Les mots de passes ne correspondent pas";
                }
                else
                {
                    if (reader2.Read())
                    {
                        result.Text = "Ce nom d'utilisateur existe déjà";
                        reader2.Close();
                    }
                    else
                    {
                        reader2.Close();

                        editor.PutString(KEY_NAME, user.Text);
                        editor.PutString(KEY_PASSWORD, password.Text);
                        editor.Commit();

                        //string register = "INSERT INTO members (id,user,password) VALUES ('','" + user.Text + "','" + password.Text + "');";
                        //MySqlCommand cmd2 = new MySqlCommand(register, con2);
                        //cmd2.ExecuteNonQuery();
                        //session.createUserLoginSession(user.Text, password.Text);
                        StartActivity(typeof(SecondRegister));
                    }
                    reader2.Close();
                }

            }
        }
        private void buttonconnexion_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

    }
}