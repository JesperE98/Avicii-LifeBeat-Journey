using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    // Referens till skriptet FadeScreen
    public FadeScreen fadeScreen;

    // Initialt scenindex
    [SerializeField]
    private int m_LoadSceneIndex = 0;

    // Publik metod f�r att initiera en scen�verg�ng
    public void GoToScene()
    {
        // Startar koroutinen f�r scen�verg�ngen
        StartCoroutine(GoToSceneRoutine());
    }   

    // Korutin som hanterar scen�verg�ngen
    IEnumerator GoToSceneRoutine()
    {
        // Initierar en fade-out-effekt med hj�lp av FadeOut-metoden fr�n FadeScreen-skriptet
        fadeScreen.FadeOut();
        // V�ntar under tiden f�r effektens varaktighet
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        // Laddar n�sta scen med hj�lp av SceneManager och �kar scenindex
        SceneManager.LoadScene(m_LoadSceneIndex);
    }

    
}
