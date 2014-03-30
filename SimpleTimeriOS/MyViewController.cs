using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Dialog;
using SimpleTimerPortable;

namespace SimpleTimeriOS
{
  public class MyViewController : DialogViewController
  {

    private TimerViewModel viewModel;
    public MyViewController()
      : base(UITableViewStyle.Plain, null, false)
    {
    }

    StringElement time;
    public override void ViewDidLoad()
    {
      base.ViewDidLoad();
      this.EdgesForExtendedLayout = UIRectEdge.None;
      
      viewModel = new TimerViewModel();

      this.Root = new RootElement("Timer"){
        new Section(){
          (time = new StringElement(string.Empty, "4:00")),
          new StringElement("Start", ()=>{ viewModel.StartCommand.Execute(null);}),
          new StringElement("Pause", ()=>{ viewModel.PauseCommand.Execute(null);}),
          new StringElement("Stop", ()=>{ viewModel.StopCommand.Execute(null);})
          
        }
      };

      viewModel.PropertyChanged += viewModel_PropertyChanged;

    }

    void viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      if (e.PropertyName == "Time")
      {
        time.Value = viewModel.Time;
        this.Root.Reload(time, UITableViewRowAnimation.Fade);
      }
      
    }

  }
}

