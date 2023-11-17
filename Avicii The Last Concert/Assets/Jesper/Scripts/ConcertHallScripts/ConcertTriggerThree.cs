using UnityEngine;

namespace ConcertHallScripts
{
    public class ConcertTriggerThree : MonoBehaviour
    {
        private BoxCollider m_BoxCollider;
        private SpotLightActivationRoutine m_SpotLightActivationRoutine;

        private void Awake()
        {
            m_BoxCollider = GetComponent<BoxCollider>();
            m_SpotLightActivationRoutine = GameObject.Find("LightShow").GetComponent<SpotLightActivationRoutine>();
        }

        private void Start()
        {
            m_BoxCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                m_SpotLightActivationRoutine.m_ConcertTriggerThree = true;
                m_SpotLightActivationRoutine.ConcertSetup();
            }
        }
    }
}

