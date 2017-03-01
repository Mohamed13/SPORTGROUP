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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Event);
            textview1 = FindViewById<TextView>(Resource.Id.textView1);
            button1 = FindViewById<Button>(Resource.Id.button1);
            textview2 = FindViewById<TextView>(Resource.Id.textView2);

            MySqlConnection con = new MySqlConnection("Server=cl1-sql22.phpnet.org;Port=3306;database=yzi38822; User Id=yzi38822;Password=M0kTZX33pyO6;");
            con.Open();

            //var i = 0;
            //for(i=1; i<=15; i++ ) { 
            //    string query = "SELECT nom FROM evenements where id = " + i + " ";

            //    MySqlDataReader reader = new MySqlCommand(query, con).ExecuteReader();

            //    if (reader.Read())
            //    {
                    
            //    }

                }
            }    
    }
