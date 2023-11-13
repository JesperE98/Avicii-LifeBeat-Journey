using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public FadeScreen fadeScreen;
    private int m_sceneindex = 1;
    
    public void GoToScene()
    {
        StartCoroutine(GoToSceneRoutine());
    } 
    IEnumerator GoToSceneRoutine()
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        SceneManager.LoadScene(m_sceneindex++);
    }
}
