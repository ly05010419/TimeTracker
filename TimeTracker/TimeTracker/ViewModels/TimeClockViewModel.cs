﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TimeTracker.Models;
using TimeTracker.ViewModels.Button;
using TimeTracker.Views.Buttons;
using Xamarin.Forms;

namespace TimeTracker.ViewModels
{
    public class TimeClockViewModel : ViewModelBase
    {
        private TimeSpan _runningTotal;

        public TimeSpan RunningTotal
        {
            get => _runningTotal;
            set => SetProperty(ref _runningTotal, value);
        }

        private DateTime _currentStartTime;

        public DateTime CurrentStartTime
        {
            get => _currentStartTime;
            set => SetProperty(ref _currentStartTime, value);
        }


        private double _todaysEarnings;

        public double TodaysEarnings
        {
            get => _todaysEarnings;
            set => SetProperty(ref _todaysEarnings, value);
        }

        private ButtonModel _clockInOutButtonModel;

        public ButtonModel ClockInOutButtonModel
        {
            get => _clockInOutButtonModel;
            set => SetProperty(ref _clockInOutButtonModel, value);
        }

        private ObservableCollection<WorkItem> _workItems;

        public ObservableCollection<WorkItem> WorkItems
        {
            get => _workItems;
            set => SetProperty(ref _workItems, value);
        }

        private bool _isClockedIn;

        public bool IsClockedIn
        {
            get => _isClockedIn;
            set => SetProperty(ref _isClockedIn, value);
        }

        public TimeClockViewModel()
        {
            WorkItems = new ObservableCollection<WorkItem>();
           

          
            TodaysEarnings = 0;
            ClockInOutButtonModel =
                new ButtonModel("Clock In", new Command(() =>
                {
                    Debug.WriteLine("ClockInOutButtonModel");
                    if (IsClockedIn)
                    {
                        WorkItems.Insert(0,new WorkItem(CurrentStartTime, DateTime.Now));
                        ClockInOutButtonModel.Text = "Clock In";
                    }
                    else
                    {
                        CurrentStartTime = DateTime.Now;
                        ClockInOutButtonModel.Text = "Clock Out";
                    }

                    IsClockedIn = !IsClockedIn;
                }));
        }

        public override Task InitializeAsync(object navigationDate = null)
        {
            RunningTotal = new TimeSpan();
            return base.InitializeAsync(navigationDate);
        }
    }
}