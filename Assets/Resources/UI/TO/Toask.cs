﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Toask : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("tako_ask");
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
