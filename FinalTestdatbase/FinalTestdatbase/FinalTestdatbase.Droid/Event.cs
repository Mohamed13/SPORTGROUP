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
using Android.Graphics;

namespace FinalTestdatbase.Droid
{
    [Activity(Label = "Event")]
    public class Event : Activity
    {
        public TextView textview1, textview2;
        public Button button1;
        List<Button> tabButton = new List<Button>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Event);
            textview1 = FindViewById<TextView>(Resource.Id.textView1);
            button1 = FindViewById<Button>(Resource.Id.button1);
            textview2 = FindViewById<TextView>(Resource.Id.textView2);

            MySqlConnection con = new MySqlConnection("Server=cl1-sql22.phpnet.org;Port=3306;database=yzi38822; User Id=yzi38822;Password=M0kTZX33pyO6;");
            

            string queryEvenementsTrue = "SELECT * FROM evenements WHERE status='1'";
            MySqlDataReader reader = new MySqlCommand(queryEvenementsTrue, con).ExecuteReader();
            con.Open();
            if (reader.Read())
            {
                while(reader.Read())
                {
                    //int i = 0;
                    Button button = new Button(Application.Context);
                    button.Text = reader["nom"].ToString();
                    button.Click += showEvents(reader["nom"]);
                    tabButton.Add(button);
                }
            }
            else
            {
                textview1.Text = "Aucun évenements disponible, revenez plus tard.";
            }
            reader.Close();

            con.Close();

            

            //var i = 0;
            //for(i=1; i<=15; i++ ) { 
            //    string query = "SELECT nom FROM evenements where id = " + i + " ";

            //    MySqlDataReader reader = new MySqlCommand(query, con).ExecuteReader();

            //    if (reader.Read())
            //    {

            //    }

        }

        private EventHandler showEvents(object v)
        {
            StartActivity(typeof(Event));
            throw new NotImplementedException();
        }

    }    
  }
