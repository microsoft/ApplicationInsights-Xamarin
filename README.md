# Application Insights for Xamarin (1.0-alpha.3)

[**NOTE**] The SDK version of this branch doesn't have a dependency on *Xamarin.Forms* (DependencyService) anymore.

This project provides an Xamarin SDK for Application Insights. [Application Insights](http://azure.microsoft.com/en-us/services/application-insights/) is a service that allows developers to keep their applications available, performing, and succeeding. This SDK allows your Xamarin apps to send telemetry of various kinds (events, traces, exceptions, etc.) to the Application Insights service where your data can be visualized in the Azure Portal. Currently, we provide support for iOS and Android.

## Content
1. [Requirements](#1)
2. [Release Notes](#2)
3. [Breaking Changes & Deprecations](#3)
4. [Setup](#4)
5. [Developer Mode](#5)
6. [Basic Usage](#6)
7. [Automatic Collection of Lifecycle Events](#7)
8. [Exception Handling (Crashes)](#8)
9. [Additional configuration](#9)
10. [Integrate plugin sources](#10)
11. [Troubleshooting](#11)
12. [Contact](#12)


## <a name="1"></a> 1. Requirements
The minimum API level to use the Application Insights Xamarin SDK in your **Android** app is 9. However, automatic collection of lifecycle-events requires API level 15 and up (Ice Cream Sandwich+). For **iOS** builds the minimum iOS version is 6. 

The SDK has been developed and tested with the following framework versions:

* Mono Framework MDK 4.0.2.5
* Xamarin.Android 5.1.4.16
* Xamarin.iOS 8.10.3.2

Older versions might work, but haven't been tested.

## <a name="2"></a> 2. Release Notes

Also see changes in [older versions](NOTES.md).

* Add NuGet support
* Prevent linker from stripping SDK assemblies (release builds on iOS)
* Align public interface (remove additional parameters of setup()-method on Android)
* Add license and release notes


##<a name="3"></a> 3. Breaking Changes & deprecations

* `Using` statement changed: `using AI.XamarinSDK.Abstractions;`
* `setup()`-method for Android changed: As on iOS this method only takes the instrumentation key as parameter

##<a name="4"></a> 4. Setup

We're assuming you are using Xamarin Studio to create your apps.

### 4.1 **Add SDK to your Xamarin solution**

Clone the repository in order to get the SDK sources. It contains 2 subfolder, one for a demo project (*DemoApp*)  and one for the SDK (*ApplicationInsightsXamarin*).

There are several ways to integrate the Application Insights Xamarin SDK into your app. The recommend way is to use the NuGet-package. However, you can also integrate the SDK by importing the sources.

1. Expand one of your platform projects inside the solution panel
2. Right click the **Packages** folder and select ***Add Packages...***
3. [Configure a local package source](http://developer.xamarin.com/guides/cross-platform/application_fundamentals/nuget_walkthrough/) and let it point to 
*ApplicationInsightsXamarin/NuGet*
4. Choose the local package source in the sources dropdown
4. Check the **Show pre-release packages** and select **ApplicationInsights SDK for Xamarin*
5. Click the **Add Package** button
6. Repeat those steps for all other platform projects

### 4.2 Configure the instrumentation key

Please see the "[Getting an Application Insights Instrumentation Key](https://github.com/Microsoft/ApplicationInsights-Home/wiki#getting-an-application-insights-instrumentation-key)" section of the wiki for more information on acquiring a key.

### 4.3 Add code to setup and start Application Insights

1. Depending on the platforms you want to support, you can setup and start the Application Insights Xamarin SDK in different files:
	* **Xamarin.Forms** (Android & iOS): Application class (e.g. *project_name*.cs in the apps shared project
	* **iOS only**: AppDelegate.cs in your iOS platform project
	* **Android only**: Main Activity of your Android platform project
2. Add using statements

	```csharp
	using AI.XamarinSDK;
	```
	
3. Add the following lines of code to on of the following methods 
	* **Xamarin.Forms** (Android & iOS): `OnStart ()`
	* **iOS only**: `FinishedLaunching()`
	* **Android only**: `OnStart ()`

		```csharp
		CrossApplicationInsights.Current.Setup("<YOUR_IKEY_HERE>");
      	CrossApplicationInsights.Current.Start();
		```
		
3. Replace `<YOUR_IKEY_HERE>`with the instrumentation key of your app.
	
**Congratulation, now you're all set to use Application Insights! See [Usage](#6) on how to use Application Insights.**

## <a name="5"></a> 5. Developer Mode

The **developer mode** is enabled automatically in case the debugger is attached or if the app is running in the emulator. This will enable the console logging and decrease the number of telemetry items per batch as well as the sending interval. If you don't want this behavior, disable the **developer mode**.

You can explicitly enable/disable the developer mode like this:

```csharp
ApplicationInsights.SetDebugLogEnabled(false);
```

## <a name="6"></a> 6. Basic Usage  ##

The ```CrossTelemetryManager``` provides various class methods to track events, traces, metrics page views, and handled exceptions. The class should only be used after *CrossApplicationInsights* has been [set up & started](#4).

```csharp
//track an event
CrossTelemetryManager.Current.TrackEvent ("My custom event");

//track a page view
CrossTelemetryManager.Current.TrackPageView ("My custom page view");

//track a trace
CrossTelemetryManager.Current.TrackTrace ("My custom message");

//track a metric
CrossTelemetryManager.Current.TrackMetric ("My custom metric", 2.2);

//track handled exceptions
try {            
	int value = 1 / int.Parse("0");
}catch (Exception e){ 
	CrossTelemetryManager.Current.TrackManagedException (e, true);
}
```

Some data types allow for custom properties.

```csharp
//Setup a custom property
Dictionary<string, string> properties = new Dictionary<string, string> ();
properties.Add ("Xamarin Key", "Custom Property Value");

//track an event with custom properties
CrossTelemetryManager.Current.TrackEvent ("My custom event", properties);

```

## <a name="7"></a>7. Automatic collection of life-cycle events (Sessions & Page Views)

Auto collection is **enabled by default**. However, you can disable automatic page view tracking & session management while setting up `ApplicationInsight`. 

### Android

To support the auto collection feature make sure the min SDK of your app is at least API level 14. 

[**NOTE**] Only 'Activity' instances will be recognized by auto collection. Note that using e.g. `Navigation.PushAsync()` within a Xamarin.Forms page will replace a `Fragment`. However, you can programmatically [track a page view](#6) in situations like this.

### All plattforms

If you want to explicitly **Disable** automatic collection of life-cycle events (auto session tracking and auto page view tracking), call make the following calls inbetween setup and start of Application Insights. 

```csharp
//after CrossApplicationInsights.Current.Setup(...);
CrossApplicationInsights.Current.SetAutoPageViewTrackingDisabled(true);
CrossApplicationInsights.Current.SetAutoSessionManagementDisabled(true);
//before **CrossApplicationInsights.Current.Start()
```

## <a name="8"></a>8. Exception Handling (Crashes)

The Application Insights Xamarin SDK enables crash reporting **per default**. Unhandled exceptions from managed (C# code) & unmanaged code (Java / native library) will be sent to the server as soon as possible: On Android this mighthappen even before the app crashes. For iOS builds unhandled exceptions will be reported right after the next app start.

This feature can be disabled as follows:

```java
//after CrossApplicationInsights.Current.Setup(...);
CrossApplicationInsights.Current.SetCrashManagerDisabled(true);
//before CrossApplicationInsights.Current.Start()
```

To get more meaningful crash reports (File name and line numbers) you can change the **Debug Informations** level of your plattform specific app projects.

1. Right click on your Android or iOS app project in the Solution panel
2. Go to *Options* - *Compiler*
3. Set *Debug Informations* to `Full`. Make sure you have selected the right target (Debug/Release) before you check the results.

## <a name="9"></a>9. Additional Configuration

To configure Application Insights according to your needs, there are some other options listed here

### 9.1 Set User Session Time

The default time the users entering the app counts as a new session is 20s. If you want to set it to a different value, do the following:

```csharp
// app background time after which session will be renewed
CrossApplicationInsights.Current.SetSessionExpirationTime(30000)
```

### 9.2 Set Different Endpoint

You can also configure a different server endpoint for the SDK if needed:

```csharp
CrossApplicationInsights.Current.SetServerUrl("https://myServer.com/track");
```

### 9.3 Override sessionID and userID

Application Insights manages IDs for a session and for individual users for you. If you want to override the generated IDs with your own, it can be done like this:

```java
CrossApplicationInsights.Current.SetUserId("User371263");
CrossApplicationInsights.Current.RenewSession("New session ID");
```
[**NOTE**] If you want to manage sessions manually, please disable [Automatic Collection of Lifecycle Events](#7).

##<a name="10"></a> 10. Integrate plugin sources

There are several ways to integrate the Application Insights Xamarin SDK into your app. The recommend way is to use the NuGet-package. However, you can also integrate the SDK by importing the sources:

1. Copy *ApplicationInsightsXamarin* to your solution directory. 
2. Open Xamarin Studio and add its projects to your solution. This can be done by right clicking the solution name in the solution panel, then click *Add* - *Add Existing Project...*:

	* **AI.XamarinSDK**
	* **AI.XamarinSDK.Abstractions**
	* **AI.XamarinSDK.iOS** *(only needed for iOS support)*
	* **AI.XamarinSDK.Android** & **AI.XamarinSDK.AndroidBindings** *(only needed for Android support)*

	[**Note**] In order to successfully build the SDK, you may have to update all referenced packages. Simply right click on the *Packages* folder of each of those projects and click *Update*.

3. Add references to your app projects

	* **Android**

		1. In the solution panel, select the Android app project.
		2. In the main menu go to *Project* - *Edit References*.
		3. Select the *All* tab and check *AI.XamarinSDK.Absstractions*.
		4. Select the *All* tab and check *AI.XamarinSDK.Android*.
		5. Confirm the change by clicking the *OK* button.

	* **iOS**

		1. In the solution panel, select the iOS app project.
		2. In the main menu go to *Project* - *Edit References*.
		3. Select the *All* tab and check *AI.XamarinSDK.Absstractions*.
		4. Select the *All* tab and check *AI.XamarinSDK.iOS*.
		5. Confirm the change by clicking the *OK* button
	
	4. Follow instructions in [4.2](#4)..
		
##<a name="11"></a> 11. Troubleshooting

### SDK references broken

In order to successfully build the SDK, you may have to update all referenced packages. Simply right click on the *Packages* folder of each of those projects and click *Update*.

##<a name="12"></a> 12. Contact

If you have further questions or are running into trouble that cannot be resolved by any of the steps here, feel free to contact us at [AppInsights-Xamarin@microsoft.com](mailto:AppInsights-Xamarin@microsoft.com)
