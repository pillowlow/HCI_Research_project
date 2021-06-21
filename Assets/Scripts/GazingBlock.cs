using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazingBlock : MonoBehaviour
{
    public static GameObject GazeHand;
    public static int GazeInterval;
    public static float GazeStandard;
    Collider2D ObjectCollider;
    bool[] IsGazing = new bool[GazeInterval];
    int IndexNow = 0;

    // Start is called before the first frame update
    void Start()
    {
        ObjectCollider = GetComponent<Collider2D>();
        for (int i = 0; i < GazeInterval; i++)
        {
            IsGazing[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        IsGazing[IndexNow] = (transform.position.x <= GazeHand.transform.position.x && transform.position.y <= GazeHand.transform.position.y && transform.position.x + ObjectCollider.bounds.size.x >= GazeHand.transform.position.x && transform.position.y <= GazeHand.transform.position.y);
        IndexNow++;
        if(IndexNow >= GazeInterval)
        {
            IndexNow = 0;
        }
        int GazingPercent = 0;
        for (int i = 0; i < GazeInterval; i++)
        {
            if (IsGazing[i])
            {
                GazingPercent++;
            }
        }
        if (GazingPercent / (float)GazeInterval >= GazeStandard)
        {
            OnGazeSuccess();
        }
        Debug.Log(Time.deltaTime);
    }

    void OnGazeSuccess()
    {

    }
}
