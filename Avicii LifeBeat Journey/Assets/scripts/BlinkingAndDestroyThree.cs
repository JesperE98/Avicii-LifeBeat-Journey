using System.Collections;
using UnityEngine;

public class BlinkingAndDestroyThree : MonoBehaviour
{
    public float blinkInterval = 0.5f; // Tidsintervall för blinkning i sekunder
    private Renderer rend;
    private bool isPlayerInRange = false;


    private void Start()
    {

        rend = GetComponent<Renderer>();
        StartCoroutine(BlinkAndDestroy());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private IEnumerator BlinkAndDestroy()
    {
        while (!isPlayerInRange)
        {
            rend.enabled = !rend.enabled; // Alternativt: använd rend.material.color för att ändra färg

            yield return new WaitForSeconds(blinkInterval);
        }

        // Förstör GameObjectet när spelaren rör det
        Destroy(gameObject);
    }
}
