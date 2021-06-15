using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ToFavorite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Action action_1 = () => {
            //ADD TO FAVORITE
            //SceneManager.LoadScene("");
        };





        //////////
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            Pop_fav popup = UIController2.Instance.CreatePopup();
            popup.Init2(UIController2.Instance.MainCanvas,
                "NO",
                "ADD",
                "Do you want to add this to your “favorite” list ?It may become the referance of recommandation in the future ."
                ,action_1
                );
        });
    }


}
