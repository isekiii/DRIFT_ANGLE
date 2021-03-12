using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    
    public void LoadMap (int mapIndex)
    {
        StartCoroutine(LoadAsynchronously(mapIndex));
    }

    IEnumerator LoadAsynchronously (int mapIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(mapIndex);

        loadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            //Debug.Log(progress);

            yield return null;
        }
    }
}
