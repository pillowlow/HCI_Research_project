using System.Collections;
using UnityEngine;
#if UNITY_ANDROID
using UnityEngine.Android;
#elif UNITY_IOS
using System.Runtime.InteropServices;
#endif

using UnityEngine.UI;
public class SeeSoExample : MonoBehaviour
{
    public GameObject OverlayCanvas;

    // Status
    bool isInitialized;
    bool isTracking;
    bool isCalibrating;

    // Buttons
    public GameObject Initialize;
    public GameObject Deinitialize;
    public GameObject StartTracking;
    public GameObject StopTracking;
    public GameObject StartCalibration;
    public GameObject StopCalibration;

    bool useFilteredGaze = true;
    GazeFilter gazeFilter = new GazeFilter();

    public void setUseFilteredGaze(bool b)
    {
        useFilteredGaze = b;
    }

    // Informations
    public GameObject GazePoint;

    public GameObject TrackingState;
    TrackingState trackingState;

    public GameObject EyeMovementState;
    EyeMovementState eyeMovementState;

    public GameObject TrackingFPS;
    public GameObject GameFPS;


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
        targetFPS = (int) fps;
    }

    public void lazySetCameraFpsRateFromSlider()
    {
        GazeTracker.setTrackingFPS(targetFPS);
    }

    bool isNewGaze;
    float gazeX;
    float gazeY;

    float systemWidth;
    float systemHeight;

    // For Orientation
    ScreenOrientation orientation;

    // For Calibration
    public GameObject CalibrationPoint;
    bool isNextStepReady;
    bool isCalibrationFinished;
    float calibrationProgress;
    float calibrationX;
    float calibrationY;

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
        GameFPS.GetComponent<Text>().text = "Game FPS : " + avgFramerate.ToString();


        // Tracking FPS Check
        TrackingFPS.GetComponent<Text>().text = "Tracking FPS : " + trackingFPS;


        if (isTracking)
        {
            if (isNewGaze)
            {
                Vector2 overlayCanvasSizeDelta = OverlayCanvas.GetComponent<RectTransform>().sizeDelta;
                GazePoint.GetComponent<RectTransform>().anchoredPosition = new Vector2(gazeX * overlayCanvasSizeDelta.x, gazeY * overlayCanvasSizeDelta.y);
                isNewGaze = false;
                TrackingState.GetComponent<Text>().text = "Gaze : " + trackingState.ToString();
                EyeMovementState.GetComponent<Text>().text = "Eye Movement : " + eyeMovementState.ToString();
            }

            if (isCalibrating)
            {
                GazePoint.SetActive(false);
            }
            else
            {
                GazePoint.SetActive(true);
            }
        }
        else
        {
            TrackingState.GetComponent<Text>().text = "Gaze : NONE";
            EyeMovementState.GetComponent<Text>().text = "Eye Movement : NONE";
            GazePoint.SetActive(false);
        }


        // Calibrate Progress
        if (isCalibrating)
        {
            CalibrationPoint.SetActive(true);

            if (isNextStepReady)
            {
                Vector2 overlayCanvasSizeDelta = OverlayCanvas.GetComponent<RectTransform>().sizeDelta;
                CalibrationPoint.GetComponent<RectTransform>().anchoredPosition = new Vector2(calibrationX * overlayCanvasSizeDelta.x, calibrationY * overlayCanvasSizeDelta.y);
                isNextStepReady = false;
                GazeTracker.startCollectSamples();
            }

            if (isCalibrationFinished)
            {
                isCalibrationFinished = false;
                isNextStepReady = false;
                isCalibrating = false;
            }

            if (CalibrationPoint.activeSelf)
            {
                CalibrationPoint.GetComponent<RawImage>().color = new Color(calibrationProgress, 0f, 0f);
            }

        }
        else
        {
            CalibrationPoint.SetActive(false);
        }

        // Button Visibility
        if (isInitialized)
        {
            Initialize.SetActive(false);
            Deinitialize.SetActive(true);
        }
        else
        {
            Initialize.SetActive(true);
            Deinitialize.SetActive(false);
        }

        if (isTracking)
        {
            StartTracking.SetActive(false);
            StopTracking.SetActive(true);
        }
        else
        {
            StartTracking.SetActive(true);
            StopTracking.SetActive(false);
        }

        if (isCalibrating)
        {
            StartCalibration.SetActive(false);
            StopCalibration.SetActive(true);
        }
        else
        {
            StartCalibration.SetActive(true);
            StopCalibration.SetActive(false);
        }
    }

    public void initialize()
    {
        if (isInitialized) return;

        GazeTracker.initGazeTracker("INPUT YOUR LICENSE KEY", onInitialized);
    }

    public void deinitialize()
    {
        if (isTracking) stopTracking();

        GazeTracker.removeCalibrationCallback();
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
        if (isCalibrating) stopCalibration();
        GazeTracker.stopTracking();
        isTracking = false;
    }

    public void startCalibration()
    {
        if (!isTracking) return;
        if (isCalibrating) return;

        GazeTracker.setCalibrationCallback(onCalibrationNextPoint, onCalibrationProgress, onCalibrationFinished);
        bool success = GazeTracker.startCalibration();

        if (!success)
        {
            Debug.Log("startCalibration() fail, please check camera permission OR call startTracking() First");
        }
        else
        {
            isCalibrating = true;
        }
    }

    public void stopCalibration()
    {
        if (!isCalibrating) return;

        GazeTracker.stopCalibration();

        isCalibrating = false;
        isNextStepReady = false;
        isCalibrationFinished = false;
    }

    public void setTrackingFps(int fps)
    {
        GazeTracker.setTrackingFPS(fps);
    }

    public void setCalibrationData(double[] calibrationData)
    {
        bool result = GazeTracker.setCalibrationData(calibrationData);
        Debug.Log("setCalibrationData : " + result);
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
        }
    }

    void onCalibrationNextPoint(float x, float y)
    {
        Debug.Log("onCalibrationNextPoint" + x + "," + y);

        calibrationX = _convertCoordinateX(x);
        calibrationY = _convertCoordinateY(y);
        isNextStepReady = true;
    }

    void onCalibrationProgress(float progress)
    {
        Debug.Log("onCalibrationProgress" + progress);
        calibrationProgress = progress;
    }
        
    void onCalibrationFinished(double[] calibrationData)
    {
        Debug.Log("OnCalibrationFinished" + calibrationData.Length);
        isCalibrationFinished = true;
    }

    public void onInitialized(InitializationErrorType error)
    {
        Debug.Log("onInitialized result : " + error);
        if(error == InitializationErrorType.ERROR_NONE)
        {
            isInitialized = true;
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
    