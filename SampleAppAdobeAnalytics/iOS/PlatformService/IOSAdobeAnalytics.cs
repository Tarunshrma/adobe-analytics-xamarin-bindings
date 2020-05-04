using System.Collections.Generic;
using System.Diagnostics;
using Adobe.Experience.iOS.Core;
using SampleAppAdobeAnalytics.Constants;
using SampleAppAdobeAnalytics.Interface;
using SampleAppAdobeAnalytics.iOS.Extensions;

namespace SampleAppAdobeAnalytics.iOS.PlatformService
{
    public class IOSAdobeAnalytics : IAdobeAnalytics
    {
        public IOSAdobeAnalytics()
        {
        }

        public void Setup()
        {
            ACPCore.LogLevel = ACPMobileLogLevel.Debug;
            ACPCore.ConfigureWithAppId(AppConfigurations.AdobeAppId);
            Adobe.Experience.iOS.Identity.ACPIdentity.RegisterExtension();
            Adobe.Experience.iOS.Analytics.ACPAnalytics.RegisterExtension();
            ACPCore.Start(() =>
            {
                Debug.Write("Adobe analyticsc initialized and started");
            });
        }

        public void TrackEvent(string eventName)
        {
            ACPCore.TrackAction(eventName, null);
        }

        public void TrackEvent(string eventName, Dictionary<string, string> data)
        {
            var dictData = data.ToNativeDictionary();
            ACPCore.TrackAction(eventName, dictData);
        }

        public void TrackState(string screenName, Dictionary<string, string> additionalContextData)
        {
            var dictData = additionalContextData?.ToNativeDictionary();
            ACPCore.TrackState(screenName, dictData);
        }
    }
}
