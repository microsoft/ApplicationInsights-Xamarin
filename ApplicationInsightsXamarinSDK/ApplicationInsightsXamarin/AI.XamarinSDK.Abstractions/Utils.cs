using System;
using Xamarin.Forms;

namespace AI.XamarinSDK.Abstractions {
	public class Utils {
		public Utils () {
		}

		public static Boolean IsSupportedPlatform(){
			return (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android);
		}
	}
}

