using UnityEngine;

namespace ConcertHallScripts
{
    public class ConcertTriggerTwo : MonoBehaviour
    {
        private SpotLightActivationRoutine m_SpotLightActivationRoutine;

        [SerializeField]
        private GameObject m_ActivateTrigger;

        private void Start()
        {
            m_SpotLightActivationRoutine = GameObject.Find("LightShow").GetComponent<SpotLightActivationRoutine>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                m_ActivateTrigger.SetActive(true);
                m_SpotLightActivationRoutine.m_ConcertTriggerTwo = true;
                m_SpotLightActivationRoutine.ConcertSetup();

            }
        }
    }
}

