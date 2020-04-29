using System;
using SampleAppAdobeAnalytics.Interface;
using SampleAppAdobeAnalytics.Services;

namespace SampleAppAdobeAnalytics
{
    public class App
    {
        public static void Initialize()
        {
            ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
        }
    }
}
