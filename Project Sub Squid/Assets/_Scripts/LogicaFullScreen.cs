using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaFullScreen : MonoBehaviour
{
    public Toggle toggle;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
           toggle.isOn = false; 
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivarFullScreen(bool fullScreenCompleto)
    {
        Screen.fullScreen = fullScreenCompleto;

    }
}
