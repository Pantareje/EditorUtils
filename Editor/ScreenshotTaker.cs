using System;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ScreenshotTaker : EditorWindow
{
    const string SCREENSHOT_BASE_NAME = "Screenshot";

    [MenuItem("Tools/Screenshot Taker")]
    public static void ShowWindow() => GetWindow<ScreenshotTaker>("Screenshot Taker");

    [MenuItem("Tools/Take Screenshot %&s")] // Ctrl + Alt + S
    public static void TakeScreenshotHotkey() => TakeScreenshot();

    void OnGUI()
    {
        if (GUILayout.Button("Take Screenshot"))
            TakeScreenshot();
    }

    static void TakeScreenshot()
    {
        if (!EditorApplication.isPlaying) return;

        string folderPath = Path.Combine(Directory.GetParent(Application.dataPath)!.FullName, "Screenshots");

        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        string screenshotName = SCREENSHOT_BASE_NAME + "_" + timestamp + ".png";
        string screenshotPath = Path.Combine(folderPath, screenshotName);


        ScreenCapture.CaptureScreenshot(screenshotPath);
        Debug.Log("Screenshot saved at: " + screenshotPath);
    }
}