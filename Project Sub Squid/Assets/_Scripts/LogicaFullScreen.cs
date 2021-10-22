using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicaFullScreen : MonoBehaviour
{
    public Toggle toggle;
    
    public TMP_Dropdown resolutionDropDown;
    Resolution [] resolutions;

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

        RevisarResolution();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivarFullScreen(bool fullScreenCompleto)
    {
        Screen.fullScreen = fullScreenCompleto;

    }

    public void RevisarResolution()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();
        int resolutionActual = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            
            if (Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                resolutionActual = i;

            }

        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = resolutionActual;
        resolutionDropDown.RefreshShownValue();

        resolutionDropDown.value = PlayerPrefs.GetInt("numeroResolution", 0);
    }

    public void CambiarResolution(int indiceResolution)
    {
        PlayerPrefs.SetInt("numeroResolution", resolutionDropDown.value);

        Resolution resolution = resolutions[indiceResolution];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }



}
