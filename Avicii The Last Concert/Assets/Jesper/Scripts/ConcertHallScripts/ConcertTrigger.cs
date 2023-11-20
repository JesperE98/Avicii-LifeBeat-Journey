using UnityEngine;

namespace ConcertHallScripts
{
    public class ConcertTrigger : MonoBehaviour
    {
        private BoxCollider m_ConcertTriggerOneCollider;
        private SpotLightActivationRoutine m_SpotLightActivationRoutine;

        [SerializeField]
        private GameObject m_ActivateTrigger;

        private void Start()
        {
            m_ConcertTriggerOneCollider = GetComponent<BoxCollider>();
            m_SpotLightActivationRoutine = GameObject.Find("LightShow").GetComponent<SpotLightActivationRoutine>();

            m_ConcertTriggerOneCollider.enabled = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                m_ActivateTrigger.SetActive(true);
                m_SpotLightActivationRoutine.m_ConcertTriggerOne = true;
                m_SpotLightActivationRoutine.ConcertSetup();

            }
        }
    }
}

