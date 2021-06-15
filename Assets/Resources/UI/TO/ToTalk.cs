using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ToTalk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Action action_1 = () => {
           //載入到information scene
           SceneManager.LoadScene("About");
       };
        Action action_2 = () => {
            //載入到 q scene
            SceneManager.LoadScene("Instruction");
        };
     
        Action action_3 = () => {
            //載入到market scene
            SceneManager.LoadScene("Market");
        };




        //////////
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            PopUp popup = UIController.Instance.CreatePopup();
            popup.Init(UIController.Instance.MainCanvas,
                "About this shop",
                "I’m confused",
                "Window Shopping",
                "nothing thank you ~",
                action_1, action_2, action_3
                );
        });
    }


}
