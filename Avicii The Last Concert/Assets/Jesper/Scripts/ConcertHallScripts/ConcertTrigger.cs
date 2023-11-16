using UnityEngine;

public class ConcertTrigger : MonoBehaviour
{
    private BoxCollider m_ConcertTriggerOneCollider;
    private SpotLightActivationRoutine m_SpotLightActivationRoutine;

    private void Awake()
    {
        m_ConcertTriggerOneCollider = GetComponent<BoxCollider>();
        m_SpotLightActivationRoutine = GameObject.Find("LightShow").GetComponent<SpotLightActivationRoutine>();
    }

    private void Start()
    {
        m_ConcertTriggerOneCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Activated routine one");
            m_SpotLightActivationRoutine.m_ConcertTriggerOne = true;
            m_ConcertTriggerOneCollider.enabled = false;
            m_SpotLightActivationRoutine.ConcertSetup();
            
        }
    }
}
