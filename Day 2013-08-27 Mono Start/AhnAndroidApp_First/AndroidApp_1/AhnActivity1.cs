using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Org.Apache.Http.Entity;

namespace AndroidApp_1
{
    [Activity(Label = "AhnLoveFeng", MainLauncher = true, Icon = "@drawable/icon")]
    public class AhnActivity1 : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            var love = new String[]
                {
                    GetString(Resource.String.love1), GetString(Resource.String.love2),
                    GetString(Resource.String.love3)
                };

            base.OnCreate(bundle);

            SetContentView(Resource.Layout.AhnLayout1);

            // Create your application here

            FindViewById<Button>(Resource.Id.btnClick1).Click += (sender, args) =>
            {
                var builder = new AlertDialog.Builder(this);
                builder.SetTitle(Resource.String.alertTitle).SetMessage(Resource.String.alertMessage).SetPositiveButton(Resource.String.alertBtnYes,
                    (sender1, args1) =>
                        Toast.MakeText(this, Resource.String.alertYes, ToastLength.Long).Show()
                    ).SetNegativeButton(Resource.String.alertBtnNo, (EventHandler<DialogClickEventArgs>)null).Show();//Show() 为异步方法
            };

            FindViewById<Button>(Resource.Id.btnClick2).Click += (sender, args) =>
            {
                var builder = new AlertDialog.Builder(this);
                builder.SetTitle(Resource.String.alertTitle).SetItems(love, (sender1, args1) => Toast.MakeText(this, love[args1.Which], ToastLength.Long).Show()).Show();
            };

            FindViewById<Button>(Resource.Id.btnClick3).Click += (sender, args) =>
            {
                var loginView = LayoutInflater.From(this).Inflate(Resource.Layout.LoginLayout, null);

                var builder = new AlertDialog.Builder(this);
                builder.SetTitle(Resource.String.title_Login).SetView(loginView).SetPositiveButton(Resource.String.btnLogin_Login,
                    (o, eventArgs) =>
                    {
                        if (loginView.FindViewById<EditText>(Resource.Id.txtUsername_Login).Text.Equals(GetString(Resource.String.username)) &&
                           loginView.FindViewById<EditText>(Resource.Id.txtPassword_Login).Text.Equals(GetString(Resource.String.password)))
                        {
                            Toast.MakeText(this, Resource.String.msg1_Login, ToastLength.Long).Show();
                        }
                        else
                        {
                            Toast.MakeText(this, Resource.String.msg2_Login, ToastLength.Long).Show();
                        }
                    }).SetNegativeButton(Resource.String.btnCancel_Login, (o, eventArgs) =>
                        Toast.MakeText(this, Resource.String.msg3_Login, ToastLength.Long).Show()
                    ).Show();
            };

            FindViewById<Button>(Resource.Id.btnMultiSelect).Click += (sender, args) =>
            {
                var builder = new AlertDialog.Builder(this);
                builder.SetMultiChoiceItems(love, null, (sender1, args1) => Toast.MakeText(this, love[args1.Which], ToastLength.Long).Show()).Show();
            };

            FindViewById<Button>(Resource.Id.btnSingleSelect).Click += (sender, args) =>
            {
                var builder = new AlertDialog.Builder(this);
                builder.SetSingleChoiceItems(love, 0, (sender1, args1) => Toast.MakeText(this, love[args1.Which], ToastLength.Long).Show()).Show();
            };
        }
    }
}