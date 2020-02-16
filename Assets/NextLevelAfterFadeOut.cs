using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelAfterFadeOut : MonoBehaviour
{
    public Animator anim;
    void Awake()
    {
        StartCoroutine(LoadNextLevel());
    }
    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0).GetLength(0));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
