using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Tolose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("lose");
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
