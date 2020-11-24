using System.Threading.Tasks;
using TinyIoC.Base;

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

        public DashboardViewModel(ProfileViewModel profileViewModel, SummaryViewModel summaryViewModel,
            TimeClockViewModel timeClockViewModel, SettingsViewModel settingsViewModel)
        {
            ProfileViewModel = profileViewModel;
            SummaryViewModel = summaryViewModel;
            TimeClockViewModel = timeClockViewModel;
            SettingsViewModel = settingsViewModel;
        }

        public override Task InitAsync()
        {
            return Task.WhenAny(base.InitAsync(),
                ProfileViewModel.InitAsync(),
                TimeClockViewModel.InitAsync(),
                SummaryViewModel.InitAsync(),
                SettingsViewModel.InitAsync()
            );
        }
    }
}