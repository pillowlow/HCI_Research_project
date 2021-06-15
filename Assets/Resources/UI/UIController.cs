using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public static UIController Instance;

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

   public PopUp CreatePopup()
    {
        GameObject PopUpGo = Instantiate(Resources.Load("UI/PopOut_")as GameObject);
        return PopUpGo.GetComponent<PopUp>();
    }
}
