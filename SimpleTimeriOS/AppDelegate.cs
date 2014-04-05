using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Touch.Platform;

namespace SimpleTimeriOS
{
  [Register("AppDelegate")]
  public partial class AppDelegate : MvxApplicationDelegate
  {
    UIWindow window;
    UINavigationController navigationController;
    
    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
      window = new UIWindow(UIScreen.MainScreen.Bounds);

      var setup = new Setup(this, window);
      setup.Initialize();

      var startup = Mvx.Resolve<IMvxAppStart>();
      startup.Start();

      window.MakeKeyAndVisible();

      return true;
    }
  }
}

