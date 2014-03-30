using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace SimpleTimerPortable
{
  public class TimerViewModel : INotifyPropertyChanged
  {
    private readonly SynchronizationContext context;
    public TimerViewModel()
    {
      context = SynchronizationContext.Current;
    }

    private Timer timer;


    private ICommand startCommand;
    public ICommand StartCommand
    {
      get { return startCommand ?? (startCommand = new RelayCommand(ExecuteStartCommand)); }
    }

    private void ExecuteStartCommand()
    {
      if(timer == null)
        timer = new Timer(OnTick, null, 1000, 1000);
    }


    private ICommand stopCommand;
    public ICommand StopCommand
    {
      get { return stopCommand ?? (stopCommand = new RelayCommand(ExecuteStopCommand)); }
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
      get { return pauseCommand ?? (pauseCommand = new RelayCommand(ExecutePauseCommand)); }
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
        OnPropertyChanged("TimeLeft");
        Time = string.Format("{0:m\\:ss}", timeLeft);
      }
    }

    private string time = "4:00";
    public string Time
    {
      get { return time; }
      set { time = value; OnPropertyChanged("Time"); }
    }


    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string name)
    {
      if (PropertyChanged == null)
        return;

      context.Post((s) =>
        {
          PropertyChanged(this, new PropertyChangedEventArgs((string)s));
        }, name);
    }
  }
}
