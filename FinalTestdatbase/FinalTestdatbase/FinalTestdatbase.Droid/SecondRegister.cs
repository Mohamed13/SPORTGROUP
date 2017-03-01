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
    [Activity(Label = "SecondRegister")]
    public class SecondRegister : Activity

        
    {
        private Button next;

        UserSessionManagement session = new UserSessionManagement();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SecondRegister);

            next = FindViewById<Button>(Resource.Id.next);
            session = new UserSessionManagement(Application.Context);

            Dictionary<string, string> user = session.getUserDetails();

            string name = user[UserSessionManagement.KEY_NAME];

            next.Click += Next_Click;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ThirdRegister));
        }
    }
}