using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PopUp : MonoBehaviour
{

    [SerializeField] Button _button_1;
    [SerializeField] Button _button_2;
    [SerializeField] Button _button_3;
    [SerializeField] Button _button_4;
    [SerializeField] Text _buttext_1;
    [SerializeField] Text _buttext_2;
    [SerializeField] Text _buttext_3;
    [SerializeField] Text _buttext_4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Init(Transform canvas,string text_1, string text_2, string text_3, string text_4, Action action_1,Action action_2 , Action action_3)
    {
        _buttext_1.text = text_1;
        _buttext_2.text = text_2;
        _buttext_3.text = text_3;
        _buttext_4.text = text_4;

        transform.SetParent(canvas);
        transform.localScale = Vector3.one;
        transform.localPosition = Vector3.zero;

        //GetComponent<RectTransform>().offsetMin = Vector2.zero;
        //GetComponent<RectTransform>().offsetMax = Vector2.zero;


        _button_1.onClick.AddListener(() =>
        {
            action_1();
            GameObject.Destroy(this.gameObject);
        });

        _button_2.onClick.AddListener(() =>
        {
            action_2();
            GameObject.Destroy(this.gameObject);
        });
        _button_3.onClick.AddListener(() =>
        {
            action_3();
            GameObject.Destroy(this.gameObject);
        });

        _button_4.onClick.AddListener(() =>
        {
            GameObject.Destroy(this.gameObject);
        });
    }
}
