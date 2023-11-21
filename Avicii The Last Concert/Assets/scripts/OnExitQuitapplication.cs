using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Kolla om det kolliderande objektet har en komponent av typen Player (eller vilken typ du beh�ver)
        if (other.CompareTag("Player"))
        {
            // Avsluta applikationen
            Application.Quit();
        }
    }
}
