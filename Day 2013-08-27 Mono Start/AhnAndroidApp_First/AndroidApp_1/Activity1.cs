using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AndroidApp_1
{
    [Activity(Label = "AndroidApp_1", MainLauncher = false, Icon = "@drawable/icon")]
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

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
            //button.Click += (o, e) => { Toast.MakeText(this, "删除成功", ToastLength.Short).Show(); };
            button.Click += (o, e) =>
            {
                Toast.MakeText(this, this.Resources.GetString(Resource.String.ClickMe), ToastLength.Short).Show();
            };

            RegisterForContextMenu(FindViewById<EditText>(Resource.Id.MyEditText1));
        }

        public override Boolean OnCreateOptionsMenu(IMenu menu)
        {
            menu.Add(0, 123, 0, "新建");
            menu.Add(0, 124, 1, "删除");

            base.OnCreateOptionsMenu(menu);

            return true;
        }

        public override Boolean OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == 123)
            {
                Toast.MakeText(this, "新建成功", ToastLength.Long).Show();
            }
            else if (item.ItemId == 124)
            {
                Toast.MakeText(this, "删除成功", ToastLength.Long).Show();
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
        {
            if (v == FindViewById<EditText>(Resource.Id.MyEditText1))
            {
                menu.Add(0, 0, 0, Resource.String.Copy);
                menu.Add(0, 1, 1, Resource.String.Paste);
            }
            base.OnCreateContextMenu(menu, v, menuInfo);
        }

        public override bool OnContextItemSelected(IMenuItem item)
        {
            if (item.ItemId == 0)
            {
                Toast.MakeText(this, Resource.String.Copy, ToastLength.Short).Show();
            }
            else if (item.ItemId == 1)
            {
                Toast.MakeText(this,Resource.String.Paste,ToastLength.Short).Show();
            }
            return base.OnContextItemSelected(item);
        }
    }
}

