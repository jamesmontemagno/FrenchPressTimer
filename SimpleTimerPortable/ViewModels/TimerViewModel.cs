using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;
using SimpleTimerPortable.Models;

namespace SimpleTimerPortable.ViewModels
{
  public class TimerViewModel : MvxViewModel
  {
    private CupOfCoffee cup;
    
    public TimerViewModel()
    {
     cup = new CupOfCoffee
      {
        CustomerName = "James",
        Price = 200,
        Roast = "Morning",
        RoastCount = 1,
        Roaster = "Vivace"
      };
    }

    private Timer timer;


    private ICommand startCommand;
    public ICommand StartCommand
    {
      get { return startCommand ?? (startCommand = new MvxCommand(ExecuteStartCommand)); }
    }

    private void ExecuteStartCommand()
    {
      if(timer == null)
        timer = new Timer(OnTick, null, 1000, 1000);
    }


    private ICommand stopCommand;
    public ICommand StopCommand
    {
      get { return stopCommand ?? (stopCommand = new MvxCommand(ExecuteStopCommand)); }
    }

    private void ExecuteStopCommand()
    {

      TimeLeft = new TimeSpan(0, 4, 0);

      if (timer == null)
        return;

      timer.Dispose();
      timer = null;
      TimeLeft = new TimeSpan(0, 4, 0);
    }


    private ICommand pauseCommand;
    public ICommand PauseCommand
    {
      get { return pauseCommand ?? (pauseCommand = new MvxCommand(ExecutePauseCommand)); }
    }

    private void ExecutePauseCommand()
    {
      if (timer == null)
        return;

      timer.Dispose();
      timer = null;
    }

    private void OnTick(object args)
    {
      TimeLeft = timeLeft.Subtract(new TimeSpan(0, 0, 1));

      if (timeLeft.TotalSeconds == 0)
        ExecuteStopCommand();
    }

    private TimeSpan timeLeft = new TimeSpan(0, 4, 0);
    public TimeSpan TimeLeft
    {
      get { return timeLeft; }
      set 
      { 
        timeLeft = value;
        RaisePropertyChanged("TimeLeft");
        Time = string.Format("{0:m\\:ss}", timeLeft);
      }
    }

    private string time = "4:00";
    public string Time
    {
      get { return time; }
      set { time = value; base.RaisePropertyChanged("Time"); }
    }

    public string RoastDescription
    {
      get { return cup.CustomerName + " likes " + cup.Roaster + ": " + cup.Roast + " coffee."; }
    }

    public string CustomerName
    {
      get { return cup.CustomerName; }
      set
      {
        if (cup.CustomerName == value)
          return;

        cup.CustomerName = value;
        RaisePropertyChanged("CustomerName");
        RaisePropertyChanged("RoastDescription");
      }
    }

  }
}
