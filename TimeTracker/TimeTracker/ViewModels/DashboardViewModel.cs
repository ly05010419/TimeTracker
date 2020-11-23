﻿using System.Threading.Tasks;

namespace TimeTracker.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private ProfileViewModel _profileViewModel;

        public ProfileViewModel ProfileViewModel
        {
            get => _profileViewModel;
            set => SetProperty(ref _profileViewModel, value);
        }
        
        private SummaryViewModel _summaryViewModel;
        
        public SummaryViewModel SummaryViewModel
        {
            get => _summaryViewModel;
            set => SetProperty(ref _summaryViewModel, value);
        }

        private TimeClockViewModel _timeClockViewModel;
        
        public TimeClockViewModel TimeClockViewModel
        {
            get => _timeClockViewModel;
            set => SetProperty(ref _timeClockViewModel, value);
        }

        private SettingsViewModel _settingsViewModel;
        
        public SettingsViewModel SettingsViewModel
        {
            get => _settingsViewModel;
            set => SetProperty(ref _settingsViewModel, value);
        }

        public DashboardViewModel(ProfileViewModel profileViewModel,SummaryViewModel summaryViewModel,TimeClockViewModel timeClockViewModel, SettingsViewModel settingsViewModel)
        {
            ProfileViewModel = profileViewModel;
            SummaryViewModel = summaryViewModel;
            TimeClockViewModel = timeClockViewModel;
            SettingsViewModel = settingsViewModel;
        }

        public override Task InitializeAsync(object navigationDate = null)
        {
            return Task.WhenAny(base.InitializeAsync(navigationDate),
                ProfileViewModel.InitializeAsync(null),
                TimeClockViewModel.InitializeAsync(null),
                SummaryViewModel.InitializeAsync(null),
                SettingsViewModel.InitializeAsync(null)
            );
        }
    }
}