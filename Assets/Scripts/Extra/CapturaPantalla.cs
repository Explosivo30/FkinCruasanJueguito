using System;
using System.Collections;
using System.Collections.Generic;
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
        ScreenCapture.CaptureScreenshot("/Captures/" + DateTime.UtcNow, resolutionMultiplier);
    }
}
