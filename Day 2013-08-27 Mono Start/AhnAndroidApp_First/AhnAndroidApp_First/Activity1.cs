using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AhnAndroidApp_First
{
    [Activity(Label = "AhnAndroidApp_First", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
            //button.Click += (Object sender, EventArgs e) => Toast.MakeText(this, "删除成功", ToastLength.Short);

            EditText editText = FindViewById<EditText>(Resource.Id.Mytxt1);
            editText.Text = DateTime.Now.ToLongTimeString();
        }
    }
}

