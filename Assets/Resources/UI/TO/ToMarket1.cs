﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ToMarket1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Market1");
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
