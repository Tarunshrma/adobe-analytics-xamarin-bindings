using System;
using System.Collections.Generic;
using System.Diagnostics;
using SampleAppAdobeAnalytics.Constants;
using SampleAppAdobeAnalytics.Interface;

namespace SampleAppAdobeAnalytics.Services
{
    public class AdobeAnalytics
    {
        public static AnalyticConstants Events { get; private set; }

        private static bool _initialized = false;
        private static IAdobeAnalytics analytics;

        public static void TrackEvent(string eventName)
        {
            if (!_initialized) return;

            analytics.TrackEvent(eventName);
        }

        public static void TrackEvent(string eventName, Dictionary<string, string> data)
        {
            if (!_initialized) return;

            analytics.TrackEvent(eventName, data);
        }

        public static void TrackState(string eventName, Dictionary<string, string> data)
        {
            if (!_initialized) return;

            analytics.TrackState(eventName, data);
        }

        public static void Setup()
        {
            try
            {
                analytics = ServiceLocator.Instance.Get<IAdobeAnalytics>();

                analytics.Setup();
                _initialized = true;
            }
            catch (Exception ex)
            {
                _initialized = false;
                Debug.Write(ex);
            }
        }
    }
}
