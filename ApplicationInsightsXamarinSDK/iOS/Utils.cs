using System;
using Foundation;
using System.Collections.Generic;

namespace AI.XamarinSDK.iOS
{
	public class Utils
	{
		public static NSDictionary ConvertToNSDictionary(Dictionary<string, string> dictionary){
			string[] keys = new string[dictionary.Count];
			dictionary.Keys.CopyTo(keys, 0);

			string[] values = new string[dictionary.Count];
			dictionary.Keys.CopyTo(values, 0);

			NSDictionary convertedDict = NSDictionary.FromObjectsAndKeys (values, keys);
			return convertedDict;
		}
	}
}

