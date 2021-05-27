
public class SeeSoBridgeManager
{
    private static SeeSoBridgeManager manager;

    protected StatusDelegate.onStarted onStarted;
    protected StatusDelegate.onStopped onStopped;
    protected GazeDelegate.onGaze onGaze;
    protected CalibrationDelegate.onCalibrationNextPoint onNextPoint;
    protected CalibrationDelegate.onCalibrationProgress onProgress;
    protected CalibrationDelegate.onCalibrationFinished onFinished;

    public static SeeSoBridgeManager SharedInstance()
    {
        if (manager == null)
        {
            manager = new SeeSoBridgeManager();
        }
        return manager;
    }

    public static void InitGazeTracker(string license, InitializationDelegate.onInitialized callback){}

    public static void DeinitGazeTracker(){}


    public virtual void StartTracking() { }

    public virtual void StopTracking() { }


    public virtual bool IsTracking() { return false; }

    public virtual bool SetTrackingFPS(int fps) { return false; }

    public virtual bool StartCalibration(CalibrationModeType mode, AccuracyCriteria criteria, float left, float top, float right, float bottom) { return false; }

    public virtual bool StartCalibration(CalibrationModeType mode, AccuracyCriteria criteria){ return false; }

    public virtual bool StartCalibration(float left, float top, float right, float bottom) { return false; }

    public virtual bool StartCalibration() { return false; }

    public virtual bool StartCollectSamples() { return false; }

    public virtual void StopCalibration() { }

    public virtual bool SetCalibrationData(double[] calibrationData) { return false; }

    public void SetStatusCallback(StatusDelegate.onStarted start, StatusDelegate.onStopped stop) {
        this.onStarted = start;
        this.onStopped = stop;
    }

    public void RemoveStatusCallback() {
        this.onStarted = null;
        this.onStopped = null;
    }

    public void SetGazeCallback(GazeDelegate.onGaze onGaze) {
        this.onGaze = onGaze;
    }

    public void RemoveGazeCallback() {
        this.onGaze = null;
    }

    public void SetCalibrationCallback(CalibrationDelegate.onCalibrationNextPoint nextPoint, CalibrationDelegate.onCalibrationProgress progress, CalibrationDelegate.onCalibrationFinished finished) {
        this.onNextPoint = nextPoint;
        this.onProgress = progress;
        this.onFinished = finished;
    }

    public void RemoveCalibrationCallback() {
        this.onNextPoint = null;
        this.onProgress = null;
        this.onFinished = null;
    }

    public static string GetVersionName() { return ""; }
}
