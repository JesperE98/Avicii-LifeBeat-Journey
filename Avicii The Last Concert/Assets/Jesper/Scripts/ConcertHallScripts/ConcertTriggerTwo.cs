using UnityEngine;

public class ConcertTriggerTwo : MonoBehaviour
{
    private AudioManager m_AudioManager;
    private BoxCollider m_ConcertTriggerTwoCollider;
    private SpotLightActivationRoutine m_SpotLightActivationRoutine;

    private void Awake()
    {
        m_AudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        m_ConcertTriggerTwoCollider = GetComponent<BoxCollider>();
        m_SpotLightActivationRoutine = GameObject.Find("LightShow").GetComponent<SpotLightActivationRoutine>();

    }

    private void Start()
    {
        //m_AudioManager.PlayAudioTrack();
        m_ConcertTriggerTwoCollider.enabled = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_SpotLightActivationRoutine.m_ConcertTriggerTwo = true;
            m_ConcertTriggerTwoCollider.enabled = false;
            m_SpotLightActivationRoutine.ConcertSetup();
            
        }
    }
}
