using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;


public class Pop_0 : MonoBehaviour
{
    [SerializeField] Button _button_1;
    [SerializeField] Text _buttext_1;
    [SerializeField] Button _button_2;
    [SerializeField] Text _buttext_2;
    [SerializeField] Text popupMessage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init0(Transform canvas, string text_1, string text_2, string text_message)
    {
        _buttext_1.text = text_1;

        transform.SetParent(canvas);
        transform.localScale = Vector3.one;
        transform.localPosition = Vector3.zero;


        _button_1.onClick.AddListener(() =>
        {//accept
            GameObject.Destroy(this.gameObject);
        });

        _button_2.onClick.AddListener(() =>
        {//xx
            
            GameObject.Destroy(this.gameObject);
        });
        
    }
}
