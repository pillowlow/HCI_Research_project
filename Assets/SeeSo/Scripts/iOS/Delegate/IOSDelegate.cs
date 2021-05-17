﻿using System;

public class IOSDelegate
{
    public delegate void initialized_gaze_tracker(int error);
    public delegate void status_on_start();
    public delegate void status_on_stop(int error);
    public delegate void gaze_info(long timestamp, float x, float y, int trackingState, int eyeMovementState, int screenState);
    public delegate void calibration_on_next(float x, float y);
    public delegate void calibration_on_progress(float progress);
    public delegate void calibration_on_finished(IntPtr calibrationData, int length);
}
