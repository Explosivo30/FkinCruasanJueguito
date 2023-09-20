using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CapturaPantalla : MonoBehaviour
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Window/Screenshot/DefaultRes")]
    static void TakeScreenshot()
    {
        MakeScreenshot();
    }
    [UnityEditor.MenuItem("Window/Screenshot/DoubleRes")]
    static void TakeScreenshotSuper()
    {
        MakeScreenshot(2);
    }
#endif

    public static void MakeScreenshot(int resolutionMultiplier = 1)
    {
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.CreateFolder("", "Captures");
#else
        Directory.CreateDirectory("Captures");
#endif
        ScreenCapture.CaptureScreenshot("Captures/Screenshot_" + DateTime.Now.Ticks + ".png", resolutionMultiplier);
    }
}
