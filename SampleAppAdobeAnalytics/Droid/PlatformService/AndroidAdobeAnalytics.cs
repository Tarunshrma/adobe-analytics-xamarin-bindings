using System;
using System.Collections.Generic;
using Android.Util;
using Com.Adobe.Marketing.Mobile;
using Plugin.CurrentActivity;
using SampleAppAdobeAnalytics.Constants;
using SampleAppAdobeAnalytics.Interface;

namespace SampleAppAdobeAnalytics.Droid.PlatformService
{
    public class AdobeCallback : Java.Lang.Object, IAdobeCallback
    {
        public void Call(Java.Lang.Object p0)
        {
            MobileCore.ConfigureWithAppID(AppConfigurations.AdobeAppId);
        }
    }

    public class AndroidAdobeAnalytics : IAdobeAnalytics
    {
        public void Setup()
        {
            MobileCore.Application = CrossCurrentActivity.Current.Activity.Application;
            MobileCore.LogLevel = LoggingMode.Debug;
            try
            {
                Analytics.RegisterExtension();
                Adobe.Experience.Android.Identity.Identity.RegisterExtension();
                MobileCore.Start(new AdobeCallback());
            }
            catch (InvalidInitException ex)
            {
                Log.Debug("ADOBE_INIT_FAILURE", ex.Message);
            }
        }

        public void TrackEvent(string eventName)
        {
            MobileCore.TrackAction(eventName, null);
        }

        public void TrackEvent(string eventName, Dictionary<string, string> data)
        {
            MobileCore.TrackAction(eventName, data);
        }

        public void TrackState(string screenName, Dictionary<string, string> additionalContextData)
        {
            MobileCore.TrackState(screenName, additionalContextData);
        }
    }
}
