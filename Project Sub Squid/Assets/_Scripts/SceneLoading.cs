using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{

    public int sceneId;

    public Image loadingImg;
    public Text progressText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AsyncLoad());
    }

    
        IEnumerator AsyncLoad()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
            while(!operation.isDone)
            {
                float progress = operation.progress / 0.9f;
                loadingImg.fillAmount = progress;
                progressText.text = string.Format("{0:0}");
                yield return null;

            }

        }
    
}
