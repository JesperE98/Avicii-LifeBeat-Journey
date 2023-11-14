using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    // Publika variabler som kan ställas in i Unity-redigeraren
    public bool fadeOnStart = true;
    public float fadeDuration = 2f;
    public Color fadeColor;

    // Privat variabel för att lagra Renderer-komponenten på GameObjectet
    private Renderer rend;

    // Start kallas innan första bilden uppdateras
    void Start()
    {
        // Hämta Renderer-komponenten på GameObjectet som detta skript är kopplat till
        rend = GetComponent<Renderer>();

        // Kontrollera om fadeOnStart är true, och om så är fallet, starta FadeIn-metoden
        if (fadeOnStart)
        {
            FadeIn();
        }
    }

    // Offentlig metod för att starta en fade in-effekt
    public void FadeIn()
    {
        // Anropa Fade-metoden med alfavärden för att fada in (från 1 till 0)
        Fade(1, 0);
    }

    // Offentlig metod för att starta en fade out-effekt
    public void FadeOut()
    {
        // Anropa Fade-metoden med alfavärden för att fada ut (från 0 till 1)
        Fade(0, 1);
    }

    // Offentlig metod för att starta en generell fade-effekt med specificerade alfavärden
    public void Fade(float alphaIn, float alphaOut)
    {
        // Starta en koroutin för att hantera gradvisa färgförändringar över tid
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    // Korutin för att hantera gradvisa färgförändringar
    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        // Initialisera en timer för fade-varaktigheten
        float timer = 0;

        // Fortsätt loopen tills timern överstiger fade-varaktigheten
        while (timer <= fadeDuration)
        {
            // Skapa en ny färg baserad på den ursprungliga fadeColor
            Color newColor = fadeColor;

            // Interpolera alfavärdet på den nya färgen mellan alphaIn och alphaOut över tid
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

            // Sätt färgen på Renderer-komponentens material till den nya färgen
            rend.material.SetColor("_Color", newColor);

            // Öka timern baserat på tiden som gått sedan den förra bilden
            timer += Time.deltaTime;

            // Vänta på nästa bildruta
            yield return null;
        }

        // Efter loopen, sätt det slutliga alfavärdet på färgen
        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;

        // Sätt färgen på Renderer-komponentens material till den slutliga färgen
        rend.material.SetColor("_Color", newColor2);
    }
}
