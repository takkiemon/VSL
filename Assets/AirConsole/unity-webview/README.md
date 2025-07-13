# ndream-unity-webview

ndream-unity-webview is a plugin for Unity 5 and higher.
The goal is to bring it to the highest possible performance in its respective target use cases.

It is opmtised for usage in the [AirConsole Unity Plugin](https://github.com/airconsole/airconsole-unity-plugin) where it provides

| Platform | Features                                                     |
| -------- | ------------------------------------------------------------ |
| Android  | native WebView, WebRTC, WebSockets                           |
| OSX      | WebRTC, WebSockets                                           |
| Windows  | At this time,  Windows is not supported as per version 1.0.0 |

## Change Log

Please see [Change Log](./CHANGES.md) for details.

unity-webview is derived from

- keijiro-san's <https://github.com/keijiro/unity-webview-integration>
- GREE Incs <https://github.com/gree/unity-webview> (fork)

## Sample Project

It is placed under `sample/`. You can open it and import the plugin as
below:

1. Open `sample/Assets/Sample.unity`.
2. Open `dist/ndream-unity-webview-v1.0.0.unitypackage` and import all files.

## Platform Specific Notes

### OS X (Editor)

The implementiation does not support rendering a webview.

### Android

*NOTE: the following steps are now performed by Assets/Plugins/Android/Editor/UnityWebViewPostprocessBuild.cs.*

Once you built an apk, please copy
`sample/Temp/StatingArea/AndroidManifest-main.xml` to
`sample/Assets/Plugins/Android/AndroidManifest.xml`, edit the latter to add
`android:hardwareAccelerated="true"` to `<activity
android:name="com.unity3d.player.UnityPlayerActivity" ...`, and
rebuilt the apk. Although some old/buggy devices may not work well
with `android:hardwareAccelerated="true"`, the WebView runs very
smoothly with this setting.

*NOTE: Unity 5.6.1p4 or newer (including 2017 1.0) seems to fix the issue. cf. <https://github.com/gree/unity-webview/pull/212#issuecomment-314952793>*

For Unity 5.6.0 and 5.6.1 (except 5.6.1p4), you also need to modify `android:name` from
`com.unity3d.player.UnityPlayerActivity` to
`net.gree.unitywebview.CUnityPlayerActivity`. This custom activity
implementation will adjust Unity's SurfaceView z order. Please refer
`plugins/Android/src/net/gree/unitywebview/CUnityPlayerActivity.java`
and `plugins/Android/src/net/gree/unitywebview/CUnityPlayer.java` if
you already have your own activity implementation.
