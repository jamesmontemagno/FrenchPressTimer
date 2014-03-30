using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SimpleTimerPortable;

namespace SimpleTimerAndroid
{
  [Activity(Label = "SimpleTimerAndroid", MainLauncher = true, Icon = "@drawable/icon")]
  public class Activity1 : Activity
  {
    private TimerViewModel viewModel;
    TextView time;
    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      // Set our view from the "main" layout resource
      SetContentView(Resource.Layout.Main);
      viewModel = new TimerViewModel();
      // Get our button from the layout resource,
      // and attach an event to it
      Button start = FindViewById<Button>(Resource.Id.start);
      Button pause = FindViewById<Button>(Resource.Id.pause);
      Button stop = FindViewById<Button>(Resource.Id.stop);

      time = FindViewById<TextView>(Resource.Id.time);

      start.Click += delegate { viewModel.StartCommand.Execute(null); };
      pause.Click += delegate { viewModel.PauseCommand.Execute(null); };
      stop.Click += delegate { viewModel.StopCommand.Execute(null); };

      viewModel.PropertyChanged += viewModel_PropertyChanged;


    }

    void viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      if (e.PropertyName == "Time")
        time.Text = viewModel.Time;
    }
  }
}

