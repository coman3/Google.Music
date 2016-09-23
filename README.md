# Google Play Music API Written in C Sharp (C\#)

# Build Status: ![GoogleMusicApi MyGet Build Status](https://www.myget.org/BuildSource/Badge/google-music-api?identifier=4920bf3e-a903-4f38-b8ca-2672c6b14dad)
An Unofficial Google Play Music API Developed from the Google Play Music Android App (GoogleMusicApi.Common.MobileClient).

# Documentation / Support
Please go checkout the [Wiki](https://github.com/coman3/Google.Music/wiki) it contains an overview and some guides on how to get started with using Google Play Music API.

# Installation
#### NuGet
- .NET 4.5.2+ / UWP (Windows 10): `Install-Package Google.Music.Api`

#### Manual Reference
- Download [Release](https://github.com/coman3/Google.Music/releases)

# Usage
Checkout the Wiki for full information, but basic usage (getting a stream URL) looks like:
```
// ### Login ###
var mobileClient = new MobileClient();
if (await mc.LoginAsync("iAmARandom@gmail.com" /* can also be "iAmARandom" */, "randomPassword1"))
{
    Console.WriteLine("Logged In!");

    // ### Get Listen Now Situations (What you see when you first open the app) ###
    ListListenNowSituationResponse listenNowSituations = await mc.ListListenNowSituationsAsync();

    // ... Get Data from listen Now Situations ...

    Track track = /*  collected track from something */;

    // ### Get Stream Url ###
    Uri url = await mc.GetStreamUrlAsync(track);

    // ... Do what ever you want with stream URI ...
}
else
{
    Console.WriteLine("Login Failed!");
}

```

# Contributing
Any Contribution is greatly appreciated and will be fully documented and credited. If you wish to contribute to this project please go ahead :)

If you don't know what to do, there is a massive list of \`TODO (): \` lines, specifying what needs to be done, plus bug testing is always greatly appreciated.

Thanks for your help in advance :)

# Get In Touch
If you have any questions don't hesitate to email me at [dev.lvelden@gmail.com](mailto:dev.lvelden@gmail.com) or leave an issue.
