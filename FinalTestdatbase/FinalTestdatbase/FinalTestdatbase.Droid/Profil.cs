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
using System.Data;

namespace FinalTestdatbase.Droid
{
    [Activity(Label = "Profil")]
    public class Profil : Activity
    {
        private EditText pseudo, email, age, city, sport;
        private Button valider, accueil;

        UserSessionManagement session = new UserSessionManagement();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Profil);

            pseudo = FindViewById<EditText>(Resource.Id.pseudo);
            email = FindViewById<EditText>(Resource.Id.email);
            age = FindViewById<EditText>(Resource.Id.age);
            city = FindViewById<EditText>(Resource.Id.city);
            sport = FindViewById<EditText>(Resource.Id.sport);
            valider = FindViewById<Button>(Resource.Id.valider);
            accueil = FindViewById<Button>(Resource.Id.Accueil);

            valider.Click += Valider_Click;

            accueil.Click += Accueil_Click;

            session = new UserSessionManagement(Application.Context);

            if (session.checkLogin())
                Finish();

            Dictionary<string, string> user = session.getUserDetails();

            string name = user[UserSessionManagement.KEY_NAME];
            string password = user[UserSessionManagement.KEY_PASSWORD];


            MySqlConnection con = new MySqlConnection("Server=cl1-sql22.phpnet.org;Port=3306;database=yzi38822; User Id=yzi38822;Password=M0kTZX33pyO6;");

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string query = "SELECT * FROM members WHERE user = '" + name + "'";

            MySqlDataReader reader = new MySqlCommand(query, con).ExecuteReader();

            if (reader.Read())
            {
                pseudo.Text = (reader["user"].ToString());
                email.Text = (reader["mail"].ToString());
                // age.Text = (reader["birthday"].ToString());
                sport.Text = (reader["sport"].ToString());
                city.Text = (reader["city"].ToString());
                reader.Close();
            }
            else
            {
                sport.Text = "Erreur";
                reader.Close();
            }

        }

        private void Accueil_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Accueil));
        }

        private void Valider_Click(object sender, EventArgs e)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Confirmation");
            alert.SetMessage("Voulez vous enregistrer les modifications ?");
            alert.SetPositiveButton("Valider", (senderAlert, args) => {
                Toast.MakeText(this, "Changement effectué !", ToastLength.Short).Show();

                MySqlConnection con2 = new MySqlConnection("Server=cl1-sql22.phpnet.org;Port=3306;database=yzi38822; User Id=yzi38822;Password=M0kTZX33pyO6;");

                if (con2.State == ConnectionState.Closed)
                {
                    con2.Open();
                }

            });
            alert.SetNegativeButton("Annuler", (senderAlert, args) => {
                Toast.MakeText(this, "Modifications annulées !", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        private void recuperer_Click(object sender, EventArgs e)
        {
         
        }
    }
    }

