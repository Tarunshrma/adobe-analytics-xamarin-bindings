using System;
using System.Collections.Generic;

namespace SampleAppAdobeAnalytics.Interface
{
    public interface IAdobeAnalytics
    {
        void Setup();

        void TrackEvent(string eventName);

        void TrackEvent(string eventName, Dictionary<string, string> data);

        void TrackState(string screenName, Dictionary<string, string> additionalContextData);

    }
}
