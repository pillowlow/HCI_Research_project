using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ToHello : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {



        //////////
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            Pop_0 popup = UIController3.Instance.CreatePopup();
            popup.Init0(UIController3.Instance.MainCanvas,
                "continue",
                "return",
                "Hi There ~ How I help You?"
                );
        });
    }


}
