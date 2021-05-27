using UnityEngine;

public class AndroidBridgeManager : SeeSoBridgeManager
{

    private AndroidBridgeManager()
    {

    }

    private static AndroidBridgeManager manager;

    //delegate
    private InitializationDelegate.onInitialized onInitialized;

    //proxy
    private InitailizationCallback_Proxy initializationCallback_Proxy;
    private StatusCallback_Proxy statusCallback_Proxy;
    private GazeCallback_Proxy gazeCallback_Proxy;
    private CalibrationCallback_Proxy calibrationCallback_Proxy;

    //native
    private AndroidJavaObject nativeTracker;
    private AndroidJavaClass nativeGazeTrackerClass;

    private bool isInitializing = false;

    public new static AndroidBridgeManager SharedInstance()
    {
        if (manager == null)
        {
            manager = new AndroidBridgeManager();

        }
        return manager;
    }

    public new static void InitGazeTracker(string license, InitializationDelegate.onInitialized initialized)
    {
        SharedInstance().onInitialized = initialized;
        if (SharedInstance().nativeGazeTrackerClass == null)
        {
            SharedInstance().nativeGazeTrackerClass = new AndroidJavaClass("camp.visual.gazetracker.GazeTracker");
        }
        AndroidJavaClass GazeDevice = new AndroidJavaClass("camp.visual.gazetracker.device.GazeDevice");
        AndroidJavaClass Build = new AndroidJavaClass("android.os.Build");

        if (SharedInstance().nativeGazeTrackerClass != null && GazeDevice != null && Build != null)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject context = activity.Call<AndroidJavaObject>("getApplicationContext");
            AndroidJavaObject gazeDevice = new AndroidJavaObject("camp.visual.gazetracker.device.GazeDevice");

            if (!gazeDevice.Call<bool>("isCurrentDeviceFound"))
            {
                Vector2 customGazeDevice = CustomGazeDevice.getCustomGazeDevice();

                gazeDevice.Call("addDeviceInfo", Build.GetStatic<string>("MODEL"), customGazeDevice.x, customGazeDevice.y);
            }
            SharedInstance().InitProxy();
            SharedInstance().nativeGazeTrackerClass.CallStatic("initGazeTracker", context, gazeDevice, license, SharedInstance().initializationCallback_Proxy);
            SharedInstance().isInitializing = true;
        }

    }

    public new static void DeinitGazeTracker()
    {
        SharedInstance().ResetInstanceVariables();
        if (SharedInstance().nativeTracker != null)
        {
            SharedInstance().nativeGazeTrackerClass.CallStatic("deinitGazeTracker", SharedInstance().nativeTracker);
        }

        SharedInstance().nativeGazeTrackerClass = null;
    }

    public override void StartTracking()
    {
        if (nativeTracker != null)
        {
            Debug.Log("startTracking called");
            nativeTracker.Call("startTracking");
        }
        else
        {
            Debug.Log("startTracking call failed");
        }
    }

    public override void StopTracking()
    {
        if (nativeTracker != null)
        {
            nativeTracker.Call("stopTracking");
        }
    }

    public override bool IsTracking()
    {
        if (nativeTracker != null)
        {
            return nativeTracker.Call<bool>("isTracking");

        }
        return false;
    }

    public override bool SetTrackingFPS(int fps)
    {
        if (nativeTracker != null)
        {
            return nativeTracker.Call<bool>("setTrackingFPS", fps);
        }
        return false;
    }

    public void StatusStarted()
    {
        onStarted.Invoke();
    }

    public void StatusStopped(StatusErrorType error)
    {
        onStopped.Invoke(error);
    }

    public void CalibrationNextPoint(float x, float y)
    {
        onNextPoint.Invoke(x, y);
    }

    public void CalibrationProgress(float progress)
    {
        onProgress.Invoke(progress);
    }

    public void CalibrationFinished(double[] calibrationData)
    {
        onFinished.Invoke(calibrationData);
    }

    public void sendGazeInfo(GazeInfo gazeInfo)
    {
        onGaze.Invoke(gazeInfo);
    }

    public override bool StartCalibration(CalibrationModeType mode, AccuracyCriteria criteria, float left, float top, float right, float bottom)
    {
        if (nativeTracker != null)
        {
            AndroidJavaClass enumMode = new AndroidJavaClass("camp.visual.gazetracker.constant.CalibrationModeType");
            AndroidJavaClass enumCriteria = new AndroidJavaClass("camp.visual.gazetracker.constant.AccuracyCriteria");
            AndroidJavaObject _mode = enumMode.GetStatic<AndroidJavaObject>(mode.ToString());
            AndroidJavaObject _criteria = enumCriteria.GetStatic<AndroidJavaObject>(criteria.ToString());
            return nativeTracker.Call<bool>("startCalibration", _mode, _criteria, left, top, right, bottom);
        }
        return false;
    }

    public override bool StartCalibration(CalibrationModeType mode, AccuracyCriteria criteria)
    {
        if (nativeTracker != null)
        {
            AndroidJavaClass enumMode = new AndroidJavaClass("camp.visual.gazetracker.constant.CalibrationModeType");
            AndroidJavaClass enumCriteria = new AndroidJavaClass("camp.visual.gazetracker.constant.AccuracyCriteria");
            AndroidJavaObject _mode = enumMode.GetStatic<AndroidJavaObject>(mode.ToString());
            AndroidJavaObject _criteria = enumCriteria.GetStatic<AndroidJavaObject>(criteria.ToString());
            return nativeTracker.Call<bool>("startCalibration", _mode, _criteria);
        }
        return false;
    }

    public override bool StartCalibration(float left, float top, float right, float bottom)
    {
        if (nativeTracker != null)
        {
            return nativeTracker.Call<bool>("startCalibration", left, top, right, bottom);
        }
        return false;
    }

    public override bool StartCalibration()
    {
        if (nativeTracker != null)
        {
            return nativeTracker.Call<bool>("startCalibration");
        }
        return false;
    }

    public override void StopCalibration()
    {
        if (nativeTracker != null)
        {
            nativeTracker.Call("stopCalibration");
        }
    }

    public override bool StartCollectSamples()
    {
        if (nativeTracker != null)
        {
            return nativeTracker.Call<bool>("startCollectSamples");
        }
        return false;
    }

    public override bool SetCalibrationData(double[] calibrationData)
    {
        if (nativeTracker != null)
        {
            return nativeTracker.Call<bool>("setCalibrationData", calibrationData);
        }
        return false;
    }


    public new static string GetVersionName()
    {
        if (SharedInstance().nativeTracker != null)
        {
            return SharedInstance().nativeTracker.CallStatic<string>("getVersionName");
        }
        return "";
    }

    public void ResetInstanceVariables()
    {
        AndroidBridgeManager manager = AndroidBridgeManager.SharedInstance();
        if (manager != null)
        {
            manager.isInitializing = false;
            manager.initializationCallback_Proxy = null;
            manager.statusCallback_Proxy = null;
            manager.gazeCallback_Proxy = null;
            manager.calibrationCallback_Proxy = null;
            manager.onInitialized = null;
            manager.onStarted = null;
            manager.onStopped = null;
            manager.onGaze = null;
            manager.onNextPoint = null;
            manager.onProgress = null;
            manager.onFinished = null;
        }
    }

    public void ConnectNativeCallbacks(AndroidJavaObject nativeTracker, InitializationErrorType error)
    {
        if (nativeTracker != null)
        {
            this.nativeTracker = nativeTracker;
            this.nativeTracker.Call("setStatusCallback", statusCallback_Proxy);
            this.nativeTracker.Call("setGazeCallback", gazeCallback_Proxy);
            this.nativeTracker.Call("setCalibrationCallback", calibrationCallback_Proxy);
        }
        else
        {
            this.nativeTracker = null;
        }
        onInitialized(error);
        manager.isInitializing = false;
        isInitializing = false;
    }

    private void InitProxy()
    {
        initializationCallback_Proxy = new InitailizationCallback_Proxy();
        statusCallback_Proxy = new StatusCallback_Proxy();
        gazeCallback_Proxy = new GazeCallback_Proxy();
        calibrationCallback_Proxy = new CalibrationCallback_Proxy();
    }
}