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
    [Activity(Label = "Activity1")]
    public class EventCreation : Activity
    {
        private Spinner spinner;
        private Button valider;
        private EditText title, owner, city, sport;


        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EventCreation);

            spinner = FindViewById<Spinner>(Resource.Id.spinner);

            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.sport, Android.Resource.Layout.SimpleSpinnerDropDownItem);
            adapter.SetDropDownViewResource(Resource.Layout.support_simple_spinner_dropdown_item);

            valider = FindViewById<Button>(Resource.Id.valider);

            valider.Click += Valider_Click;

            title = FindViewById<EditText>(Resource.Id.title);
            owner = FindViewById<EditText>(Resource.Id.owner);
            city = FindViewById<EditText>(Resource.Id.city);

        }

        private void Valider_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(title.Text))
            {
                //AlertDialog.Builder alert = new AlertDialog.Builder(;
                //alert.SetTitle("Confirmation");
                //alert.SetMessage("Voulez vous enregistrer les modifications ?");
                title.Text = "vide";
            } else
            {
                if(String.IsNullOrEmpty(owner.Text))
                {
                    owner.Text = "vide";
                } else
                {
                    if (String.IsNullOrEmpty(city.Text))
                    {
                        city.Text = "vide";
                    } else
                    {
                        MySqlConnection con2 = new MySqlConnection("Server=cl1-sql22.phpnet.org;Port=3306;database=yzi38822; User Id=yzi38822;Password=M0kTZX33pyO6;");
                        con2.Open();
                        string register = "INSERT INTO evenements (id,nom,createur,lieu) VALUES ('','" + title.Text + "','" + owner.Text + "', '" + city.Text + "');";
                        MySqlCommand cmd2 = new MySqlCommand(register, con2);
                        cmd2.ExecuteNonQuery();
                        StartActivity(typeof(Event));
                    }
                }
            }

        }
    }
}