# Application Insights for Xamarin.Forms (1.0-alpha.3) DEPRECATED

This SDK is officially deprecated. Please switch to [HockeyApp](https://hockeyapp.net) or consider [MobileCenter](https://www.visualstudio.com/vs/mobile-center/).

You can find more about the transition from Application Insights to HockeyApp [here](https://www.hockeyapp.net/blog/2016/03/11/welcome-application-insights-users.html) and about how Mobile Center will be the future of HockeyApp [here](https://www.hockeyapp.net/blog/2016/11/16/mobile-center-next-generation-hockeyapp.html).

Please don't hesitate to get in touch via [support@hockeyapp.net](mailto:support@hockeyapp.net).
 if you have questions.

### About

<span style="color:green">If you want to use the a version of the SDK, which doesn't have a dependency on Xamarin.Forms, please switch to</span> [**feature/remove-xamarin-forms**](https://github.com/Microsoft/ApplicationInsights-Xamarin/tree/feature/remove-xamarin-forms) *(Thanks to [xvare](https://github.com/xvare))*. However, changes on this branch have not been fully tested, yet.

This project provides an Xamarin SDK for Application Insights. [Application Insights](http://azure.microsoft.com/en-us/services/application-insights/) is a service that allows developers to keep their applications available, performing, and succeeding. This SDK allows your Xamarin apps to send telemetry of various kinds (events, traces, exceptions, etc.) to the Application Insights service where your data can be visualized in the Azure Portal. Currently, we provide support for iOS and Android.

##Breaking Changes!

Version 1.0-alpha.3 of the Application Insights SDK for Xamarin.Forms comes with two major changes:

Crash Reporting and the API to send handled exceptions have been removed from the SDK. In addition, the Application Insights SDK for Xamarin.Forms is now deprecated.

The reason for this is that [HockeyApp](http://hockeyapp.net/releases) is now our major offering for mobile and cross-plattform crash reporting, beta distribution and user feedback. We are focusing all our efforts on enhancing the HockeySDK and adding telemetry features to make HockeyApp the best platform to build awesome apps. We've launched [HockeyApp Preseason](http://hockeyapp.net/blog/2016/02/02/introducing-preseason.html) so you can try all the new bits yourself, including User Metrics.

We apologize for any inconvenience and please feel free to [contact us](http://support.hockeyapp.net/) at any time.

## Content
1. [Requirements](#1)
2. [Release Notes](#2)
3. [Breaking Changes & Deprecations](#3)
4. [Setup](#4)
5. [Developer Mode](#5)
6. [Basic Usage](#6)
7. [Automatic Collection of Lifecycle Events](#7)
8. [Additional configuration](#8)
9. [Integrate plugin sources](#9)
10. [Troubleshooting](#10)
11. [Contact](#11)


## <a name="1"></a> 1. Requirements
The minimum API level to use the Application Insights SDK for Xamarin.Forms in your **Android** app is 9. However, automatic collection of lifecycle-events requires API level 15 and up (Ice Cream Sandwich+). For **iOS** builds the minimum iOS version is 6. Furthermore, the SDK has a dependency on 2.0.1.6505.

The SDK has been developed and tested with the following framework versions:

* Xamarin.Android 6.0.1.10
* Xamarin.iOS 9.4.1.25

Older versions might work, but haven't been tested.

## <a name="2"></a> 2. Release Notes

Also see changes in [older versions](NOTES.md).

* Update underlying SDKs
  * Application Insights SDK for iOS 1.0-beta.7
  * Application Insights SDK for Android 1.0-beta.9
* Remove crash/exception reporting APIs
* Add APIs for setting common properties
* Remove API to set the `userID` field, add API to set the `authUserID` (fixes user statistics)
* Minor bugfixes


##<a name="3"></a> 3. Breaking Changes & deprecations

* Remove crash reporting and APIs for exception tracking
* `ApplicationInsights.SetUserId(string)` changed to `ApplicationInsights.SetAuthUserId(string)`

##<a name="4"></a> 4. Setup

We're assuming you are using Xamarin Studio to create your apps.

### 4.1 **Add SDK to your Xamarin solution**

Clone the repository in order to get the SDK sources. It contains 3 subfolder, one for a demo project (*DemoApp*), one for a local NuGet package (*NuGet*), and another one for the SDK sources (*ApplicationInsightsXamarin*).

There are several ways to integrate the Application Insights Xamarin SDK into your app. The recommend way is to use the NuGet-package. However, you can also integrate the SDK by importing the sources.

1. Expand one of your platform projects inside the solution panel
2. Right click the **Packages** folder and select ***Add Packages...***
3. [Configure a local package source](http://developer.xamarin.com/guides/cross-platform/application_fundamentals/nuget_walkthrough/) and let it point to 
*ApplicationInsightsXamarin/NuGet*
4. Choose the local package source in the sources dropdown
4. Check the **Show pre-release packages** and select **ApplicationInsights SDK for Xamarin.Forms**
5. Click the **Add Package** button
6. Repeat those steps for all other platform projects

### 4.2 Configure the instrumentation key

Please see the "[Getting an Application Insights Instrumentation Key](https://github.com/Microsoft/ApplicationInsights-Home/wiki#getting-an-application-insights-instrumentation-key)" section of the wiki for more information on acquiring a key.

### 4.3 Add code to setup and start Application Insights

1. Depending on the plattforms you want to support, you can setup and start the Application Insights Xamarin SDK in different files:
	* **Xamarin.Forms** (Android & iOS): Application class (e.g. *project_name*.cs in the apps shared project
	* **iOS only**: AppDelegate.cs in your iOS platform project
	* **Android only**: Main Activity of your Android platform project
2. Add using statements

	```csharp
	using AI.XamarinSDK.Abstractions;
	```
	
3. Add the following lines of code to on of the following methods 
	* **Xamarin.Forms** (Android & iOS): `OnStart ()`
	* **iOS only**: `FinishedLaunching()`
	* **Android only**: `OnStart ()`

		```csharp
		ApplicationInsights.Setup ("<YOUR_IKEY_HERE>");
		ApplicationInsights.Start ();
		```
	
	* **[NOTE]**: If you plan to support *iOS* you currently need to make a direct call to the iOS assembly so that it doesn't get stripped by the linker. Add the following line right after the Xamarin.Forms init()-call inside the `FinsihedLaunching()` of your **AppDelegate.cs**
	
		```csharp
		AI.XamarinSDK.iOS.ApplicationInsights.Init();
		```
		
4. Replace `<YOUR_IKEY_HERE>` with the instrumentation key of your app.
	
**Congratulation, now you're all set to use Application Insights! See [Usage](#6) on how to use Application Insights.**

## <a name="5"></a> 5. Developer Mode

The **developer mode** is enabled automatically in case the debugger is attached or if the app is running in the emulator. This will enable the console logging and decrease the number of telemetry items per batch as well as the sending interval. If you don't want this behavior, disable the **developer mode**.

You can explicitly enable/disable the developer mode like this:

```csharp
ApplicationInsights.SetDebugLogEnabled(false);
```

## <a name="6"></a> 6. Basic Usage  ##

The ```TelemetryManager``` provides various class methods to track events, traces, metrics, and page views. The class should only be used after *ApplicationInsights* has been [set up & started](#4).

```csharp
//track an event
TelemetryManager.TrackEvent ("My custom event");

//track a page view
TelemetryManager.TrackPageView ("My custom page view");

//track a trace
TelemetryManager.TrackTrace ("My custom message");

//track a metric
TelemetryManager.TrackMetric ("My custom metric", 2.2);
```

Some data types allow for custom properties.

```csharp
//Setup a custom property
Dictionary<string, string> properties = new Dictionary<string, string> ();
properties.Add ("Xamarin Key", "Custom Property Value");

//track an event with custom properties
TelemetryManager.TrackEvent ("My custom event", properties);

```

## <a name="7"></a>7. Automatic collection of life-cycle events (Sessions & Page Views)

Auto collection is **enabled by default**. However, you can disable automatic page view tracking & session management while setting up `ApplicationInsight`. 

### Android

To support the auto collection feature make sure the min SDK of your app is at least API level 14. 

[**NOTE**] Only 'Activity' instances will be recognized by auto collection. Note that using e.g. `Navigation.PushAsync()` within a Xamarin.Forms page will replace a `Fragment`. However, you can programmatically [track a page view](#6) in situations like this.

### All plattforms

If you want to explicitly **Disable** automatic collection of life-cycle events (auto session tracking and auto page view tracking), call make the following calls inbetween setup and start of Application Insights. 

```csharp
//after ApplicationInsights.Setup(...);
ApplicationInsights.SetAutoPageViewTrackingDisabled(true);
ApplicationInsights.SetAutoSessionManagementDisabled(true);
//before ApplicationInsights.Start()
```

## <a name="8"></a>8. Additional Configuration

To configure Application Insights according to your needs, there are some other options listed here

### 8.1 Set User Session Time

The default time the users entering the app counts as a new session is 20s. If you want to set it to a different value, do the following:

```csharp
// app background time after which session will be renewed
ApplicationInsights.SetSessionExpirationTime(30000)
```

### 8.2 Set Different Endpoint

You can also configure a different server endpoint for the SDK if needed:

```csharp
ApplicationInsights.SetServerUrl("https://myServer.com/track");
```

### 8.3 Override sessionID and ID of authenticated users

Application Insights manages IDs for a session and for individual users for you. If you want to override the generated IDs with your own, it can be done like this:

```csharp
ApplicationInsights.SetAuthUserId("User371263");
ApplicationInsights.RenewSession("New session ID");
```
[**NOTE**] If you want to manage sessions manually, please disable [Automatic Collection of Lifecycle Events](#7).

### 8.4 Setting common properties

Common properties are key-value-pairs that are added to all telemetry events, that are sent out.

```csharp
// Set common properties
Dictionary<string, string> commonProperties = new Dictionary<string, string> ();
commonProperties.Add ("Common Key", "Common Property Value");
ApplicationInsights.SetCommonProperties (commonProperties);
```

[**NOTE**] Depending on the platform your are running on, the common property API behaves is slightly different. While it is possible to set those properties at any time if your app is running on iOS, you can only set common properties on Android between the `Setup()` and `Start()` call (otherwise the call will just be ignored).

##<a name="9"></a> 9. Integrate plugin sources

There are several ways to integrate the Application Insights Xamarin SDK into your app. The recommend way is to use the NuGet-package. However, you can also integrate the SDK by importing the sources:

1. Copy *ApplicationInsightsXamarin* to your solution directory. 
2. Open Xamarin Studio and add its projects to your solution. This can be done by right clicking the solution name in the solution panel, then click *Add* - *Add Existing Project...*:

	* **AI.XamarinSDK**
	* **AI.XamarinSDK.iOS** *(only needed for iOS support)*
	* **AI.XamarinSDK.Android** & **AI.XamarinSDK.AndroidBindings** *(only needed for Android support)*

	[**Note**] In order to successfully build the SDK, you may have to update all referenced packages. Simply right click on the *Packages* folder of each of those projects and click *Update*.

3. Add references to your app projects

	* **Android**

		1. In the solution panel, select the Android app project.
		2. In the main menu go to *Project* - *Edit References*.
		3. Select the *All* tab and check *AI.XamarinSDK.Android*.
		4. Confirm the change by clicking the *OK* button.

	* **iOS**

		1. In the solution panel, select the iOS app project.
		2. In the main menu go to *Project* - *Edit References*.
		3. Select the *All* tab and check *AI.XamarinSDK.iOS*.
		4. Confirm the change by clicking the *OK* button
	
	4. Follow instructions in [4.2](#4)..
		
##<a name="10"></a> 10. Troubleshooting

### SDK references broken

In order to successfully build the SDK, you may have to update all referenced packages. Simply right click on the *Packages* folder of each of those projects and click *Update*.

### iOS App crashes immediately after start

If you plan to support *iOS* you currently need to make a direct call to the iOS assembly so that it doesn't get stripped by the linker. Add the following line right after the Xamarin.Forms init()-call inside the `FinsihedLaunching()` of your **AppDelegate.cs**
	
```csharp
AI.XamarinSDK.iOS.ApplicationInsights.Init();
``` 

##<a id="11"></a> 11. Contact

If you have further questions or are running into trouble that cannot be resolved by any of the steps here, feel free to open a GitHub issue here or contact us at [support@hockeyapp.net](mailto:support@hockeyapp.net)
