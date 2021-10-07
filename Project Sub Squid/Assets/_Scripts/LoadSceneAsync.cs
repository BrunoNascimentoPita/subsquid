using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneAsync : MonoBehaviour
{
    public RadialGradiusBar radialBar;
    private AsyncOperation asyncLoad;

    public string sceneToLoad;


    // Start is called before the first frame update
    void Start()
    {
        radialBar.OnChange (this.OnRadialBarChange);
        radialBar.OnDone (this.OnRadialBarDone);
        StartCoroutine (this.LoadAsyncScene ());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnRadialBarChange(float value)
    {
        print ("radial progressa is : " + value);
    }

    void OnRadialBarDone()
    {
        print ("radial progressa is done!");
        asyncLoad.allowSceneActivation = true;
    }

    IEnumerator LoadAsyncScene()
    {
        asyncLoad = SceneManager.LoadSceneAsync (this.sceneToLoad);
        asyncLoad.allowSceneActivation = false;

        while(!asyncLoad.isDone)
        {
            radialBar.SetValue (Mathf.Clamp01 (asyncLoad.progress / 0.9f));
            yield return null;

        }

    }


}
