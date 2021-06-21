using System.Collections;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_ANDROID
using UnityEngine.Android;
#elif UNITY_IOS
using System.Runtime.InteropServices;
#endif

using UnityEngine.UI;
public class SeesoCombine : MonoBehaviour
{
    // public GameObject OverlayCanvas;

    // Status
    bool isInitialized;
    bool isTracking;

    // Buttons
    /* public GameObject Initialize;
    public GameObject Deinitialize;
    public GameObject StartTracking;
    public GameObject StopTracking; */

    public GameObject GameText;
    bool useFilteredGaze = true;
    GazeFilter gazeFilter = new GazeFilter();

    public void setUseFilteredGaze(bool b)
    {
        useFilteredGaze = b;
    }

    /* // Informations
    public GameObject GazePoint;

    public GameObject TrackingState; */
    TrackingState trackingState;

    // public GameObject EyeMovementState;
    EyeMovementState eyeMovementState;

    /* public GameObject TrackingFPS;
    public GameObject GameFPS; */


#if UNITY_IOS
    [DllImport("__Internal")]
    private static extern bool hasIOSCameraPermission();
    [DllImport("__Internal")]
    private static extern void requestIOSCameraPermission();
#endif

    // Tracking FPS
    int targetFPS;

    public void setCameraFpsRateFromSlider(float fps)
    {
        targetFPS = (int)fps;
    }

    public void lazySetCameraFpsRateFromSlider()
    {
        GazeTracker.setTrackingFPS(targetFPS);
    }

    bool isNewGaze;
    public float gazeX;
    public float gazeY;

    float systemWidth;
    float systemHeight;

    // For Orientation
    ScreenOrientation orientation;

    // Game FPS
    int trackingFPS;
    int trackingFPSCount;

    float timer, refresh, avgFramerate;


    void Start()
    {
        orientation = Screen.orientation;

        // portrait based
        systemWidth = Mathf.Min(Display.main.systemWidth, Display.main.systemHeight);
        systemHeight = Mathf.Max(Display.main.systemWidth, Display.main.systemHeight);

        // Request Camera Permission

        if (!HasCameraPermission())
        {
            RequestCameraPermission();
        }
        StartCoroutine(_checkTrackingFps());
        initialize();
    }

    bool HasCameraPermission()
    {
#if UNITY_ANDROID
        return Permission.HasUserAuthorizedPermission(Permission.Camera);
#elif UNITY_IOS
        return hasIOSCameraPermission();
#endif
    }

    void RequestCameraPermission()
    {
#if UNITY_ANDROID
        Permission.RequestUserPermission(Permission.Camera);
#elif UNITY_IOS
        requestIOSCameraPermission();
#endif
    }

    void Update()
    {
        // Orientation Check
        orientation = Screen.orientation;

        // Game FPS Check
        float timelapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;

        if (timer <= 0) avgFramerate = (int)(1f / timelapse);
        GameText.GetComponent<Text>().text = gazeX.ToString() + " , " + gazeY.ToString();
    }

    public void initialize()
    {
        if (isInitialized) return;

        GazeTracker.initGazeTracker("dev_t6nux5jke16k3j67g957olqxwmhetg9clcgu6p36", onInitialized);
    }

    public void deinitialize()
    {
        if (isTracking) stopTracking();
        GazeTracker.removeGazeCallback();
        GazeTracker.removeStatusCallback();
        GazeTracker.deinitGazeTracker();

        isInitialized = false;
    }

    public void startTracking()
    {
        if (isTracking) return;
        GazeTracker.setStatusCallback(onStarted, onStopped);
        GazeTracker.setGazeCallback(onGaze);
        GazeTracker.startTracking();
    }

    public void stopTracking()
    {
        GazeTracker.stopTracking();
        isTracking = false;
    }

    public void setTrackingFps(int fps)
    {
        GazeTracker.setTrackingFPS(fps);
    }

    void onStarted()
    {
        isTracking = true;
    }

    void onStopped(StatusErrorType error)
    {
        isTracking = false;
    }

    void onGaze(GazeInfo gazeInfo)
    {
        Debug.Log("onGaze " + gazeInfo.timestamp + "," + gazeInfo.x + "," + gazeInfo.y + "," + gazeInfo.trackingState + "," + gazeInfo.eyeMovementState + "," + gazeInfo.screenState);

        isNewGaze = true;

        trackingFPSCount++;
        trackingState = gazeInfo.trackingState;

        gazeX = gazeInfo.x;
        float screenHeight = systemHeight;
        if (orientation == ScreenOrientation.Landscape || orientation == ScreenOrientation.LandscapeLeft || orientation == ScreenOrientation.LandscapeRight)
        {
            screenHeight = systemWidth;
        }
        gazeY = screenHeight - gazeInfo.y;
        /*
        if (!useFilteredGaze)
        {
            gazeX = _convertCoordinateX(gazeInfo.x);
            gazeY = _convertCoordinateY(gazeInfo.y);

        }
        else
        {
            gazeFilter.filterValues(gazeInfo.timestamp, _convertCoordinateX(gazeInfo.x), _convertCoordinateY(gazeInfo.y));
            gazeX = gazeFilter.getFilteredX();
            gazeY = gazeFilter.getFilteredY();
        } */
    }

    public void onInitialized(InitializationErrorType error)
    {
        Debug.Log("onInitialized result : " + error);
        if (error == InitializationErrorType.ERROR_NONE)
        {
            isInitialized = true;
            startTracking(); // start immediately
        }
        else
        {
            isInitialized = false;
        }
    }

    float _convertCoordinateX(float x)
    {
        float screenWidth = systemWidth;
        if (orientation == ScreenOrientation.Landscape || orientation == ScreenOrientation.LandscapeLeft || orientation == ScreenOrientation.LandscapeRight)
        {
            screenWidth = systemHeight;
        }

        return gazeX = x / screenWidth - 0.5f;
    }

    float _convertCoordinateY(float y)
    {
        float screenHeight = systemHeight;
        if (orientation == ScreenOrientation.Landscape || orientation == ScreenOrientation.LandscapeLeft || orientation == ScreenOrientation.LandscapeRight)
        {
            screenHeight = systemWidth;
        }
        return gazeY = 0.5f - y / screenHeight;
    }

    IEnumerator _checkTrackingFps()
    {
        while (true)
        {
            trackingFPS = trackingFPSCount;
            trackingFPSCount = 0;
            yield return new WaitForSeconds(1f);
        }
    }
}
