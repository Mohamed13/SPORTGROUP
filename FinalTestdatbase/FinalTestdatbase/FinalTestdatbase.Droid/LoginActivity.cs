using System;

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

    [Activity(Label = "Activity1")]
    public class LoginActivity : Activity
 
    {
        private EditText editText1, editText2;
        private Button button3, buttonregister, profil;
        private TextView textView3, textView4, textView5, textView6;
        UserSessionManagement session = new UserSessionManagement();
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            editText1 = FindViewById<EditText>(Resource.Id.editText1);
            editText2 = FindViewById<EditText>(Resource.Id.editText2);
            profil = FindViewById<Button>(Resource.Id.profil);
            button3 = FindViewById<Button>(Resource.Id.button3);
            buttonregister = FindViewById<Button>(Resource.Id.buttonregister);
            textView3 = FindViewById<TextView>(Resource.Id.textView3);
            textView4 = FindViewById<TextView>(Resource.Id.textView4);
            textView5 = FindViewById<TextView>(Resource.Id.textView5);
            textView6 = FindViewById<TextView>(Resource.Id.textView6);
            string var1 = FindViewById<EditText>(Resource.Id.editText1).Text;
            string var2 = FindViewById<EditText>(Resource.Id.editText2).Text;

            button3.Click += button3_Click;
            buttonregister.Click += Button_Click;
            profil.Click += Button_Click;

            session = new UserSessionManagement(Application.Context);

        }


        private void Button_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Register));
        }


        private void button3_Click(object sender, EventArgs e)
        {

            MySqlConnection con = new MySqlConnection("Server=cl1-sql22.phpnet.org;Port=3306;database=yzi38822; User Id=yzi38822;Password=M0kTZX33pyO6;");

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    textView3.Text = "Successfully connected";
                }
                else
                {
                    textView4.Text = "Connexion déjà établi";
                }
            }
            catch (MySqlException ex)
            {
                textView3.Text = ex.ToString();
            }

            string query = "SELECT user,password FROM members WHERE user = '" + editText1.Text + "' and password = '" + editText2.Text + "'";

            MySqlDataReader reader = new MySqlCommand(query, con).ExecuteReader();

            if (reader.Read())
            {
                textView5.Text = (reader["user"].ToString());
                textView6.Text = (reader["password"].ToString());
                reader.Close();
                session.createUserLoginSession(textView5.Text, textView6.Text);
                Intent i = new Intent(Application.Context, typeof(Profil));
                i.AddFlags(ActivityFlags.ClearTop);
                i.SetFlags(ActivityFlags.NewTask);
                StartActivity(i);
            }
            else
            {
                textView5.Text = "Aucun compte existant !";
                reader.Close();
            }
            reader.Close();
        }

        private void profil_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Profil));
        }
    }
}


