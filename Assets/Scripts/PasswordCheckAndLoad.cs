using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PasswordCheckAndLoad : MonoBehaviour
{
    public Text output;
    public GameObject error;
    public Dictionary<string, int> loadScene;

    private void Awake()
    {
        loadScene = new Dictionary<string, int>();
        loadScene.Add("intro", 1);
        loadScene.Add("meeting", 2);
        loadScene.Add("vertical", 3);
        loadScene.Add("spikes", 4);
        loadScene.Add("separation", 5);
        loadScene.Add("fast", 6);
        loadScene.Add("antispikes", 7);
        loadScene.Add("partners", 8);
        loadScene.Add("longdrop", 9);
        loadScene.Add("twoentrances", 10);
        loadScene.Add("limbo", 12);
    }

    public void PasswordCheck()
    {
        try
        {
            SceneManager.LoadScene(loadScene[output.text]);
        }
        catch (KeyNotFoundException)
        {
            StartCoroutine(errorTimer());
        }
    }

    IEnumerator errorTimer()
    {
        error.SetActive(true);
        yield return new WaitForSeconds(1f);
        error.SetActive(false);
    }
}
