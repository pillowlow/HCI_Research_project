using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController2 : MonoBehaviour
{

    public static UIController2 Instance;

    public Transform MainCanvas;
        
    // Start is called before the first frame update
    void Start()
    {
      if( Instance != null)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

   public Pop_fav CreatePopup()
    {
        GameObject PopUpGo = Instantiate(Resources.Load("UI/PopOutfav")as GameObject);
        return PopUpGo.GetComponent<Pop_fav>();
    }
}
