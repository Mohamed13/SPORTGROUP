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

namespace FinalTestdatbase.Droid
{
    [Activity(Label = "Accueil")]
    public class Accueil : Activity
    {

        private Button evenement, button1, deconnexion, btn_map;
        UserSessionManagement session = new UserSessionManagement();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Accueil);
            evenement = FindViewById<Button>(Resource.Id.evenement);
            button1 = FindViewById<Button>(Resource.Id.button1);
            deconnexion = FindViewById<Button>(Resource.Id.deconnexion);
            btn_map = FindViewById<Button>(Resource.Id.map_btn);

            session = new UserSessionManagement(Application.Context);

            btn_map.Click += map_btn_Click;
            evenement.Click += Evenement_Click;
            button1.Click += Button1_Click;
            deconnexion.Click += Deconnexion_Click;
        }

        private void map_btn_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(DisplayMap));
        }

        private void Deconnexion_Click(object sender, EventArgs e)
        {
            session.logoutUser();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Event));
        }

        private void Evenement_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(EventCreation));
        }
    }
}