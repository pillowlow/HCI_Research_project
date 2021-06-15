using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController3 : MonoBehaviour
{

    public static UIController3 Instance;

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

   public Pop_0 CreatePopup()
    {
        GameObject PopUpGo = Instantiate(Resources.Load("UI/PopOut00")as GameObject);
        return PopUpGo.GetComponent<Pop_0>();
    }
}
