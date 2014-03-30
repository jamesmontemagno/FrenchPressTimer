using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SimpleTimeriOS
{
  [Register("AppDelegate")]
  public partial class AppDelegate : UIApplicationDelegate
  {
    UIWindow window;
    UINavigationController navigationController;
    MyViewController viewController;

    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
      window = new UIWindow(UIScreen.MainScreen.Bounds);

      viewController = new MyViewController();
      navigationController = new UINavigationController(viewController);
      window.RootViewController = navigationController;

      window.MakeKeyAndVisible();

      return true;
    }
  }
}

