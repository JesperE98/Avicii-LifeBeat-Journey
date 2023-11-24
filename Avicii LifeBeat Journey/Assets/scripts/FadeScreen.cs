using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    // Publika variabler som kan st�llas in i Unity-redigeraren
    public bool fadeOnStart = true;
    public float fadeDuration = 2f;
    public Color fadeColor;

    // Privat variabel f�r att lagra Renderer-komponenten p� GameObjectet
    private Renderer rend;

    // Start kallas innan f�rsta bilden uppdateras
    void Start()
    {
        // H�mta Renderer-komponenten p� GameObjectet som detta skript �r kopplat till
        rend = GetComponent<Renderer>();

        // Kontrollera om fadeOnStart �r true, och om s� �r fallet, starta FadeIn-metoden
        if (fadeOnStart)
        {
            FadeIn();
        }
    }

    // Offentlig metod f�r att starta en fade in-effekt
    public void FadeIn()
    {
        // Anropa Fade-metoden med alfav�rden f�r att fada in (fr�n 1 till 0)
        Fade(1, 0);
    }

    // Offentlig metod f�r att starta en fade out-effekt
    public void FadeOut()
    {
        // Anropa Fade-metoden med alfav�rden f�r att fada ut (fr�n 0 till 1)
        Fade(0, 1);
    }

    // Offentlig metod f�r att starta en generell fade-effekt med specificerade alfav�rden
    public void Fade(float alphaIn, float alphaOut)
    {
        // Starta en koroutin f�r att hantera gradvisa f�rgf�r�ndringar �ver tid
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    // Korutin f�r att hantera gradvisa f�rgf�r�ndringar
    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        // Initialisera en timer f�r fade-varaktigheten
        float timer = 0;

        // Forts�tt loopen tills timern �verstiger fade-varaktigheten
        while (timer <= fadeDuration)
        {
            // Skapa en ny f�rg baserad p� den ursprungliga fadeColor
            Color newColor = fadeColor;

            // Interpolera alfav�rdet p� den nya f�rgen mellan alphaIn och alphaOut �ver tid
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

            // S�tt f�rgen p� Renderer-komponentens material till den nya f�rgen
            rend.material.SetColor("_Color", newColor);

            // �ka timern baserat p� tiden som g�tt sedan den f�rra bilden
            timer += Time.deltaTime;

            // V�nta p� n�sta bildruta
            yield return null;
        }

        // Efter loopen, s�tt det slutliga alfav�rdet p� f�rgen
        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;

        // S�tt f�rgen p� Renderer-komponentens material till den slutliga f�rgen
        rend.material.SetColor("_Color", newColor2);
    }
}
