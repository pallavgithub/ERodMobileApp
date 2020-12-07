﻿using Android.App;
using Android.Widget;
using ERodMobileApp.Helpers;

namespace ERodMobileApp.Droid.CustomRenderers
{
    class MessageAndroid : IMessage
    {
        public string GetPath()
        {
            return Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDownloads).AbsolutePath;
        }

        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}