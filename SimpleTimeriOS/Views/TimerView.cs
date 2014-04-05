using System;
using MonoTouch.UIKit;
using System.Drawing;
using SimpleTimerPortable;
using Cirrious.MvvmCross.Touch.Views;
using SimpleTimerPortable.ViewModels;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace SimpleTimeriOS.Views
{
  public class TimerView : MvxViewController
  {


    public TimerView()
    {
    }

    public override void ViewDidLoad()
    {
      base.ViewDidLoad();
      this.EdgesForExtendedLayout = UIRectEdge.None;
      View.Frame = UIScreen.MainScreen.Bounds;
      View.BackgroundColor = UIColor.White;
      View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

      var x = (View.Frame.Width - 200) / 2;

      var time = new UILabel();
      time.Frame = new RectangleF(x, 10, 200, 50);
      time.TextColor = UIColor.Black;
      
      var startButton = UIButton.FromType(UIButtonType.RoundedRect);
      startButton.Frame = new RectangleF(x, 70, 200, 50);
      startButton.BackgroundColor = UIColor.Green;
      startButton.SetTitle("Start", UIControlState.Normal);
     

      var pauseButton = UIButton.FromType(UIButtonType.RoundedRect);
      pauseButton.Frame = new RectangleF(x, 130, 200, 50);
      pauseButton.BackgroundColor = UIColor.Yellow;
      pauseButton.SetTitle("Pause", UIControlState.Normal);


      var stopButton = UIButton.FromType(UIButtonType.RoundedRect);
      stopButton.Frame = new RectangleF(x, 190, 200, 50);
      stopButton.BackgroundColor = UIColor.Red;
      stopButton.SetTitle("Stop", UIControlState.Normal);

      var customerName = new UITextField(new RectangleF(10, 250, View.Frame.Width - 20, 25));

      var description = new UILabel(new RectangleF(10, 85, View.Frame.Width - 20, 60));

     

      var set = this.CreateBindingSet<TimerView, TimerViewModel>();
      set.Bind(time).To(vm => vm.Time);
      set.Bind(startButton).To(vm => vm.StartCommand);
      set.Bind(pauseButton).To(vm => vm.PauseCommand);
      set.Bind(stopButton).To(vm => vm.StopCommand);
      set.Bind(customerName).To(vm => vm.CustomerName).TwoWay();
      set.Bind(description).To(vm => vm.RoastDescription);
      set.Apply();

      View.AddSubview(time);
      View.AddSubview(startButton);
      View.AddSubview(pauseButton);
      View.AddSubview(stopButton);
      View.AddSubview(customerName);
      View.AddSubview(description);
   
    }

  }
}

