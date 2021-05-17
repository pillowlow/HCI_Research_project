using UnityEngine;
using System.Collections.Generic;


public static class CustomGazeDevice
{
    static Dictionary<string, Vector2> customGazeDevices = new Dictionary<string, Vector2>()
    {
      {"NOT_SUPPORTED_DEFAULT", new Vector2(-57f, 3f)},
      //{"deviceModel", new Vector2(ScreenOrigin x1, ScreenOrigin y1) }
    };

    public static Vector2 getCustomGazeDevice()
    {

        string model = "NOT_SUPPORTED_DEFAULT";

        AndroidJavaClass Build = new AndroidJavaClass("android.os.Build");

        if(Build != null)
        {
            model = Build.GetStatic<string>("MODEL");
        }

        Debug.Log("Current Device Model : " + Build.GetStatic<string>("MODEL"));

        if (customGazeDevices.ContainsKey("model"))
        {
            return customGazeDevices[model];
        }
        else
        {
            return customGazeDevices["NOT_SUPPORTED_DEFAULT"];
        }
    }
}



/*
 * * * * * * Currently supported gaze devices * * * * * * * *
    //Galaxy S9 
    SM_G960N("SM-G960N", -45f, 3f),

    //Galaxy S10 5G
    SM_G977N("SM-G977N", -57f, 3f),

    //Galaxy S9+
    SM_G965N("SM-G965N", -50f, -3f),

    //Galaxy S9
    SM_G960N("SM-G960N", -45f, -3f),

    //Galaxy S8
    SM_G950N("SM-G950N", -45f, -3f),

    //Galaxy S7
    SM_G930L("SM-G930L", -55f, -9f),

    //LG v10
    LG_F600S("LG-F600S", -12f, -5.5f),

    //LG G8
    LM_G820N("LM-G820N", -25f, 1f),

    //Oppo FindX
    PAFM00("PAFM00", -52f, -5.5f),

    //Oppo reno3 pro
    PCRM00("PCRM00", -7.5f, 4f), 

    //Galaxy Tab S7+ // Galaxy Tab S7+ 5G
    SM_T975("SM-T975", -172f, 133f),
    SM_T975N("SM-T975N", -172f, 133f),
    SM_T970("SM-T970", -172f, 133f),
    SM_T976B("SM-T976B", -172f, 133f),
    SM_T976N("SM-T976N", -172f, 133f),
    SM_T978U("SM-T978U", -172f, 133f),

    //Galaxy Tab S7
    SM_T875("SM-T875", -152f, 118f),
    SM_T875N("SM-T875N", -152f, 118f),
    SM_T870("SM-T870", -152f, 118f),
    SM_T878U("SM-T878U", -152f, 118f),

    //Galaxy Tab S6 Lite
    SM_P615N("SM-P615N", -68f, -5f),
    SM_P615("SM-P615", -68f, -5f),
    SM_P610N("SM-P610N", -68f, -5f),
    SM_P610("SM-P610", -68f, -5f),
    SM_P615C("SM-P615C", -68f, -5f),
    SM_P617("SM-P617", -68f, -5f),
    SM_P610X("SM-P610X", -68f, -5f),

    //Galaxy Tab S6
    SM_T865N("SM-T865N", -71f, -5f),
    SM_T865("SM-T865", -71f, -5f),
    SM_T867("SM-T867", -71f, -5f),
    SM_T867R4("SM-T867R4", -71f, -5f),
    SM_T867U("SM-T867U", -71f, -5f),
    SM_T867V("SM-T867V", -71f, -5f),
    SM_T860("SM-T860", -71f, -5f),

    //Galaxy Tab S5e
    SM_T720("SM-T720", -72f, -4f),
    SM_T725("SM-T725", -72f, -4f),
    SM_T725C("SM-T725C", -72f, -4f),
    SM_T725N("SM-T725N", -72f, -4f),
    SM_T727("SM-T727", -72f, -4f),
    SM_T727A("SM-T727A", -72f, -4f),
    SM_T727R4("SM-T727R4", -72f, -4f),
    SM_T727U("SM-T727U", -72f, -4f),
    SM_T727V("SM-T727V", -72f, -4f),

    //Galaxy Tab S4
    SM_T835("SM-T835", -71f, -5f),
    SM_T837("SM-T837", -71f, -5f),
    SM_T837A("SM-T837A", -71f, -5f),
    SM_T835C("SM-T835C", -71f, -5f),
    SM_T835N("SM-T835N", -71f, -5f),
    SM_T837P("SM-T837P", -71f, -5f),
    SM_T837T("SM-T837T", -71f, -5f),
    SM_T837R4("SM-T837R4", -71f, -5f),
    SM_T837V("SM-T837V", -71f, -5f),
    SM_T830("SM-T830", -71f, -5f),

    //Galaxy Tab A 10.5 (2018)
    SM_T595("SM-T595", -71f, -9f),
    SM_T597("SM-T597", -71f, -9f),
    SM_T595C("SM-T595C", -71f, -9f),
    SM_T595N("SM-T595N", -71f, -9f),
    SM_T590("SM-T590", -71f, -9f),

    //Galaxy Tab A 10.1 (2019)
    SM_T515("SM-T515", -68f, -7f),
    SM_T515N("SM-T515N", -68f, -7f),
    SM_T517P("SM-T517P", -68f, -7f),
    SM_T510("SM-T510", -68f, -7f),
    SM_T517("SM-T517", -68f, -7f),

    //Galaxy Tab A 8.0 with S Pen (2019)
    SM_P205("SM-P205", -64f, -6f),
    SM_P200("SM-P200", -64f, -6f),

    //Galaxy Tab A 8.0 (2019)
    SM_T295("SM-T295", -36f, -8f),
    SM_T295C("SM-T295C", -36f, -8f),
    SM_T295N("SM-T295N", -36f, -8f),
    SM_T297("SM-T297", -36f, -8f),
    SM_T290("SM-T290", -36f, -8f),

    //Galaxy Tab A7 10.4 (2020)
    SM_T505("SM-T505", -140f, 112f),
    SM_T505C("SM-T505C", -140f, 112f),
    SM_T505N("SM-T505N", -140f, 112f),
    SM_T507("SM-T507", -140f, 112f),
    SM_T500("SM-T500", -140f, 112f),

    //Galaxy Tab A 8.4 (2020)
    SM_T307U("SM-T307U", -57f, -5f),

    //Galaxy Tab4 10.1
    SM_T536("SM-T536", -145f, 89f),
    SM_T533("SM-T533", -145f, 89f),
    SM_T530("SM-T530", -145f, 89f),
    SM_T530X("SM-T530X", -145f, 89f),
    SM_T530NU("SM-T530NU", -145f, 89f),

    //Galaxy Tab A (2016) with S Pen
    SM_P580("SM-P580", -90f, -8f),
    SM_P585("SM-P585", -90f, -8f),
    SM_P585M("SM-P585M", -90f, -8f),
    SM_P585Y("SM-P585Y", -90f, -8f),
    SM_P587("SM-P587", -90f, -8f),
    SM_P588C("SM-P588C", -90f, -8f),
    SM_P585N0("SM-P585N0", -90f, -8f),
    SM_P583("SM-P583", -90f, -8f),

    //G Pad 5 10.1 FHD
    LM_T600("LM-T600", -68f, -8f),
    LM_T600L("LM-T600L", -68f, -8f),
    LM_T605("LM-T605", -68f, -8f),

    // MI Pad 4
    MI_PAD_4("MI PAD 4", -54f, -6f),

    //MediaPad M5 10.8 //vMediaPad M5 10.8 Pro
    CMR_AL09("CMR-AL09", -150f, 116f),
    CMR_W09("CMR-W09", -150f, 116f),
    CMR_AL19("CMR-AL19", -150f, 116f),
    CMR_W19("CMR-W19", -150f, 116f),

    //MediaPad M5 8.4
    SHT_AL09("SHT-AL09", -57f, -5f),
    SHT_W09("SHT-W09", -57f, -5f),

    //MediaPad M5 lite
    BAH2_L09("BAH2-L09", -141f, 108f),
    BAH2_W19("BAH2-W19", -141f, 108f),
    JDN2_L09("JDN2-L09", -141f, 108f),
    JDN2_W09("JDN2-W09", -141f, 108f);

 * Please check more available devices in SeeSo documentation
 
 * * * * * * How to calculate Screen Origin (x1,y1) * * * * *
 * 
 *                                ^ +(y axis)
 *                                |
 *   -----------------------------|-------------------
 *   ||                           |                 ||
 *   ||                           O --------------------> +(x axis)
 *   ||                     (Camera (0, 0))         ||
 *   ||                                             ||
 *   ||-----------------------------------------------
 *   |o(Screen Origin(x1, y1))------------------------
 *   ||          Screen                             ||
 *   ||                                             ||
 *
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *     
 */
