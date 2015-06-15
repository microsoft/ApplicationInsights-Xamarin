using System;
using Xamarin.Forms;

namespace XamarinTest
{
	public class ApplicationInsights
	{
		public ApplicationInsights(){}

		public static void Setup (string instrumentationKey){
			DependencyService.Get<IApplicationInsights> ().Setup (instrumentationKey);
		}

		public static void Start (){
			DependencyService.Get<IApplicationInsights> ().Start ();
		}
	}
}

