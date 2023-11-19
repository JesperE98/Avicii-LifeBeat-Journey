using System.Collections;
using UnityEngine;

public class BlinkingAndDestroy : MonoBehaviour
{
    public float blinkInterval = 0.5f; // Tidsintervall f�r blinkning i sekunder
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
            rend.enabled = !rend.enabled; // Alternativt: anv�nd rend.material.color f�r att �ndra f�rg

            yield return new WaitForSeconds(blinkInterval);
        }

        // F�rst�r GameObjectet n�r spelaren r�r det
        Destroy(gameObject);
    }
}
