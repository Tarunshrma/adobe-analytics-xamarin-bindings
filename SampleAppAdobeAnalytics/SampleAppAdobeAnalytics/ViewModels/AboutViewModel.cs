using System.Windows.Input;
using SampleAppAdobeAnalytics.Constants;
using SampleAppAdobeAnalytics.Services;

namespace SampleAppAdobeAnalytics
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() =>
            {
                AnalyticsService.TrackEvent(AnalyticConstants.BrowseEvent);
                Plugin.Share.CrossShare.Current.OpenBrowser("https://xamarin.com/platform");
            });
        }

        public ICommand OpenWebCommand { get; }
    }
}
