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

namespace FinalTestdatbase.Droid
{
    [Activity(Label = "Activity1")]
    public class Home : Activity
    {

        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);

        }

        private void openmap_Click(object sender, EventArgs e)
        {
            var geoloc = Android.Net.Uri.Parse("geo:43.586998,5.3967273");
            var mapOpen = new Intent(Intent.ActionView, geoloc);
            StartActivity(mapOpen);
        }

    }
}