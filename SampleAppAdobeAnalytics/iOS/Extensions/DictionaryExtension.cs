using System;
using System.Collections.Generic;
using Foundation;

namespace SampleAppAdobeAnalytics.iOS.Extensions
{
    public static class DictionaryExtension
    {
        public static NSDictionary<NSString, NSString> ToNativeDictionary(this Dictionary<string, string> dict)
        {
            NSDictionary<NSString, NSString> nativeDict = null;
            foreach (var key in dict.Keys)
            {
                NSString strKey = new NSString(key);
                NSString strValue = new NSString(dict[key]);

                nativeDict = new NSDictionary<NSString, NSString>(strKey, strValue);
            }

            return nativeDict;
        }
    }
}
