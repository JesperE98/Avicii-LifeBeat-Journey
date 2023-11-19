using System.Collections;
using UnityEngine;

public class BlinkingAndDestroy : MonoBehaviour
{
    public float blinkInterval = 0.5f; // Tidsintervall för blinkning i sekunder
    private Renderer rend;
    private bool isPlayerInRange = false;

    private MonitorTwo m_MonitorTwo;

    private void Start()
    {
        m_MonitorTwo = GameObject.Find("Monitor").GetComponent<MonitorTwo>();
        rend = GetComponent<Renderer>();
        StartCoroutine(BlinkAndDestroy());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            m_MonitorTwo.StartRoutine();
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
