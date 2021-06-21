using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectSetting : MonoBehaviour
{
    public GameObject Hand;
    void Start()
    {
        GazingBlock.GazeHand = Hand;
        GazingBlock.GazeInterval = 180;
        GazingBlock.GazeStandard = 0.75f;
    }
}
