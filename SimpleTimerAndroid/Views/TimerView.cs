using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SimpleTimerPortable;
using Cirrious.MvvmCross.Droid.Views;

namespace SimpleTimerAndroid.Views
{
  [Activity(Label = "SimpleTimerAndroid", MainLauncher = true, Icon = "@drawable/icon")]
  public class TimerView : MvxActivity
  {
    
    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      // Set our view from the "main" layout resource
      SetContentView(Resource.Layout.Main);
      
    }

  }
}

