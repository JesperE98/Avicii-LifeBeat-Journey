using System.Collections;
using UnityEngine;

public class BlinkingAndDestroyThree : MonoBehaviour
{
    public float blinkInterval = 0.5f; // Tidsintervall f�r blinkning i sekunder
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
            rend.enabled = !rend.enabled; // Alternativt: anv�nd rend.material.color f�r att �ndra f�rg

            yield return new WaitForSeconds(blinkInterval);
        }

        // F�rst�r GameObjectet n�r spelaren r�r det
        Destroy(gameObject);
    }
}
