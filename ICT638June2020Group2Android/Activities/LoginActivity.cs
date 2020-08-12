using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace ICT638June2020Group2Android.Activities
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        public object Newtonsoft { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.login_layout);
            base.OnCreate(savedInstanceState);
            Button btnLogin = FindViewById<Button>(Resource.Id.btnLoginUser);
            btnLogin.Click += BtnLogin_Click;

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            EditText eduseraccount = FindViewById<EditText>(Resource.Id.edUserAccount);
            EditText eduserpassword = FindViewById<EditText>(Resource.Id.edUserPassword);

            string url = "https://10.0.2.2:5001/api/Registers/1";
            string login77 = "";
            var httpWebRequest = new HttpWebRequest(new Uri(url));
            httpWebRequest.ServerCertificateValidationCallback = delegate { return true; };
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";



            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                login77 = reader.ReadToEnd();
            }


            User user = new User();
            user = JsonConvert.DeserializeObject<User>(login77);



            if (eduseraccount.Text == user.uniquename && eduserpassword.Text == user.password)
            {
                StartActivity(typeof(View));
            }
        }
    }
}