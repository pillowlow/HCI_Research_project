using UnityEngine;
public class GazeTracker
{

    public static void initGazeTracker(string license, InitializationDelegate.onInitialized callback)
    {
#if UNITY_ANDROID
        AndroidBridgeManager.InitGazeTracker(license, callback);
#elif UNITY_IOS
        IOSBridgeManager.InitGazeTracker(license, callback);
#endif
    }

    public static void deinitGazeTracker()
    {
#if UNITY_ANDROID
        AndroidBridgeManager.DeinitGazeTracker();
#elif UNITY_IOS
        IOSBridgeManager.DeinitGazeTracker();
#endif
    }

    public static void startTracking()
    {
#if UNITY_ANDROID
        AndroidBridgeManager.SharedInstance().StartTracking();
#elif UNITY_IOS
        IOSBridgeManager.SharedInstance().StartTracking();
#endif
    }

    public static void stopTracking()
    {
#if UNITY_ANDROID
        AndroidBridgeManager.SharedInstance().StopTracking();
#elif UNITY_IOS
        IOSBridgeManager.SharedInstance().StopTracking();
#endif 
    }

    public static bool isTracking()
    {
#if UNITY_ANDROID
        return AndroidBridgeManager.SharedInstance().IsTracking();
#elif UNITY_IOS
        return IOSBridgeManager.SharedInstance().IsTracking();
#endif
    }

    public static bool setTrackingFPS(int fps)
    {
#if UNITY_ANDROID
        return AndroidBridgeManager.SharedInstance().SetTrackingFPS(fps);
#elif UNITY_IOS
        return IOSBridgeManager.SharedInstance().SetTrackingFPS(fps);
#endif 
    }

    public static bool startCalibration(CalibrationModeType mode, AccuracyCriteria criteria, float left, float top, float right, float bottom)
    {
#if UNITY_ANDROID
        return AndroidBridgeManager.SharedInstance().StartCalibration(mode, criteria, left, top, right, bottom);
#elif UNITY_IOS
        return IOSBridgeManager.SharedInstance().StartCalibration(mode, criteria, left, top, right, bottom);
#endif 
    }

    public static bool startCalibration(CalibrationModeType mode, AccuracyCriteria criteria)
    {
#if UNITY_ANDROID
        return AndroidBridgeManager.SharedInstance().StartCalibration(mode, criteria);
#elif UNITY_IOS
        return IOSBridgeManager.SharedInstance().StartCalibration(mode, criteria);
#endif 
    }

    public static bool startCalibration(float left, float top, float right, float bottom)
    {
#if UNITY_ANDROID
        return AndroidBridgeManager.SharedInstance().StartCalibration(left, top, right, bottom);
#elif UNITY_IOS
        return IOSBridgeManager.SharedInstance().StartCalibration(left, top, right, bottom);
#endif 
    }

    public static bool startCalibration()
    {
#if UNITY_ANDROID
        return AndroidBridgeManager.SharedInstance().StartCalibration();
#elif UNITY_IOS
        return IOSBridgeManager.SharedInstance().StartCalibration();
#endif 
    }

    public static void stopCalibration()
    {
#if UNITY_ANDROID
        AndroidBridgeManager.SharedInstance().StopCalibration();
#elif UNITY_IOS
        IOSBridgeManager.SharedInstance().StopCalibration();
#endif 
    }

    public static bool startCollectSamples()
    {
#if UNITY_ANDROID
        return AndroidBridgeManager.SharedInstance().StartCollectSamples();
#elif UNITY_IOS
        return IOSBridgeManager.SharedInstance().StartCollectSamples();
#endif 
    }

    public static bool setCalibrationData(double[] calibrationData)
    {
#if UNITY_ANDROID
        return AndroidBridgeManager.SharedInstance().SetCalibrationData(calibrationData);
#elif UNITY_IOS
        return IOSBridgeManager.SharedInstance().SetCalibrationData(calibrationData);
#endif 
    }

    public static void setStatusCallback(StatusDelegate.onStarted onStarted, StatusDelegate.onStopped onStopped)
    {
#if UNITY_ANDROID
        AndroidBridgeManager.SharedInstance().SetStatusCallback(onStarted, onStopped);
#elif UNITY_IOS
        IOSBridgeManager.SharedInstance().SetStatusCallback(onStarted, onStopped);
#endif 
    }

    public static void removeStatusCallback()
    {
#if UNITY_ANDROID
        AndroidBridgeManager.SharedInstance().RemoveStatusCallback();
#elif UNITY_IOS
        IOSBridgeManager.SharedInstance().RemoveStatusCallback();
#endif 
    }

    public static void setGazeCallback(GazeDelegate.onGaze onGaze)
    { 
#if UNITY_ANDROID
        AndroidBridgeManager.SharedInstance().SetGazeCallback(onGaze);
#elif UNITY_IOS
        IOSBridgeManager.SharedInstance().SetGazeCallback(onGaze);
#endif 
    }

    public static void removeGazeCallback()
    {
#if UNITY_ANDROID
        AndroidBridgeManager.SharedInstance().RemoveGazeCallback();
#elif UNITY_IOS
        IOSBridgeManager.SharedInstance().RemoveGazeCallback();
#endif 
    }

    public static void setCalibrationCallback(CalibrationDelegate.onCalibrationNextPoint onCalibrationNext, CalibrationDelegate.onCalibrationProgress onCalibrationProgress, CalibrationDelegate.onCalibrationFinished onCalibrationFinished)
    {
#if UNITY_ANDROID
        AndroidBridgeManager.SharedInstance().SetCalibrationCallback(onCalibrationNext, onCalibrationProgress, onCalibrationFinished);
#elif UNITY_IOS
        IOSBridgeManager.SharedInstance().SetCalibrationCallback(onCalibrationNext, onCalibrationProgress, onCalibrationFinished);
#endif 

    }

    public static void removeCalibrationCallback()
    {
#if UNITY_ANDROID
        AndroidBridgeManager.SharedInstance().RemoveCalibrationCallback();
#elif UNITY_IOS
        IOSBridgeManager.SharedInstance().RemoveCalibrationCallback();
#endif

    }

    public static string getVersionName()
    {
#if UNITY_ANDROID
        return AndroidBridgeManager.GetVersionName();
#elif UNITY_IOS
        return IOSBridgeManager.GetVersionName();
#endif 
    }
}
