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
	[Activity (Label = "FinalTestdatbase.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        private EditText editText1, editText2;
        private Button button1, button2, button3; 
        private TextView textView3, textView4, textView5, textView6;
        

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            editText1 = FindViewById<EditText>(Resource.Id.editText1);
            editText2 = FindViewById<EditText>(Resource.Id.editText2);
            button1 = FindViewById<Button>(Resource.Id.button1);
            button2 = FindViewById<Button>(Resource.Id.button2);
            button3 = FindViewById<Button>(Resource.Id.button3);
            textView3 = FindViewById<TextView>(Resource.Id.textView3);
            textView4 = FindViewById<TextView>(Resource.Id.textView4);
            textView5 = FindViewById<TextView>(Resource.Id.textView5);
            textView6 = FindViewById<TextView>(Resource.Id.textView6);
            string var1 = FindViewById<EditText>(Resource.Id.editText1).Text;
            string var2 = FindViewById<EditText>(Resource.Id.editText2).Text;

            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
        }

        MySqlConnection con = new MySqlConnection("Server=sql7.freemysqlhosting.net;Port=3306;database=sql7147202; User Id=sql7147202;Password=TQ13I75cK3;");
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    textView3.Text = "Successfully connected";
                    
                } else {
                    textView4.Text = "Connexion déjà établi";
                }
            } 
            catch(MySqlException ex)
            {
                textView3.Text = ex.ToString();
            } finally
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string query = "INSERT INTO members (id,user,password) VALUES ('','" + editText1.Text + "','" + editText2.Text + "');";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();

            


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "SELECT user,password FROM members WHERE user = '" + editText1.Text + "' and password = '" + editText2.Text + "'";

            MySqlDataReader reader = new MySqlCommand(query, con).ExecuteReader();

            if (reader.Read())
            {
                textView5.Text = (reader["user"].ToString());
                textView6.Text = (reader["password"].ToString());
                reader.Close();
            } else
            {
                textView5.Text = "Aucun compte existant !";
                reader.Close();
            }


        }
    }
}


