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

    // Publik metod för att initiera en scenövergång
    public void GoToScene()
    {
        // Startar koroutinen för scenövergången
        StartCoroutine(GoToSceneRoutine());
    }   

    // Korutin som hanterar scenövergången
    IEnumerator GoToSceneRoutine()
    {
        // Initierar en fade-out-effekt med hjälp av FadeOut-metoden från FadeScreen-skriptet
        fadeScreen.FadeOut();
        // Väntar under tiden för effektens varaktighet
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        // Laddar nästa scen med hjälp av SceneManager och ökar scenindex
        SceneManager.LoadScene(m_LoadSceneIndex);
    }

    
}
