## Vibrate Plugin for Xamarin and Windows
Simple and elegant way to trigger the vibration on a device in your Xamarin.iOS, Xamarin.Android, Windows, and Xamarin.Forms projects.

### Setup
* Available on NuGet: https://www.nuget.org/packages/Xam.Plugins.Vibrate [![NuGet](https://img.shields.io/nuget/v/Xam.Plugins.Vibrate.svg?label=NuGet)](https://www.nuget.org/packages/Xam.Plugins.Vibrate/)
* Install into your PCL project and Client projects.

Build status: [![Build status](https://ci.appveyor.com/api/projects/status/pm68wxtxmudjiml1?svg=true)](https://ci.appveyor.com/project/JamesMontemagno/vibrateplugin)

**Platform Support**

|Platform|Supported|Version|
| ------------------- | :-----------: | :------------------: |
|Xamarin.iOS|Yes|iOS 7+|
|Xamarin.iOS Unified|Yes|iOS 7+|
|Xamarin.Android|Yes|API 10+|
|Windows Phone Silverlight|Yes|8.0+|
|Windows Phone RT|Yes|8.1+|
|Windows Store RT|---|8.1+|
|Windows 10 UWP|Yes|10+|
|Xamarin.Mac|No||


### API Usage

To gain access to the Vibrate class simply use this method:

```csharp
var v = CrossVibrate.Current;
v.Vibration(1000); // 1 second vibration
```

#### Methods

```csharp
/// <summary>
/// Vibrate the phone for specified amount of time
/// </summary>
/// <param name="milliseconds">Time in Milliseconds to vibrate. 500ms is default</param>
void Vibration(int milliseconds = 500);
```


#### Platform Tweaks

**iOS**
There is no API to vibrate for a specific amount of time, so it will vibrate for the default time the system specifies (around 500 milliseconds..

**Android**
The `android.permission.VIBRATE` permission will automatically be added for you into your AndroidManifest.xml


#### Contributions
Contributions are welcome! If you find a bug please report it and if you want a feature please report it.

If you want to contribute code please file an issue and create a branch off of the current dev branch and file a pull request.

#### License
Under MIT, see LICENSE file.
